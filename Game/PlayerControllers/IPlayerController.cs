using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Game.PlayerControllers
{
    public interface IPlayerController
    {
        event Action<string> GameActionException;

        void ChatSendMessage(string message);
        void RollDice();
        void EndTurn();
    }
}
