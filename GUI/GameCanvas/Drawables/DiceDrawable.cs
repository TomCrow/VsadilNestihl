using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.GUI.GameCanvas.Drawables
{
    public class DiceDrawable : Drawable
    {
        public DiceDrawable(Point p)
        {
            X = p.X;
            Y = p.Y;
            BitmapStill = Properties.Resources.dice_still;
            BitmapMouseOver = Properties.Resources.dice_mouse;
            BitmapMousePressed = Properties.Resources.dice_pressed;
            CenterX = BitmapStill.Width / 2;
            CenterY = BitmapStill.Height / 2;
            MouseOverCheckTransparency = true;
            Depth = -101;
        }

        public override void MouseClick(int mouseX, int mouseY)
        {
            base.MouseClick(mouseX, mouseY);
            Console.WriteLine("dice click");
        }

        public override void MouseDrag(int mouseX, int mouseY)
        {
            //SetPosition(mouseX, mouseY);
            //Console.WriteLine($"Dice dragged: {mouseX} , {mouseY}");
        }
    }
}
