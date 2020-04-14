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
        protected int CenterX { get; set; }
        protected int CenterY { get; set; }
        protected Bitmap BitmapStill { get; set; }
        protected Bitmap BitmapMouseOver { get; set; }
        protected Bitmap BitmapMousePressed { get; set; }
        protected bool MouseOverCheckTransparency { get; set; }
        
        public bool MouseOver { get; private set; }
        public bool MousePressed { get; private set; }

        public event Action PositionUpdated;
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
            return 0;
        }

        public virtual void Draw(Graphics graphics)
        {
            if (MousePressed && BitmapMousePressed != null)
                DrawMousePressed(graphics);
            else if (MouseOver && BitmapMouseOver != null)
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

        public virtual bool IsMouseOver(int mouseX, int mouseY)
        {
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
            MouseOver = mouseOver;
        }

        public virtual void SetMousePressed(bool pressed)
        {
            MousePressed = pressed;
        }

        public virtual void Click()
        {
            Clicked?.Invoke();
        }
    }
}
