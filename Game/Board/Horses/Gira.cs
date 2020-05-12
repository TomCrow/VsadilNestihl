using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;

namespace VsadilNestihl.Game.Board.Horses
{
    public class Gira : Horse
    {
        public Gira() : base(ConcretePlace.Gira, "Gira", Color.DarkGreen)
        {
            Price = 6400;
            VisitPrice = 560;
            RaceVisitPrice1 = 3000;
            RaceVisitPrice2 = 9000;
            RaceVisitPrice3 = 20000;
            RaceVisitPrice4 = 24000;
            RaceVisitPriceMain = 28000;
            RacePrice = 4000;
            MainRacePrice = 4000;
        }
    }
}
