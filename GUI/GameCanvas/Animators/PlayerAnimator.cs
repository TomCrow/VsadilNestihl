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
                    var animator = new Animator2D(FPSLimiterKnownValues.LimitTwoHundred);
                    var currPos = _playerDrawable.GetPosition();
                    animator.Paths = new Path2D(currPos.X, x, currPos.Y, y, 300).ToArray();
                    _lastPathEnd = animator.Paths.Last().End;
                    animator.Play(_frameCallbackInvoker, _endCallback);
                    _running = true;
                }
                else
                {
                    var path = new Path2D(_lastPathEnd.X, x, _lastPathEnd.Y, y, 300);
                    _lastPathEnd = path.End;
                    _waitingPaths.Add(path);
                }
            }
        }

        private void FrameCallback(Float2D float2D)
        {
            _playerDrawable.SetPosition(float2D);
        }

        private void EndCallback()
        {
            Console.WriteLine("END CALLBACK");
            lock (_runningLock)
            {
                if (_waitingPaths.Any())
                {
                    var animator = new Animator2D(FPSLimiterKnownValues.LimitTwoHundred)
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
