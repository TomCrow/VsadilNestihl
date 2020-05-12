using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;
using VsadilNestihl.GUI.Extensions;

namespace VsadilNestihl.GUI.GameCanvas.Drawables
{
    public class HorseCardDrawable : Drawable
    {
        private readonly int _width;
        private readonly int _height;
        private readonly IHorse _horse;

        public HorseCardDrawable(Point point, IHorse horse)
        {
            _width = 140;
            _height = 200;
            _horse = horse;

            CenterX = _width / 2;
            CenterY = _height / 2;

            X = point.X - CenterX;
            Y = point.Y - CenterY;

            Depth = -2001;
        }

        public override void Draw(Graphics graphics)
        {
            // Card
            var rect = new Rectangle(X, Y, _width, _height);
            var path = RoundedRect(rect, 10);
            graphics.FillPath(new SolidBrush(Color.White), path);
            graphics.DrawPath(new Pen(Color.Black), path);

            // Color
            var rect2 = new Rectangle(X + 5, Y + 5, _width - 10, 30);
            var path2 = RoundedRect(rect2, 5);
            graphics.FillPath(new SolidBrush(_horse.GetPlaceColor()), path2);

            // Name
            graphics.DrawString(_horse.GetName(), new Font("Arial", 12f, FontStyle.Bold), new SolidBrush(Color.White), rect2,
                new StringFormat() {Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center});

            var currY = Y + 40;
            graphics.DrawString($"Cena: {_horse.GetPrice().ToThousandsSpacedString()}", new Font("Arial", 8f), new SolidBrush(Color.Black), X + 5, currY);
            currY += 13;
            graphics.DrawString($"Prohlídka: {_horse.GetVisitPrice().ToThousandsSpacedString()}", new Font("Arial", 8f), new SolidBrush(Color.Black), X + 5, currY);
            currY += 23;
            graphics.DrawString($"Jeden dostih: {_horse.GetRaceVisitPrice(1).ToThousandsSpacedString()}", new Font("Arial", 8f), new SolidBrush(Color.Black), X + 5, currY);
            currY += 13;
            graphics.DrawString($"Dva dostihy: {_horse.GetRaceVisitPrice(2).ToThousandsSpacedString()}", new Font("Arial", 8f), new SolidBrush(Color.Black), X + 5, currY);
            currY += 13;
            graphics.DrawString($"Tri dostihy: {_horse.GetRaceVisitPrice(3).ToThousandsSpacedString()}", new Font("Arial", 8f), new SolidBrush(Color.Black), X + 5, currY);
            currY += 13;
            graphics.DrawString($"Ctyri dostihy: {_horse.GetRaceVisitPrice(4).ToThousandsSpacedString()}", new Font("Arial", 8f), new SolidBrush(Color.Black), X + 5, currY);
            currY += 23;
            graphics.DrawString($"Hlavni dostih: {_horse.GetRaceVisitPrice(5).ToThousandsSpacedString()}", new Font("Arial", 8f), new SolidBrush(Color.Black), X + 5, currY);

            currY += 13;
            currY += 13;
            graphics.DrawString($"Cena dostihu: {_horse.GetRacePrice().ToThousandsSpacedString()}", new Font("Arial", 8f), new SolidBrush(Color.Black), X + 5, currY);
            currY += 13;
            graphics.DrawString($"Cena h. dostihu: {_horse.GetMainRacePrice().ToThousandsSpacedString()}", new Font("Arial", 8f), new SolidBrush(Color.Black), X + 5, currY);
        }

        public override bool CheckMouseOver(int mouseX, int mouseY)
        {
            if (mouseX > X && mouseX < X + _width &&
                mouseY > Y && mouseY < Y + _height)
                return true;

            return false;
        }

        public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
