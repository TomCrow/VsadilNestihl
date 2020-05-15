using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Networking.Messages.Game
{
    [Serializable]
    public class PlayerRolledDice : IMessage
    {
        public int PlayerId { get; set; }
        public int RolledCount { get; set; }

        public PlayerRolledDice() { }
        public PlayerRolledDice(int playerId, int rolledCount)
        {
            PlayerId = playerId;
            RolledCount = rolledCount;
        }
    }
}
