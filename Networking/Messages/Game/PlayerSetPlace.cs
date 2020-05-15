using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Networking.Messages.Game
{
    [Serializable]
    public class PlayerSetPlace : IMessage
    {
        public int PlayerId { get; set; }
        public int PlaceId { get; set; }

        public PlayerSetPlace() { }
        public PlayerSetPlace(int playerId, int placeId)
        {
            PlayerId = playerId;
            PlaceId = placeId;
        }
    }
}
