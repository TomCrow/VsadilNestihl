﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Player;

namespace VsadilNestihl.Game.Lobby
{
    public class LobbyPlayer
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public Color Color { get; set; }
        public PlayerPosition PlayerPosition { get; set; }

        public PlayerHandler PlayerHandler { get; set; }

        public LobbyPlayer(int playerId, string playerName, Color color, PlayerPosition playerPosition)
        {
            PlayerId = playerId;
            PlayerName = playerName;
            Color = color;
            PlayerPosition = playerPosition;
        }

        public void PlayerCreated(VsadilNestihl.Game.Player.Player player)
        {
            // Attach inner player controller for player
            PlayerHandler?.CreateInnerRemotePlayerController(player);
        }
    }
}
