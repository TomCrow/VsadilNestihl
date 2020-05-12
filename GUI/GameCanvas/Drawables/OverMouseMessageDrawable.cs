using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VsadilNestihl.GUI.GameCanvas.Drawables
{
    public class OverMouseMessageDrawable : Drawable
    {
        private readonly Point _mousePoint;
        private readonly string _message;
        private readonly Color _backColor;
        private readonly Color _textColor;
        private bool _sizeCalculated = false;
        private int _width;
        private int _height;

        public OverMouseMessageDrawable(Point mousePoint, string message, Color backColor, Color textColor)
        {
            _mousePoint = mousePoint;
            _message = message;
            _backColor = backColor;
            _textColor = textColor;
            Depth = -3000;
            MouseOverDisabled = true;
        }

        public override void Draw(Graphics graphics)
        {
            var font = new Font("Arial", 10f);
            if (!_sizeCalculated)
            {
                var strSize = graphics.MeasureString(_message, font);
                _width = (int)strSize.Width + 5;
                _height = (int)strSize.Height + 5;
                CenterX = _width / 2;
                CenterY = _height / 2;

                X = _mousePoint.X - CenterX;
                Y = _mousePoint.Y - CenterY - 20;

                _sizeCalculated = true;
            }

            var rect = new Rectangle(X, Y, _width, _height);
            var stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            graphics.FillRectangle(new SolidBrush(_backColor), rect);
            graphics.DrawString(_message, font, new SolidBrush(_textColor), rect, stringFormat);
        }
    }
}
