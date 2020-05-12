using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;

namespace VsadilNestihl.Game.Board.Horses
{
    public class Napoli : Horse
    {
        public Napoli() : base(ConcretePlace.Napoli, "Napoli", Color.FromArgb(94, 52, 124))
        {
            Price = 8000;
            VisitPrice = 1000;
            RaceVisitPrice1 = 4000;
            RaceVisitPrice2 = 12000;
            RaceVisitPrice3 = 28000;
            RaceVisitPrice4 = 34000;
            RaceVisitPriceMain = 40000;
            RacePrice = 4000;
            MainRacePrice = 4000;
        }
    }
}
