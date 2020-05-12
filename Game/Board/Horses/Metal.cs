using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;

namespace VsadilNestihl.Game.Board.Horses
{
    public class Metal : Horse
    {
        public Metal() : base(ConcretePlace.Metal, "Metal", Color.FromArgb(165, 41, 95))
        {
            Price = 4800;
            VisitPrice = 400;
            RaceVisitPrice1 = 2000;
            RaceVisitPrice2 = 6000;
            RaceVisitPrice3 = 15000;
            RaceVisitPrice4 = 18000;
            RaceVisitPriceMain = 22000;
            RacePrice = 3000;
            MainRacePrice = 3000;
        }
    }
}
