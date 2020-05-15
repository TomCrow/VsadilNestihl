using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Networking.Messages.Game
{
    [Serializable]
    public class NextRound : IMessage
    {
        public int PlayerId { get; set; }

        public NextRound() { }
        public NextRound(int playerId)
        {
            PlayerId = playerId;
        }
    }
}
