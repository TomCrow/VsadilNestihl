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
        public static List<IDrawable> GetBoardPlacePositions(Action<ConcretePlace> clickedAction)
        {
            var list = new List<IDrawable>();
            foreach (var concretePlace in (ConcretePlace[])Enum.GetValues(typeof(ConcretePlace)))
            {
                var rect = PlacesPositions.GetPlayerPosition(concretePlace);
                var drawable = new BoardPositionDrawable(rect);

                if (clickedAction != null)
                    drawable.Clicked += () => clickedAction?.Invoke(concretePlace);

                list.Add(drawable);
            }
            return list;
        }

        public static List<IDrawable> GetBoardIconPositions(Action<ConcretePlace> clickedAction)
        {
            var list = new List<IDrawable>();
            foreach (var concretePlace in (ConcretePlace[])Enum.GetValues(typeof(ConcretePlace)))
            {
                var rect = PlacesPositions.GetIconPosition(concretePlace);
                var drawable = new BoardPositionDrawable(rect);

                if (clickedAction != null)
                    drawable.Clicked += () => clickedAction?.Invoke(concretePlace);

                list.Add(drawable);
            }
            return list;
        }
    }
}
