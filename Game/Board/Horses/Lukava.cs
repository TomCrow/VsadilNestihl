using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;

namespace VsadilNestihl.Game.Board.Horses
{
    public class Lukava : Horse
    {
        public Lukava() : base(ConcretePlace.Lukava, "Lukava", Color.FromArgb(38, 93, 26))
        {
            Price = 3600;
            VisitPrice = 280;
            RaceVisitPrice1 = 1400;
            RaceVisitPrice2 = 4000;
            RaceVisitPrice3 = 11000;
            RaceVisitPrice4 = 15000;
            RaceVisitPriceMain = 19000;
            RacePrice = 2000;
            MainRacePrice = 2000;
        }
    }
}
