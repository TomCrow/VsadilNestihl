using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;

namespace VsadilNestihl.Game.Board.Horses
{
    public class Gavora : Horse
    {
        public Gavora() : base(ConcretePlace.Gavora, "Gavora", Color.FromArgb(186, 73, 75))
        {
            Price = 1200;
            VisitPrice = 40;
            RaceVisitPrice1 = 200;
            RaceVisitPrice2 = 600;
            RaceVisitPrice3 = 1800;
            RaceVisitPrice4 = 3200;
            RaceVisitPriceMain = 5000;
            RacePrice = 1000;
            MainRacePrice = 1000;
        }
    }
}
