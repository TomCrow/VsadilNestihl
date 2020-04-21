using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Game.Logic
{
    public interface ITurnLogic
    {
        void BeginFirstRound();
        void PlayerEndTurn(Player.Player player);
    }
}
