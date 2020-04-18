﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Exceptions;
using VsadilNestihlNetworking;
using VsadilNestihlNetworking.Messages;
using VsadilNestihlNetworking.Messages.Game;
using VsadilNestihlNetworking.Messages.GameControlls;

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

            _receiver.MessageDispatcher.Add(typeof(RollDice), OnRollDice);
            _receiver.MessageDispatcher.Add(typeof(EndTurn), OnEndTurn);
        }

        private void OnRollDice(IMessage message, Receiver receiver)
        {
            if (!(message is RollDice rollDice))
                return;

            try
            {
                _player.RollDice();
            }
            catch (Exception exception)
            {
                _receiver.SendMessage(new GameActionException(exception.Message));
            }
        }

        private void OnEndTurn(IMessage message, Receiver receiver)
        {
            if (!(message is EndTurn endTurn))
                return;

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