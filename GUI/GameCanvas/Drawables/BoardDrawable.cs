using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.GUI.GameCanvas.Drawables
{
    public class BoardDrawable : Drawable
    {
        public BoardDrawable(Point p)
        {
            X = p.X;
            Y = p.Y;
            Depth = 100;
            BitmapStill = Properties.Resources.board;
            MouseOverDisabled = true;
        }

        public int GetX()
        {
            return X;
        }

        public int GetY()
        {
            return Y;
        }

        public int GetWidth()
        {
            return BitmapStill.Width;
        }

        public int GetHeight()
        {
            return BitmapStill.Height;
        }
    }
}
