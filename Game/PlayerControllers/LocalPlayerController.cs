using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihlNetworking.Messages.Game;

namespace VsadilNestihl.Game.PlayerControllers
{
    public class LocalPlayerController : IPlayerController
    {
        private readonly Player.Player _player;

        public event Action<string> GameActionException;

        public LocalPlayerController(Player.Player player)
        {
            _player = player;
        }

        public Player.Player GetPlayer()
        {
            return _player;
        }

        public void ChatSendMessage(string message)
        {
            try
            {
                _player.SendChatMessage(message);
            }
            catch (Exception exception)
            {
                GameActionException?.Invoke(exception.Message);
            }
        }

        public void RollDice()
        {
            try
            {
                _player.RollDice();
            }
            catch (Exception exception)
            {
                GameActionException?.Invoke(exception.Message);
            }
        }

        public void EndTurn()
        {
            try
            {
                _player.EndTurn();
            }
            catch (Exception exception)
            {
                GameActionException?.Invoke(exception.Message);
            }
        }
    }
}
