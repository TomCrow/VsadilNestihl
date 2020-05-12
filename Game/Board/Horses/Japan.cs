using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;

namespace VsadilNestihl.Game.Board.Horses
{
    public class Japan : Horse
    {
        public Japan() : base(ConcretePlace.Japan, "Japan", Color.FromArgb(17, 99, 185))
        {
            Price = 3200;
            VisitPrice = 240;
            RaceVisitPrice1 = 1200;
            RaceVisitPrice2 = 3600;
            RaceVisitPrice3 = 10000;
            RaceVisitPrice4 = 14000;
            RaceVisitPriceMain = 18000;
            RacePrice = 2000;
            MainRacePrice = 2000;
        }
    }
}
