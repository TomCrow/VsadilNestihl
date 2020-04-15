using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board;

namespace VsadilNestihl.Game.Player
{
    public class PlayerData : IPlayerData
    {
        public int PlayerId { get; private set; }
        public string Name { get; private set; }
        public Color Color { get; private set; }
        public IPlace Place { get; set; }
        public int Money { get; set; }

        public PlayerData(int playerId, string name, Color color)
        {
            PlayerId = playerId;
            Name = name;
            Color = color;
        }

        public static PlayerData FromPlayer(Player player)
        {
            return new PlayerData(player.PlayerId, player.Name, player.Color)
            {
                Place = player.Place,
            };
        }
    }
}
