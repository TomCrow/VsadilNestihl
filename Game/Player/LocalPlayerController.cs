using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Game.Player
{
    class LocalPlayerController : IPlayerController
    {
        private readonly Player _player;

        public LocalPlayerController(Player player)
        {
            _player = player;
        }

        public Player GetPlayer()
        {
            return _player;
        }

        public void RollDice()
        {
            _player.RollDice();
        }

        public void EndTurn()
        {
            _player.EndTurn();
        }
    }
}
