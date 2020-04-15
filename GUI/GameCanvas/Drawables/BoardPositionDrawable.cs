using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.GUI.GameCanvas.Drawables
{
    public class BoardPositionDrawable : Drawable
    {
        public BoardPositionDrawable(Point p)
        {
            X = p.X;
            Y = p.Y;
            MouseOverCheckTransparency = false;
        }

        public override void Draw(Graphics graphics)
        {
            if (MouseIsOver || MouseIsPressed)
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(75, Color.White)), X, Y, 49, 49);
        }

        public override bool CheckMouseOver(int mouseX, int mouseY)
        {
            if (mouseX > X && mouseX < X + 49 &&
                mouseY > Y && mouseY < Y + 49)
                return true;

            return false;
        }
    }
}
