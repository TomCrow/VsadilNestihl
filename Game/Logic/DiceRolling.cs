using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Exceptions;

namespace VsadilNestihl.Game.Logic
{
    public class DiceRolling : IDiceRolling
    {
        private readonly GameManager _gameManager;

        public DiceRolling(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void PlayerRolled(Player.Player player, int rolledCount)
        {
            if (_gameManager.CurrentPlayer != player)
                throw new InvalidActionException("Not your turn.");

            if (player.GetRolledThisTurn())
                throw new InvalidActionException("You have no more rolls left.");

            _gameManager.GameUpdater.PlayerRolledDice(player, rolledCount);

            var place = player.Place;
            for (var i = 0; i < rolledCount; i++)
                place = _gameManager.Board.GetNextPlace(place);

            if (rolledCount != 6)
                player.SetRolledThisTurn(true);

            player.SetPlace(place);
        }
    }
}
