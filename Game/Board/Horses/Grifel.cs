using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;

namespace VsadilNestihl.Game.Board.Horses
{
    public class Grifel : Horse
    {
        public Grifel() : base(ConcretePlace.Grifel, "Grifel", Color.FromArgb(165, 41, 95))
        {
            Price = 4400;
            VisitPrice = 360;
            RaceVisitPrice1 = 1800;
            RaceVisitPrice2 = 5000;
            RaceVisitPrice3 = 14000;
            RaceVisitPrice4 = 17000;
            RaceVisitPriceMain = 21000;
            RacePrice = 3000;
            MainRacePrice = 3000;
        }
    }
}
