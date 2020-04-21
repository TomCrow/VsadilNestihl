using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Game.Logic
{
    public interface IDiceRolling
    {
        void PlayerRolled(Player.Player player, int rolledCount);
    }
}
