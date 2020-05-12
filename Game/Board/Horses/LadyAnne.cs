using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;

namespace VsadilNestihl.Game.Board.Horses
{
    public class LadyAnne : Horse
    {
        public LadyAnne() : base(ConcretePlace.LadyAnne, "LadyAnne", Color.FromArgb(78, 47, 45))
        {
            Price = 2000;
            VisitPrice = 120;
            RaceVisitPrice1 = 600;
            RaceVisitPrice2 = 1800;
            RaceVisitPrice3 = 5400;
            RaceVisitPrice4 = 8000;
            RaceVisitPriceMain = 11000;
            RacePrice = 1000;
            MainRacePrice = 1000;
        }
    }
}
