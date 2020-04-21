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
using VsadilNestihl.GUI.Extensions;
using VsadilNestihl.GUI.GameCanvas.Drawables;
using VsadilNestihl.GUI.GameCanvas.Helpers;

namespace VsadilNestihl.GUI.GameCanvas
{
    public partial class GameCanvasControl : UserControl, IGameCanvas
    {
        private readonly List<IDrawable> _drawables = new List<IDrawable>();
        private IDrawable _mouseOverDrawable = null;
        private IDrawable _mousePressedDrawable = null;
        private IDrawable _mouseOverWhilePressedDrawable = null;
        private bool _mousePressed = false;

        public GameCanvasControl()
        {
            InitializeComponent();
        }

        public void AddDrawable(IDrawable drawable)
        {
            _drawables.Add(drawable);
            drawable.PositionUpdated += DrawableOnPositionUpdated;
            Refresh();
        }
        
        public void AddDrawables(IEnumerable<IDrawable> drawables)
        {
            foreach (var drawable in drawables)
            {
                drawable.PositionUpdated += DrawableOnPositionUpdated;
                _drawables.Add(drawable);
            }

            Refresh();
        }

        public void RemoveDrawable(IDrawable drawable)
        {
            _drawables.Remove(drawable);
            drawable.PositionUpdated -= DrawableOnPositionUpdated;
            Refresh();
        }

        public void RefreshCanvas()
        {
            this.InvokeIfRequired(Refresh);
        }

        private void DrawableOnPositionUpdated()
        {
            this.InvokeIfRequired(Refresh);
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
            _mousePressedDrawable?.MouseDrag(e.X, e.Y);
            
            var drawables = GetDrawablesByDepth();
            for (var i = drawables.Count - 1; i >= 0; i--)
            {
                if (drawables[i].CheckMouseOver(e.X, e.Y))
                {
                    if (_mousePressed)
                    {
                        if (_mouseOverWhilePressedDrawable == drawables[i])
                            return;

                        _mouseOverWhilePressedDrawable = drawables[i];
                        return;
                    }
                    else
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
            }

            _mouseOverDrawable?.SetMouseOver(false);
            _mouseOverDrawable = null;
            _mouseOverWhilePressedDrawable = null;
            Cursor = Cursors.Default;
            Refresh();
        }

        private void BoardControl_MouseDown(object sender, MouseEventArgs e)
        {
            _mousePressed = true;
            if (_mouseOverDrawable == null)
                return;

            _mouseOverDrawable.SetMousePressed(true, e.X, e.Y);
            _mousePressedDrawable = _mouseOverDrawable;
            _mouseOverWhilePressedDrawable = _mouseOverDrawable;
            Refresh();
        }

        private void BoardControl_MouseUp(object sender, MouseEventArgs e)
        {
            _mousePressed = false;
            if (_mousePressedDrawable == null)
                return;
            
            _mousePressedDrawable.SetMousePressed(false, e.X, e.Y);
            Refresh();

            if (_mousePressedDrawable == _mouseOverWhilePressedDrawable)
                _mousePressedDrawable.MouseClick(e.X, e.Y);

            _mousePressedDrawable = null;
        }
    }
}
