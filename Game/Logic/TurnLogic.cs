using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Exceptions;

namespace VsadilNestihl.Game.Logic
{
    public class TurnLogic : ITurnLogic
    {
        private readonly GameManager _gameManager;

        public TurnLogic(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void BeginFirstRound()
        {
            SetCurrentPlayer(_gameManager.Players.First());
        }

        public void PlayerEndTurn(Player.Player player)
        {
            if (_gameManager.CurrentPlayer != player)
                throw new InvalidActionException("Not your turn.");

            if (!_gameManager.CurrentPlayer.GetRolledThisTurn())
                throw new InvalidActionException("You have to roll first.");

            NextPlayer();
        }

        private void NextPlayer()
        {
            var foundCurrPlayer = false;
            Player.Player foundNextPlayer = null;
            foreach (var player in _gameManager.Players)
            {
                if (foundCurrPlayer)
                    foundNextPlayer = player;

                if (_gameManager.CurrentPlayer == player)
                    foundCurrPlayer = true;
            }

            if (foundNextPlayer == null)
                foundNextPlayer = _gameManager.Players.First();

            SetCurrentPlayer(foundNextPlayer);
        }

        private void SetCurrentPlayer(Player.Player player)
        {
            _gameManager.CurrentPlayer = player;
            _gameManager.CurrentPlayer.SetRolledThisTurn(false);
            _gameManager.GameUpdater.NextRound(_gameManager.CurrentPlayer);
        }
    }
}
