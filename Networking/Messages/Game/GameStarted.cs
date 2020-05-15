using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Networking.Messages.Game.Models;

namespace VsadilNestihl.Networking.Messages.Game
{
    [Serializable]
    public class GameStarted : IMessage
    {
        public List<PlayerData> Players { get; set; }

        public GameStarted() { }
        public GameStarted(List<PlayerData> players)
        {
            Players = players;
        }
    }
}
