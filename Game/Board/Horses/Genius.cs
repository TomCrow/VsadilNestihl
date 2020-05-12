using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;

namespace VsadilNestihl.Game.Board.Horses
{
    public class Genius : Horse
    {
        public Genius() : base(ConcretePlace.Genius, "Genius", Color.FromArgb(200, 131, 62))
        {
            Price = 5600;
            VisitPrice = 580;
            RaceVisitPrice1 = 2400;
            RaceVisitPrice2 = 7200;
            RaceVisitPrice3 = 17000;
            RaceVisitPrice4 = 20500;
            RaceVisitPriceMain = 24000;
            RacePrice = 3000;
            MainRacePrice = 3000;
        }
    }
}
