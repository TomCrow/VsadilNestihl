using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;
using VsadilNestihl.GUI.GameCanvas.Drawables;

namespace VsadilNestihl.GUI.GameCanvas.Helpers
{
    public static class CommonDrawables
    {
        public static List<IDrawable> GetBoardPositions(Action<ConcretePlace, int> positionClickedAction)
        {
            var list = new List<IDrawable>();
            foreach (var concretePlace in (ConcretePlace[])Enum.GetValues(typeof(ConcretePlace)))
            {
                var point = PlacesPositions.GetByPlaceAndPosition(concretePlace, 0);
                var drawable = new BoardPositionDrawable(point);

                if (positionClickedAction != null)
                    drawable.Clicked += () => positionClickedAction?.Invoke(concretePlace, 0);

                list.Add(drawable);
            }
            return list;
        }
    }
}
