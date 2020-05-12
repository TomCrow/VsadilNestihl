using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Game.Board.DostihyASazky
{
    public abstract class Horse : IHorse
    {
        private readonly ConcretePlace _concretePlace;
        private readonly string _name;
        private readonly Color _color;
        protected int? OwnerId;
        protected int Price;
        protected int VisitPrice;
        protected int RaceVisitPrice1;
        protected int RaceVisitPrice2;
        protected int RaceVisitPrice3;
        protected int RaceVisitPrice4;
        protected int RaceVisitPriceMain;
        protected int RacePrice;
        protected int MainRacePrice;

        protected Horse(ConcretePlace concretePlace, string name, Color color)
        {
            _concretePlace = concretePlace;
            _name = name;
            _color = color;
        }

        public int GetPlaceId()
        {
            return (int)_concretePlace;
        }

        public string GetName()
        {
            return _name;
        }

        public Color GetPlaceColor()
        {
            return _color;
        }

        public int? GetOwnerId()
        {
            return OwnerId;
        }

        public int GetPrice()
        {
            return Price;
        }

        public int GetVisitPrice()
        {
            return VisitPrice;
        }

        public int GetRaceVisitPrice(int raceCount)
        {
            switch (raceCount)
            {
                case 0: return VisitPrice;
                case 1: return RaceVisitPrice1;
                case 2: return RaceVisitPrice2;
                case 3: return RaceVisitPrice3;
                case 4: return RaceVisitPrice4;
                case 5: return RaceVisitPriceMain;
                default: throw new ArgumentOutOfRangeException(nameof(raceCount));
            }
        }

        public int GetRacePrice()
        {
            return RacePrice;
        }

        public int GetMainRacePrice()
        {
            return MainRacePrice;
        }
    }
}
