using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Player;

namespace VsadilNestihl.GUI.GameCanvas.Drawables
{
    public class PlayerDrawable : Drawable
    {
        public PlayerDrawable(Color playerColor)
        {
            var bmp = new Bitmap(Properties.Resources.player);
            using (var g = Graphics.FromImage(bmp))
            {
                var colorMap = new ColorMap[1];
                colorMap[0] = new ColorMap
                {
                    OldColor = Color.FromArgb(255, 237, 28, 36),
                    NewColor = playerColor
                };
                var attr = new ImageAttributes();
                attr.SetRemapTable(colorMap);
                var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                g.DrawImage(bmp, rect, 0, 0, rect.Width, rect.Height, GraphicsUnit.Pixel, attr);

                BitmapStill = bmp;
            }

            CenterX = 8;
            CenterY = 11;
            Depth = -100;


            MouseOverCheckTransparency = true;
            //MouseOverDisabled = true;
        }

        public override void MouseDrag(int mouseX, int mouseY)
        {
            //SetPosition(mouseX, mouseY);
            //Console.WriteLine($"Dice dragged: {mouseX} , {mouseY}");
        }
    }
}
