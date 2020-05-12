using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Game.Board.DostihyASazky
{
    public class Place : IPlace
    {
        public ConcretePlace ConcretePlace { get; private set; }
        public string Name { get; private set; }
        public Color Color { get; private set; }

        public Place(ConcretePlace concretePlace, string name, Color color)
        {
            ConcretePlace = concretePlace;
            Name = name;
            Color = color;
        }

        public int GetPlaceId()
        {
            return (int) ConcretePlace;
        }

        public string GetName()
        {
            return Name;
        }

        public Color GetPlaceColor()
        {
            return Color;
        }
    }
}
