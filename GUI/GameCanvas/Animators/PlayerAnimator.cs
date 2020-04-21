using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.GUI.GameCanvas.Drawables;
using WinFormAnimation;

namespace VsadilNestihl.GUI.GameCanvas.Animators
{
    public class PlayerAnimator
    {
        private readonly PlayerDrawable _playerDrawable;
        private bool _running = false;
        private readonly object _runningLock = new object();

        private Float2D _lastPathEnd = null;
        private readonly List<Path2D> _waitingPaths = new List<Path2D>();

        private readonly SafeInvoker<Float2D> _frameCallbackInvoker;
        private readonly SafeInvoker _endCallback;

        public PlayerAnimator(PlayerDrawable playerDrawable)
        {
            _playerDrawable = playerDrawable;
            _frameCallbackInvoker = new SafeInvoker<Float2D>(FrameCallback);
            _endCallback = new SafeInvoker(EndCallback);
        }

        public void MoveTo(int x, int y)
        {
            lock (_runningLock)
            {
                if (!_running)
                {
                    var animator = new Animator2D(FPSLimiterKnownValues.LimitSixty);
                    var currPos = _playerDrawable.GetPosition();

                    animator.Paths = CreatePath(currPos.X, currPos.Y, x, y);

                    _lastPathEnd = animator.Paths.Last().End;
                    animator.Play(_frameCallbackInvoker, _endCallback);
                    _running = true;
                }
                else
                {
                    var path = CreatePath((int)_lastPathEnd.X, (int)_lastPathEnd.Y, x, y);
                    _lastPathEnd = path.Last().End;

                    foreach (var path2D in path)
                        _waitingPaths.Add(path2D);
                }
            }
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
            _playerDrawable.SetPosition(float2D);
        }

        private void EndCallback()
        {
            lock (_runningLock)
            {
                if (_waitingPaths.Any())
                {
                    var animator = new Animator2D(FPSLimiterKnownValues.LimitSixty)
                    {
                        Paths = _waitingPaths.ToArray()
                    };
                    _waitingPaths.Clear();

                    animator.Play(_frameCallbackInvoker, _endCallback);
                }
                else
                {
                    _running = false;
                }
            }
        }
    }
}
