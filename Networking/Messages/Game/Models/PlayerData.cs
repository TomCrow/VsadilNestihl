using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Networking.Messages.Game.Models
{
    [Serializable]
    public class PlayerData
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int Color { get; set; }
        public int PlayerPosition { get; set; }
        public int PlaceId { get; set; }
        public int Money { get; set; }

        public PlayerData() { }
    }
}
