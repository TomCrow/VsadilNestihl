using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Network;
using VsadilNestihlNetworking.Messages.GameControlls;

namespace VsadilNestihl.Game.PlayerControllers
{
    public class RemotePlayerController : IPlayerController
    {
        private readonly GameClient _gameClient;

        public RemotePlayerController(GameClient gameClient)
        {
            _gameClient = gameClient;
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
