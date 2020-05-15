using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Networking.Messages.Game
{
    [Serializable]
    public class PlayerRolledThisTurn : IMessage
    {
        public int PlayerId { get; set; }
        public bool RolledThisTurn { get; set; }

        public PlayerRolledThisTurn() { }
        public PlayerRolledThisTurn(int playerId, bool rolledThisTurn)
        {
            PlayerId = playerId;
            RolledThisTurn = rolledThisTurn;
        }
    }
}
