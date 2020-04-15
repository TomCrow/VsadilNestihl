using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;
using VsadilNestihl.GUI.GameCanvas.Drawables;

namespace VsadilNestihl.GUI.GameCanvas.Helpers
{
    public static class PlayerPositionSetterHelper
    {
        public static void SetPlayersPositions(List<PlayerDrawable> playersDrawables, Point leftCornerPoint)
        {
            if (playersDrawables.Count == 1)
            {
                playersDrawables[0].SetPosition(leftCornerPoint.X + 25, leftCornerPoint.Y + 25);
            }
            else if (playersDrawables.Count == 2)
            {
                playersDrawables[0].SetPosition(leftCornerPoint.X + 15, leftCornerPoint.Y + 25);
                playersDrawables[1].SetPosition(leftCornerPoint.X + 35, leftCornerPoint.Y + 25);
            }
            else if (playersDrawables.Count == 3)
            {
                playersDrawables[0].SetPosition(leftCornerPoint.X + 19, leftCornerPoint.Y + 20);
                playersDrawables[1].SetPosition(leftCornerPoint.X + 37, leftCornerPoint.Y + 20);
                playersDrawables[2].SetPosition(leftCornerPoint.X + 28, leftCornerPoint.Y + 35);
            }
            else if (playersDrawables.Count == 4)
            {
                playersDrawables[0].SetPosition(leftCornerPoint.X + 18, leftCornerPoint.Y + 19);
                playersDrawables[1].SetPosition(leftCornerPoint.X + 37, leftCornerPoint.Y + 19);
                playersDrawables[2].SetPosition(leftCornerPoint.X + 18, leftCornerPoint.Y + 37);
                playersDrawables[3].SetPosition(leftCornerPoint.X + 37, leftCornerPoint.Y + 37);
            }
            else if (playersDrawables.Count == 5)
            {
                playersDrawables[0].SetPosition(leftCornerPoint.X + 15, leftCornerPoint.Y + 22);
                playersDrawables[1].SetPosition(leftCornerPoint.X + 32, leftCornerPoint.Y + 16);
                playersDrawables[2].SetPosition(leftCornerPoint.X + 27, leftCornerPoint.Y + 29);
                playersDrawables[3].SetPosition(leftCornerPoint.X + 39, leftCornerPoint.Y + 35);
                playersDrawables[4].SetPosition(leftCornerPoint.X + 17, leftCornerPoint.Y + 39);
            }
            else if (playersDrawables.Count == 6)
            {
                playersDrawables[0].SetPosition(leftCornerPoint.X + 14, leftCornerPoint.Y + 15);
                playersDrawables[1].SetPosition(leftCornerPoint.X + 31, leftCornerPoint.Y + 14);
                playersDrawables[2].SetPosition(leftCornerPoint.X + 42, leftCornerPoint.Y + 24);
                playersDrawables[3].SetPosition(leftCornerPoint.X + 12, leftCornerPoint.Y + 28);
                playersDrawables[4].SetPosition(leftCornerPoint.X + 20, leftCornerPoint.Y + 38);
                playersDrawables[5].SetPosition(leftCornerPoint.X + 37, leftCornerPoint.Y + 38);
            }
        }
    }
}
