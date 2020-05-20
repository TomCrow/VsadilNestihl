using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;
using VsadilNestihl.GUI.GameCanvas.Animators;
using VsadilNestihl.GUI.GameCanvas.Drawables;
using VsadilNestihl.GUI.GameCanvas.Helpers;
using WinFormAnimation;

namespace VsadilNestihl.GUI.GameCanvas
{
    public class PlayersAnimator
    {
        private readonly Dictionary<PlayerDrawable, ConcretePlace> _playersPlaces = new Dictionary<PlayerDrawable, ConcretePlace>();
        private readonly Dictionary<PlayerDrawable, Queue<ConcretePlace>> _playersWaitingMoves = new Dictionary<PlayerDrawable, Queue<ConcretePlace>>();
        
        private PlayerDrawable _currentAnimatingPlayer = null;
        private readonly object _lock = new object();
        //private readonly SafeInvoker<Float2D> _frameCallbackInvoker;
        //private readonly SafeInvoker _endCallback;

        public PlayersAnimator()
        {
            //_frameCallbackInvoker = new SafeInvoker<Float2D>(FrameCallback);
            //_endCallback = new SafeInvoker(EndCallback);
        }

        public void AddPlayer(PlayerDrawable player, ConcretePlace place)
        {
            if (_playersPlaces.ContainsKey(player))
                return; // TODO: throw exception

            _playersPlaces.Add(player, place);
        }

        public void MoveTo(PlayerDrawable player, ConcretePlace place)
        {
            lock (_lock)
            {
                if (!_playersPlaces.ContainsKey(player))
                    return; // TODO:  throw exception

                if (!_playersWaitingMoves.ContainsKey(player))
                    _playersWaitingMoves.Add(player, new Queue<ConcretePlace>());

                _playersWaitingMoves[player].Enqueue(place);

                if (_currentAnimatingPlayer == null)
                {
                    _currentAnimatingPlayer = player;
                    MoveTo(player, GetFreePointForPlace(place));
                }
            }
        }

        private Point GetFreePointForPlace(ConcretePlace place)
        {
            var leftCornerPoint = PlacesPositions.GetPlayerPosition(place);
            return new Point(leftCornerPoint.X + 25, leftCornerPoint.Y + 25);
        }

        private void MoveTo(PlayerDrawable player, Point point)
        {
            var animator = new Animator2D(FPSLimiterKnownValues.LimitSixty);
            var currentPosition = player.GetPosition();
            animator.Paths = CreatePath(currentPosition.X, currentPosition.Y, point.X, point.Y);
            animator.Play(new SafeInvoker<Float2D>(float2D =>
            {
                lock (_lock)
                {
                    if (_currentAnimatingPlayer == player)
                        FrameCallback(float2D);
                }
            }), 
                new SafeInvoker(() =>
            {
                lock (_lock)
                {
                    if (_currentAnimatingPlayer == player)
                        EndCallback();
                }
            }));
        }

        private Path2D[] CreatePath(int startX, int startY, int endX, int endY)
        {
            var middleX = (startX + endX) / 2;
            var middleY = (startY + endY) / 2;
            middleY -= 15;

            return new Path2D(
                    new Path(startX, middleX, 150, AnimationFunctions.Liner),
                    new Path(startY, middleY, 150, AnimationFunctions.QuadraticEaseIn))
                .ContinueTo(new Path2D(
                    new Path(middleX, endX, 150, AnimationFunctions.Liner),
                    new Path(middleY, endY, 150, AnimationFunctions.QuadraticEaseOut)));
        }

        private void FrameCallback(Float2D float2D)
        {
            lock (_lock)
            {
                _currentAnimatingPlayer?.SetPosition(float2D);
                if (_currentAnimatingPlayer == null)
                    Console.WriteLine("Frame callback null");
            }
        }

        private void EndCallback()
        {
            Console.WriteLine("End callback");
            lock (_lock)
            {
                if (_currentAnimatingPlayer == null)
                    return; // TODO log error

                var nextPlace = GetNextPlaceForPlayer(_currentAnimatingPlayer);
                if (nextPlace != null)
                {
                    MoveTo(_currentAnimatingPlayer, GetFreePointForPlace(nextPlace.Value));
                }
                else
                {
                    foreach (var playerWaitingMove in _playersWaitingMoves)
                    {
                        nextPlace = GetNextPlaceForPlayer(_currentAnimatingPlayer);
                        if (nextPlace != null)
                        {
                            MoveTo(playerWaitingMove.Key, GetFreePointForPlace(nextPlace.Value));
                            return;
                        }
                    }

                    // All animations done
                    _currentAnimatingPlayer = null;
                }
            }
        }

        private ConcretePlace? GetNextPlaceForPlayer(PlayerDrawable player)
        {
            lock (_lock)
            {
                if (!_playersWaitingMoves.ContainsKey(player))
                    return null;

                if (!_playersWaitingMoves[player].Any())
                {
                    _playersWaitingMoves.Remove(player);
                    return null;
                }

                return _playersWaitingMoves[player].Dequeue();
            }
        }
    }
}
