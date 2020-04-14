using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board;
using VsadilNestihl.Game.Player;

namespace VsadilNestihl.Game
{
    public class LocalGameUpdater : IGameUpdater
    {
        public Dictionary<int, IPlayerData> Players { get; private set; } = new Dictionary<int, IPlayerData>();
        public Dictionary<int, IPlayerController> PlayerControllers { get; private set; } = new Dictionary<int, IPlayerController>();
        public int CurrentPlayerId { get; private set; }
        public bool CurrentPlayerRolledThisTurn { get; private set; }

        public void GameStarted(List<Player.Player> players)
        {
            foreach (var player in players)
            {
                var playerData = PlayerData.FromPlayer(player);
                Players.Add(playerData.PlayerId, playerData);

                var localPlayerController = new LocalPlayerController(player);
                PlayerControllers.Add(playerData.PlayerId, localPlayerController);
            }
        }

        public void PlayerSetMoney(Player.Player player, int money)
        {
            Players[player.PlayerId].Money = money;
        }

        public void PlayerRolledDice(Player.Player player, int rolledCount)
        {
            // TODO:
        }

        public void PlayerRolledThisTurn(Player.Player player, bool rolledThisTurn)
        {
            if (player.PlayerId == CurrentPlayerId)
                CurrentPlayerRolledThisTurn = rolledThisTurn;
        }

        public void PlayerSetPlace(Player.Player player, IPlace place)
        {
            Players[player.PlayerId].Place = place;
        }

        public void PlayerSetPosition(Player.Player player, IPosition position)
        {
            Players[player.PlayerId].Position = position;
        }

        public void NextRound(Player.Player currentPlayer)
        {
            CurrentPlayerId = currentPlayer.PlayerId;
        }
    }
}
