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
    public static class PlayerPlaceHelper
    {
        private static IReadOnlyList<Point> _placePoints = new List<Point>
        {
            new Point(14, 15),
            new Point(31, 14),
            new Point(42, 24),
            new Point(12, 28),
            new Point(20, 38),
            new Point(37, 38)
        };

        public static Point GetFreePosition(List<Point> occupiedPoints)
        {
            foreach (var placePoint in _placePoints)
            {
                if (occupiedPoints.Any(x => x == placePoint))
                    continue;

                return placePoint;
            }

            throw new Exception("BIG ERROR"); // TODO: refactor to concrete exception
        }

        [Obsolete]
        public static void SetPlayersPositions(List<Animators.PlayerAnimator> playersDrawables, Rectangle position)
        {
            if (playersDrawables.Count == 1)
            {
                playersDrawables[0].MoveTo(position.X + 25, position.Y + 25);
            }
            else if (playersDrawables.Count == 2)
            {
                playersDrawables[0].MoveTo(position.X + 15, position.Y + 25);
                playersDrawables[1].MoveTo(position.X + 35, position.Y + 25);
            }
            else if (playersDrawables.Count == 3)
            {
                playersDrawables[0].MoveTo(position.X + 19, position.Y + 20);
                playersDrawables[1].MoveTo(position.X + 37, position.Y + 20);
                playersDrawables[2].MoveTo(position.X + 28, position.Y + 35);
            }
            else if (playersDrawables.Count == 4)
            {
                playersDrawables[0].MoveTo(position.X + 18, position.Y + 19);
                playersDrawables[1].MoveTo(position.X + 37, position.Y + 19);
                playersDrawables[2].MoveTo(position.X + 18, position.Y + 37);
                playersDrawables[3].MoveTo(position.X + 37, position.Y + 37);
            }
            else if (playersDrawables.Count == 5)
            {
                playersDrawables[0].MoveTo(position.X + 15, position.Y + 22);
                playersDrawables[1].MoveTo(position.X + 32, position.Y + 16);
                playersDrawables[2].MoveTo(position.X + 27, position.Y + 29);
                playersDrawables[3].MoveTo(position.X + 39, position.Y + 35);
                playersDrawables[4].MoveTo(position.X + 17, position.Y + 39);
            }
            else if (playersDrawables.Count == 6)
            {
                playersDrawables[0].MoveTo(position.X + 14, position.Y + 15);
                playersDrawables[1].MoveTo(position.X + 31, position.Y + 14);
                playersDrawables[2].MoveTo(position.X + 42, position.Y + 24);
                playersDrawables[3].MoveTo(position.X + 12, position.Y + 28);
                playersDrawables[4].MoveTo(position.X + 20, position.Y + 38);
                playersDrawables[5].MoveTo(position.X + 37, position.Y + 38);
            }
        }
    }
}
