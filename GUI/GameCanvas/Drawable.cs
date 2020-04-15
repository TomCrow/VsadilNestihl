using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.GUI.GameCanvas
{
    public abstract class Drawable : IDrawable
    {
        protected int X { get; set; }
        protected int Y { get; set; }
        protected int Depth { get; set; }
        protected int CenterX { get; set; }
        protected int CenterY { get; set; }
        protected Bitmap BitmapStill { get; set; }
        protected Bitmap BitmapMouseOver { get; set; }
        protected Bitmap BitmapMousePressed { get; set; }
        protected bool MouseOverDisabled { get; set; }
        protected bool MouseOverCheckTransparency { get; set; }
        
        public bool MouseIsOver { get; private set; }
        public bool MouseIsPressed { get; private set; }

        public event Action PositionUpdated;
        public event Action<int, int> MousePressed;
        public event Action<int, int> MouseReleased;
        public event Action<int, int> MouseDragged;
        public event Action Clicked;

        public virtual void SetPosition(int x, int y)
        {
            X = x;
            Y = y;
            PositionUpdated?.Invoke();
        }

        public virtual void SetPosition(Point p)
        {
            X = p.X;
            Y = p.Y;
            PositionUpdated?.Invoke();
        }

        public virtual int GetDepth()
        {
            return Depth;
        }

        public virtual void Draw(Graphics graphics)
        {
            if (MouseIsPressed && BitmapMousePressed != null)
                DrawMousePressed(graphics);
            else if (MouseIsOver && BitmapMouseOver != null)
                DrawMouseOver(graphics);
            else if (BitmapStill != null)
                DrawStill(graphics);
        }

        public virtual void DrawStill(Graphics graphics)
        {
            graphics.DrawImage(BitmapStill, X - CenterX, Y - CenterY, BitmapStill.Width, BitmapStill.Height);
        }

        public virtual void DrawMouseOver(Graphics graphics)
        {
            graphics.DrawImage(BitmapMouseOver, X - CenterX, Y - CenterY, BitmapMouseOver.Width, BitmapMouseOver.Height);
        }

        public virtual void DrawMousePressed(Graphics graphics)
        {
            graphics.DrawImage(BitmapMousePressed, X - CenterX, Y - CenterY, BitmapMousePressed.Width, BitmapMousePressed.Height);
        }

        public virtual bool CheckMouseOver(int mouseX, int mouseY)
        {
            if (MouseOverDisabled)
                return false;

            var leftX = BitmapStill.Width - CenterX;
            var leftY = BitmapStill.Height - CenterY;

            if (mouseX > X - CenterX && mouseX < X + leftX &&
                mouseY > Y - CenterY && mouseY < Y + leftY)
            {
                if (!MouseOverCheckTransparency)
                    return true;

                var localX = mouseX - (X - CenterX);
                var localY = mouseY - (Y - CenterY);
                var color = BitmapStill.GetPixel(localX, localY);
                if (color.A > 0)
                    return true;
            }

            return false;
        }

        public virtual void SetMouseOver(bool mouseOver)
        {
            MouseIsOver = mouseOver;
        }
        
        public virtual void SetMousePressed(bool pressed, int mouseX, int mouseY)
        {
            MouseIsPressed = pressed;

            if (MouseIsPressed)
                MousePressed?.Invoke(mouseX, mouseY);
            else
                MouseReleased?.Invoke(mouseX, mouseY);
        }
        
        public virtual void MouseClick(int mouseX, int mouseY)
        {
            Clicked?.Invoke();
        }

        public virtual void MouseDrag(int mouseX, int mouseY)
        {
            MouseDragged?.Invoke(mouseX, mouseY);
        }
    }
}
