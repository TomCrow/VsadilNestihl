using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Network;
using VsadilNestihl.Networking.Messages.GameControlls;

namespace VsadilNestihl.Game.PlayerControllers
{
    public class RemotePlayerController : IPlayerController
    {
        private readonly GameClient _gameClient;

        public event Action<string> GameActionException;

        public RemotePlayerController(GameClient gameClient)
        {
            _gameClient = gameClient;
            gameClient.GameActionException += exception => RaiseGameActionException(exception.Message);
        }

        public void RaiseGameActionException(string message)
        {
            GameActionException?.Invoke(message);
        }

        public void ChatSendMessage(string message)
        {
            _gameClient.SendMessage(new VsadilNestihl.Networking.Messages.Chat.ChatPlayerMessageRequest(message));
        }

        public void RollDice()
        {
            _gameClient.SendMessage(new RollDice());
        }

        public void EndTurn()
        {
            _gameClient.SendMessage(new EndTurn());
        }
    }
}
