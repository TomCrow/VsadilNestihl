using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using VsadilNestihl.Game.Dices;
using VsadilNestihl.Game.Exceptions;

namespace VsadilNestihl.Game
{
    public class GameManager
    {
        public Board.IBoard Board { get; private set; }
        public GameSettings GameSettings { get; private set; }
        public IGameUpdater GameUpdater { get; private set; }
        public GameState GameState { get; private set; }
        public List<Player.Player> Players { get; private set; }
        public Player.Player CurrentPlayer { get; private set; }

        public IDice DefaultDice { get; set; } = new Dice();

        public GameManager(Board.IBoard board, GameSettings gameSettings, IGameUpdater gameUpdater, List<Player.Player> players)
        {
            Board = board;
            GameSettings = gameSettings;
            GameUpdater = gameUpdater;
            Players = players;
            GameState = GameState.Lobby;
        }

        public void Start()
        {
            if (GameState != GameState.Lobby)
                throw new InvalidActionException("Game is already started.");

            if (Players.Count < 2)
                throw new InvalidActionException("More players are needed.");

            var startPlace = Board.GetStartPlace();
            var startPosition = Board.GetStartPosition();

            // Set start money to all players and set position to start
            var nextPlayerId = 1;
            foreach (var player in Players)
            {
                player.SetGameManager(this, nextPlayerId);
                nextPlayerId++;

                player.Dice = DefaultDice;
                player.SetMoney(GameSettings.StartMoney);
                player.SetPlace(startPlace);
                player.SetPosition(startPosition);
            }

            GameState = GameState.ChosingStartingPlayer;
            GameUpdater.GameStarted(Players);

            GameState = GameState.Running;
            SetCurrentPlayer(Players.First());
        }

        public void PlayerRolledDice(Player.Player player, int rolled)
        {
            if (CurrentPlayer != player)
                throw new InvalidActionException("Not your turn.");
                
            if (player.GetRolledThisTurn())
                throw new InvalidActionException("You have no more rolls left.");

            GameUpdater.PlayerRolledDice(player, rolled);

            var place = player.Place;
            for (var i = 0; i < rolled; i++)
                place = Board.GetNextPlace(place);

            player.SetRolledThisTurn(true);
            player.SetPlace(place);
            player.SetPosition(place.GetPosition());
        }

        public void PlayerEndTurn(Player.Player player)
        {
            if (CurrentPlayer != player)
                throw new InvalidActionException("Not your turn.");

            if (!CurrentPlayer.GetRolledThisTurn())
                throw new InvalidActionException("You have to roll first.");

            NextPlayer();
        }

        private void NextPlayer()
        {
            var foundCurrPlayer = false;
            Player.Player foundNextPlayer = null;
            foreach (var player in Players)
            {
                if (foundCurrPlayer)
                    foundNextPlayer = player;

                if (CurrentPlayer == player)
                    foundCurrPlayer = true;
            }

            if (foundNextPlayer == null)
                foundNextPlayer = Players.First();

            SetCurrentPlayer(foundNextPlayer);
        }

        private void SetCurrentPlayer(Player.Player player)
        {
            CurrentPlayer = player;
            CurrentPlayer.SetRolledThisTurn(false);
            GameUpdater.NextRound(CurrentPlayer);
        }
    }
}
