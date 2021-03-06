﻿using System;
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
        private readonly int _width;
        private readonly int _height;

        public BoardPositionDrawable(Rectangle rectangle)
        {
            X = rectangle.X;
            Y = rectangle.Y;
            _width = rectangle.Width;
            _height = rectangle.Height;
            MouseOverCheckTransparency = false;
        }

        public override void Draw(Graphics graphics)
        {
            if (MouseIsOver || MouseIsPressed)
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(75, Color.White)), X, Y, _width, _height);
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
