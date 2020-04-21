using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Game.Dices
{
    class Dice : IDice
    {
        private readonly Random _random;

        public Dice()
        {
            _random = new Random();
        }

        public int Roll()
        {
            var roll = _random.Next(1, 7);
            if (roll == 7)
            {
                int a = 0;
            }
            return roll;
        }
    }
}
