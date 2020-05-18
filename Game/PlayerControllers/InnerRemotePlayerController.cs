using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Exceptions;
using VsadilNestihl.Networking;
using VsadilNestihl.Networking.Messages;
using VsadilNestihl.Networking.Messages.Game;
using VsadilNestihl.Networking.Messages.GameControlls;

namespace VsadilNestihl.Game.PlayerControllers
{
    public class InnerRemotePlayerController
    {
        private readonly Receiver _receiver;
        private readonly Player.Player _player;

        public InnerRemotePlayerController(Receiver receiver, Player.Player player)
        {
            _receiver = receiver;
            _player = player;

            _receiver.SubscribeForMessage<Networking.Messages.Chat.ChatPlayerMessageRequest>(OnChatPlayerMessageRequest);
            _receiver.SubscribeForMessage<RollDice>(OnRollDice);
            _receiver.SubscribeForMessage<EndTurn>(OnEndTurn);
        }

        private void OnChatPlayerMessageRequest(Networking.Messages.Chat.ChatPlayerMessageRequest chatPlayerMessageRequest, Receiver receiver)
        {
            try
            {
                _player.SendChatMessage(chatPlayerMessageRequest.Message);
            }
            catch (Exception exception)
            {
                _receiver.SendMessage(new GameActionException(exception.Message));
            }
        }

        private void OnRollDice(RollDice rollDice, Receiver receiver)
        {
            try
            {
                _player.RollDice();
            }
            catch (Exception exception)
            {
                _receiver.SendMessage(new GameActionException(exception.Message));
            }
        }

        private void OnEndTurn(EndTurn endTurn, Receiver receiver)
        {
            try
            {
                _player.EndTurn();
            }
            catch (Exception exception)
            {
                _receiver.SendMessage(new GameActionException(exception.Message));
            }
        }
    }
}
