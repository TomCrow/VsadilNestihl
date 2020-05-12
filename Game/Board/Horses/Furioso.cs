using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;

namespace VsadilNestihl.Game.Board.Horses
{
    public class Furioso : Horse
    {
        public Furioso() : base(ConcretePlace.Furioso, "Furioso", Color.FromArgb(200, 131, 62))
        {
            Price = 5200;
            VisitPrice = 440;
            RaceVisitPrice1 = 2200;
            RaceVisitPrice2 = 6600;
            RaceVisitPrice3 = 16000;
            RaceVisitPrice4 = 19500;
            RaceVisitPriceMain = 23000;
            RacePrice = 3000;
            MainRacePrice = 3000;
        }
    }
}
