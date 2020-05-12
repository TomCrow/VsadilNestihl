using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;

namespace VsadilNestihl.Game.Board.Horses
{
    public class Melak : Horse
    {
        public Melak() : base(ConcretePlace.Melak, "Melak", Color.FromArgb(38, 93, 26))
        {
            Price = 4000;
            VisitPrice = 320;
            RaceVisitPrice1 = 1600;
            RaceVisitPrice2 = 4400;
            RaceVisitPrice3 = 12000;
            RaceVisitPrice4 = 16000;
            RaceVisitPriceMain = 20000;
            RacePrice = 2000;
            MainRacePrice = 2000;
        }
    }
}
