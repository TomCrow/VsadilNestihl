using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Game.Board.DostihyASazky
{
    class Place : IPlace, IPosition
    {
        public ConcretePlace ConcretePlace { get; private set; }
        public string Name { get; private set; }

        public Place(ConcretePlace concretePlace, string name)
        {
            ConcretePlace = concretePlace;
            Name = name;
        }

        public int GetPlaceId()
        {
            return (int) ConcretePlace;
        }

        public string GetName()
        {
            return Name;
        }

        public IPosition GetDefaultPosition()
        {
            return this;
        }

        public IPlace GetPlace()
        {
            return this;
        }

        public int GetPositionId()
        {
            return 0;
        }
    }
}
