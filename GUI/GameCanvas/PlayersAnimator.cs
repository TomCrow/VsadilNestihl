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
        private ConcretePlace _currentEndPlace;
        private Point _currentEndPosition;
        private readonly object _lock = new object();
        private readonly SafeInvoker<Float2D> _frameCallback;

        public event Action<PlayerDrawable, ConcretePlace> PlayerAtPlace;

        public PlayersAnimator()
        {
            _frameCallback = new SafeInvoker<Float2D>(FrameCallback);
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

                if (_currentAnimatingPlayer == null)
                {
                    _currentAnimatingPlayer = player;
                    _currentEndPlace = place;
                    _playersPlaces[player] = place;
                    MoveTo(player, GetFreePointForPlace(place));
                }
                else
                {
                    if (!_playersWaitingMoves.ContainsKey(player))
                        _playersWaitingMoves.Add(player, new Queue<ConcretePlace>());

                    _playersWaitingMoves[player].Enqueue(place);
                }
            }
        }

        private Point GetFreePointForPlace(ConcretePlace place)
        {
            var leftCornerPoint = PlacesPositions.GetPlayerPosition(place);
            var occupiedPositions = GetOccupiedPositions(place, leftCornerPoint.Location);
            var freePositionPoint = PlayerPlaceHelper.GetFreePosition(occupiedPositions);
            return new Point(leftCornerPoint.X + freePositionPoint.X, leftCornerPoint.Y + freePositionPoint.Y);
        }

        private List<Point> GetOccupiedPositions(ConcretePlace place, Point leftCornerPoint)
        {
            var occupiedPoints = new List<Point>();
            foreach (var playerPoint in _playersPlaces.Where(x => x.Value == place).Select(o => o.Key.GetPosition()))
                occupiedPoints.Add(new Point(playerPoint.X - leftCornerPoint.X, playerPoint.Y - leftCornerPoint.Y));

            return occupiedPoints;
        }

        private void MoveTo(PlayerDrawable player, Point point)
        {
            _currentEndPosition = point;
            var animator = new Animator2D(FPSLimiterKnownValues.LimitSixty);
            var currentPosition = player.GetPosition();
            animator.Paths = CreatePath(currentPosition.X, currentPosition.Y, point.X, point.Y);
            animator.Play(_frameCallback);
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
                if (_currentAnimatingPlayer == null)
                    return;

                _currentAnimatingPlayer.SetPosition(float2D);

                if (float2D == _currentEndPosition)
                    AnimationEnd();
            }
        }

        private void AnimationEnd()
        {
            lock (_lock)
            {
                if (_currentAnimatingPlayer == null)
                    return;

                PlayerAtPlace?.Invoke(_currentAnimatingPlayer, _currentEndPlace);

                var nextPlace = GetNextPlaceForPlayer(_currentAnimatingPlayer);
                if (nextPlace != null)
                {
                    _currentEndPlace = nextPlace.Value;
                    MoveTo(_currentAnimatingPlayer, GetFreePointForPlace(nextPlace.Value));
                }
                else
                {
                    foreach (var playerWaitingMove in _playersWaitingMoves)
                    {
                        nextPlace = GetNextPlaceForPlayer(_currentAnimatingPlayer);
                        if (nextPlace != null)
                        {
                            _currentAnimatingPlayer = playerWaitingMove.Key;
                            _currentEndPlace = nextPlace.Value;
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
