using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;

namespace VsadilNestihl.Game.Board.Horses
{
    public class Dahoman : Horse
    {
        public Dahoman() : base(ConcretePlace.Dahoman, "Dahoman", Color.DarkGreen)
        {
            Price = 6000;
            VisitPrice = 500;
            RaceVisitPrice1 = 2600;
            RaceVisitPrice2 = 7800;
            RaceVisitPrice3 = 18000;
            RaceVisitPrice4 = 22000;
            RaceVisitPriceMain = 25500;
            RacePrice = 4000;
            MainRacePrice = 4000;
        }
    }
}
