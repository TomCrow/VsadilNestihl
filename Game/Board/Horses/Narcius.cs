using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;

namespace VsadilNestihl.Game.Board.Horses
{
    public class Narcius : Horse
    {
        public Narcius() : base(ConcretePlace.Narcius, "Narcius", Color.FromArgb(94, 52, 124))
        {
            Price = 7000;
            VisitPrice = 700;
            RaceVisitPrice1 = 3500;
            RaceVisitPrice2 = 10000;
            RaceVisitPrice3 = 22000;
            RaceVisitPrice4 = 26000;
            RaceVisitPriceMain = 30000;
            RacePrice = 4000;
            MainRacePrice = 4000;
        }
    }
}
