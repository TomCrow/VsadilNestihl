using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Networking.Messages.Game
{
    [Serializable]
    public class PlayerSetMoney : IMessage
    {
        public int PlayerId { get; set; }
        public int Money { get; set; }

        public PlayerSetMoney() { }
        public PlayerSetMoney(int playerId, int money)
        {
            PlayerId = playerId;
            Money = money;
        }
    }
}
