using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board;

namespace VsadilNestihl.Game
{
    public class MultipleGameUpdater : IGameUpdater
    {
        private readonly List<IGameUpdater> _gameUpdaters;

        public MultipleGameUpdater(List<IGameUpdater> gameUpdaters)
        {
            _gameUpdaters = gameUpdaters;
        }

        public void GameStarted(List<Player.Player> players)
        {
            foreach (var gameUpdater in _gameUpdaters)
            {
                gameUpdater.GameStarted(players);
            }
        }

        public void PlayerSetMoney(Player.Player player, int money)
        {
            foreach (var gameUpdater in _gameUpdaters)
            {
                gameUpdater.PlayerSetMoney(player, money);
            }
        }

        public void PlayerRolledDice(Player.Player player, int rolledCount)
        {
            foreach (var gameUpdater in _gameUpdaters)
            {
                gameUpdater.PlayerRolledDice(player, rolledCount);
            }
        }

        public void PlayerRolledThisTurn(Player.Player player, bool rolledThisTurn)
        {
            foreach (var gameUpdater in _gameUpdaters)
            {
                gameUpdater.PlayerRolledThisTurn(player, rolledThisTurn);
            }
        }

        public void PlayerSetPlace(Player.Player player, IPlace place)
        {
            foreach (var gameUpdater in _gameUpdaters)
            {
                gameUpdater.PlayerSetPlace(player, place);
            }
        }

        public void NextRound(Player.Player currentPlayer)
        {
            foreach (var gameUpdater in _gameUpdaters)
            {
                gameUpdater.NextRound(currentPlayer);
            }
        }
    }
}
