using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Game.Board.DostihyASazky
{
    public interface IHorse : IPlace, IProperty
    {
        int GetRaceVisitPrice(int raceCount);
        int GetRacePrice();
        int GetMainRacePrice();
    }
}
