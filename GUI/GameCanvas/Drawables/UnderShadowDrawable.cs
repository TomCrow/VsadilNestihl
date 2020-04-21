using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.GUI.GameCanvas.Drawables
{
    public class UnderShadowDrawable : Drawable
    {
        private readonly int _width;
        private readonly int _height;

        public UnderShadowDrawable(Rectangle rectangle)
        {
            X = rectangle.X;
            Y = rectangle.Y;
            _width = rectangle.Width;
            _height = rectangle.Height;
            Depth = -2000;
        }

        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Black)), X, Y, _width, _height);
        }

        public override bool CheckMouseOver(int mouseX, int mouseY)
        {
            if (mouseX > X && mouseX < X + _width &&
                mouseY > Y && mouseY < Y + _height)
                return true;

            return false;
        }
    }
}
