using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board;
using VsadilNestihl.Networking;
using VsadilNestihl.Networking.Messages.Game;
using VsadilNestihl.Networking.Messages.Game.Models;

namespace VsadilNestihl.Game
{
    public class RemoteGameUpdater : IGameUpdater
    {
        private readonly Receiver _receiver;

        public RemoteGameUpdater(Receiver receiver)
        {
            _receiver = receiver;
        }

        public void GameStarted(List<Player.Player> players)
        {
            var playerDatas = new List<PlayerData>();
            foreach (var player in players)
            {
                playerDatas.Add(new PlayerData
                {
                    PlayerId = player.PlayerId,
                    Name = player.Name,
                    Color = player.Color.ToArgb(),
                    PlayerPosition = (int)player.PlayerPosition,
                    PlaceId = player.Place.GetPlaceId(),
                    Money = player.GetMoney()
                });
            }

            var message = new GameStarted(playerDatas);
            _receiver.SendMessage(message);
        }

        public void ChatServerMessage(string message)
        {
            _receiver.SendMessage(new VsadilNestihl.Networking.Messages.Chat.ChatServerMessage(message));
        }

        public void ChatPlayerMessage(Player.Player player, string message)
        {
            _receiver.SendMessage(new VsadilNestihl.Networking.Messages.Chat.ChatPlayerMessage(player.PlayerId, message));
        }

        public void PlayerSetMoney(Player.Player player, int money)
        {
            _receiver.SendMessage(new PlayerSetMoney(player.PlayerId, money));
        }

        public void PlayerRolledDice(Player.Player player, int rolledCount)
        {
            _receiver.SendMessage(new PlayerRolledDice(player.PlayerId, rolledCount));
        }

        public void PlayerRolledThisTurn(Player.Player player, bool rolledThisTurn)
        {
            _receiver.SendMessage(new PlayerRolledThisTurn(player.PlayerId, rolledThisTurn));
        }

        public void PlayerPassedPlace(Player.Player player, IPlace place)
        {
            _receiver.SendMessage(new PlayerPassedPlace(player.PlayerId, place.GetPlaceId()));
        }

        public void PlayerSetPlace(Player.Player player, IPlace place)
        {
            _receiver.SendMessage(new PlayerSetPlace(player.PlayerId, place.GetPlaceId()));
        }

        public void NextRound(Player.Player currentPlayer)
        {
            _receiver.SendMessage(new NextRound(currentPlayer.PlayerId));
        }
    }
}
