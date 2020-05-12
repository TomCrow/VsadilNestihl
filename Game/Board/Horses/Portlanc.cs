using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;

namespace VsadilNestihl.Game.Board.Horses
{
    public class Portlanc : Horse
    {
        public Portlanc() : base(ConcretePlace.Portlanc, "Portlanc", Color.FromArgb(17, 99, 185))
        {
            Price = 2800;
            VisitPrice = 200;
            RaceVisitPrice1 = 1000;
            RaceVisitPrice2 = 3000;
            RaceVisitPrice3 = 9000;
            RaceVisitPrice4 = 12500;
            RaceVisitPriceMain = 15000;
            RacePrice = 2000;
            MainRacePrice = 2000;
        }
    }
}
