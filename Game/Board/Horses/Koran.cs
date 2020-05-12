using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;

namespace VsadilNestihl.Game.Board.Horses
{
    public class Koran : Horse
    {
        public Koran() : base(ConcretePlace.Koran, "Koran", Color.FromArgb(78, 47, 45))
        {
            Price = 2400;
            VisitPrice = 160;
            RaceVisitPrice1 = 800;
            RaceVisitPrice2 = 2000;
            RaceVisitPrice3 = 6000;
            RaceVisitPrice4 = 9000;
            RaceVisitPriceMain = 12000;
            RacePrice = 1000;
            MainRacePrice = 1000;
        }
    }
}
