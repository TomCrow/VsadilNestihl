using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board;
using VsadilNestihl.Game.Player;

namespace VsadilNestihl.Game
{
    public abstract class LocalGameUpdater : IGameUpdater
    {
        protected Dictionary<int, IPlayerData> Players { get; private set; } = new Dictionary<int, IPlayerData>();
        protected Dictionary<int, IPlayerController> PlayerControllers { get; private set; } = new Dictionary<int, IPlayerController>();
        protected int CurrentPlayerId { get; private set; }
        protected bool CurrentPlayerRolledThisTurn { get; private set; }

        public virtual void GameStarted(List<Player.Player> players)
        {
            foreach (var player in players)
            {
                var playerData = PlayerData.FromPlayer(player);
                Players.Add(playerData.PlayerId, playerData);

                var localPlayerController = new LocalPlayerController(player);
                PlayerControllers.Add(playerData.PlayerId, localPlayerController);
            }
        }

        public virtual void PlayerSetMoney(Player.Player player, int money)
        {
            Players[player.PlayerId].Money = money;
        }

        public virtual void PlayerRolledDice(Player.Player player, int rolledCount)
        {
            // TODO:
        }

        public virtual void PlayerRolledThisTurn(Player.Player player, bool rolledThisTurn)
        {
            if (player.PlayerId == CurrentPlayerId)
                CurrentPlayerRolledThisTurn = rolledThisTurn;
        }

        public void PlayerSetPlacePosition(Player.Player player, IPlace place, IPosition position)
        {
            Players[player.PlayerId].Place = place;
            Players[player.PlayerId].Position = position;
        }

        public virtual void NextRound(Player.Player currentPlayer)
        {
            CurrentPlayerId = currentPlayer.PlayerId;
        }
    }
}
