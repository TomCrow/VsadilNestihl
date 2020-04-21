using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using VsadilNestihl.Game.Dices;
using VsadilNestihl.Game.Exceptions;
using VsadilNestihl.Game.Logic;

namespace VsadilNestihl.Game
{
    public class GameManager
    {
        private readonly List<Lobby.LobbyPlayer> _lobbyPlayers;

        public Board.IBoard Board { get; private set; }
        public GameSettings GameSettings { get; private set; }
        public IGameUpdater GameUpdater { get; private set; }
        public GameState GameState { get; private set; }
        public List<Player.Player> Players { get; private set; }
        public Player.Player CurrentPlayer { get; set; }

        public IDice DefaultDice { get; set; } = new Dice();

        public IDiceRolling DiceRolling { get; set; }
        public ITurnLogic TurnLogic { get; set; }

        public GameManager(Board.IBoard board, GameSettings gameSettings, IGameUpdater gameUpdater, List<Lobby.LobbyPlayer> lobbyPlayers)
        {
            _lobbyPlayers = lobbyPlayers;

            Board = board;
            GameSettings = gameSettings;
            GameUpdater = gameUpdater;
            GameState = GameState.Lobby;
        }

        public void Start()
        {
            if (GameState != GameState.Lobby)
                throw new InvalidActionException("Game is already started.");

            // All playing players (not spectators)
            var actualLobbyPlayers = _lobbyPlayers.Where(x => x.PlayerPosition != Player.PlayerPosition.Spectator).ToList();

            if (actualLobbyPlayers.Count < 2)
                throw new InvalidActionException("More players are needed.");

            var startPlace = Board.GetStartPlace();

            // Create all players
            Players = new List<Player.Player>();
            foreach (var lobbyPlayer in actualLobbyPlayers)
            {
                var player = new Player.Player(lobbyPlayer, 
                                               DefaultDice, 
                                               GameSettings.StartMoney,
                                               startPlace);
                player.SetGameManager(this);
                lobbyPlayer.PlayerCreated(player);
                Players.Add(player);
            }

            GameState = GameState.ChosingStartingPlayer;
            GameUpdater.GameStarted(Players);
            GameUpdater.ChatServerMessage("Game started.");

            GameState = GameState.Running;
            TurnLogic.BeginFirstRound();
        }

        public void PlayerSendChatMessage(Player.Player player, string message)
        {
            // TODO: player message handler
            GameUpdater.ChatPlayerMessage(player, message);
        }

        public void PlayerRolledDice(Player.Player player, int rolled)
        {
            DiceRolling.PlayerRolled(player, rolled);
        }

        public void PlayerEndTurn(Player.Player player)
        {
            TurnLogic.PlayerEndTurn(player);
        }
    }
}
