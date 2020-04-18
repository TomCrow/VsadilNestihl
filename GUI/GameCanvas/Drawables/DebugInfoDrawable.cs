using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.GUI.GameCanvas.Drawables
{
    public class DebugInfoDrawable : Drawable
    {
        public string NaTahu { get; set; }
        public string Hodil { get; set; }

        public DebugInfoDrawable(Point p)
        {
            X = p.X;
            Y = p.Y;
            Depth = -1000;
            MouseOverDisabled = true;
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawString($"Na tahu: {NaTahu}", new Font("Arial", 12f), new SolidBrush(Color.Black), X, Y);
            graphics.DrawString($"Hodil: {Hodil}", new Font("Arial", 12f), new SolidBrush(Color.Black), X, Y + 15);
        }
    }
}
