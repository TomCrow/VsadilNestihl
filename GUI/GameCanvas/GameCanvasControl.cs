using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VsadilNestihl.Game.Board.DostihyASazky;
using VsadilNestihl.GUI.GameCanvas.Drawables;
using VsadilNestihl.GUI.GameCanvas.Helpers;

namespace VsadilNestihl.GUI.GameCanvas
{
    public partial class GameCanvasControl : UserControl, IGameCanvas
    {
        private readonly List<IDrawable> _drawables = new List<IDrawable>();
        private IDrawable _mouseOverDrawable = null;
        private IDrawable _mousePressedDrawable = null;

        public GameCanvasControl()
        {
            var board = new BoardDrawable(new Point(0, 0));
            _drawables.Add(board);

            var dice = new DiceDrawable(new Point(724 / 2, 724 / 2));
            _drawables.Add(dice);
            
            InitializeComponent();
        }

        public void AddDrawable(IDrawable drawable)
        {
            _drawables.Add(drawable);
            Refresh();
        }

        public void AddDrawables(IEnumerable<IDrawable> drawables)
        {
            foreach (var drawable in drawables)
                _drawables.Add(drawable);

            Refresh();
        }

        private List<IDrawable> GetDrawablesByDepth()
        {
            return _drawables.OrderByDescending(x => x.GetDepth()).ToList();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;

            foreach (var drawable in GetDrawablesByDepth())
                drawable.Draw(g);
        }

        private void BoardControl_MouseMove(object sender, MouseEventArgs e)
        {
            var drawables = GetDrawablesByDepth();
            for (var i = drawables.Count - 1; i >= 0; i--)
            {
                if (drawables[i].IsMouseOver(e.X, e.Y))
                {
                    if (_mouseOverDrawable == drawables[i])
                        return;

                    _mouseOverDrawable?.SetMouseOver(false);
                    drawables[i].SetMouseOver(true);
                    _mouseOverDrawable = drawables[i];
                    Cursor = Cursors.Hand;
                    Refresh();
                    return;
                }
            }

            _mouseOverDrawable?.SetMouseOver(false);
            _mouseOverDrawable = null;
            Cursor = Cursors.Default;
            Refresh();
        }

        private void BoardControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (_mouseOverDrawable == null)
                return;

            _mouseOverDrawable.SetMousePressed(true);
            _mousePressedDrawable = _mouseOverDrawable;
            Refresh();
        }

        private void BoardControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (_mousePressedDrawable == null)
                return;
            
            _mousePressedDrawable.SetMousePressed(false);
            Refresh();

            if (_mousePressedDrawable == _mouseOverDrawable)
                _mousePressedDrawable.Click();

            _mousePressedDrawable = null;
        }
    }
}
