using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board;

namespace VsadilNestihl.Game.Player
{
    public class Player
    {
        private GameManager _gameManager;
        private IGameUpdater _gameUpdater;
        private int _money;
        private bool _rolledThisTurn;

        public int PlayerId { get; private set; }
        public string Name { get; private set; }
        public Color Color { get; private set; }
        public IPlace Place { get; set; }

        public Dices.IDice Dice { get; set; } = new Dices.Dice();

        public Player(Lobby.LobbyPlayer lobbyPlayer, Dices.IDice dice, int startingMoney, IPlace startingPlace)
        {
            PlayerId = lobbyPlayer.PlayerId;
            Name = lobbyPlayer.PlayerName;
            Color = lobbyPlayer.Color;
            Dice = dice;
            _money = startingMoney;
            Place = startingPlace;
        }

        public void SetGameManager(GameManager gameManager)
        {
            _gameManager = gameManager;
            _gameUpdater = gameManager.GameUpdater;
        }

        public void RollDice()
        {
            var rolledCount = Dice.Roll();
            _gameManager.PlayerRolledDice(this, rolledCount);
        }

        public void SetPlace(IPlace place)
        {
            Place = place;
            _gameUpdater.PlayerSetPlace(this, place);
        }

        public void EndTurn()
        {
            _gameManager.PlayerEndTurn(this);
        }

        public int GetMoney()
        {
            return _money;
        }

        public void SetMoney(int money)
        {
            _money = money;
            _gameUpdater.PlayerSetMoney(this, money);
        }

        public bool GetRolledThisTurn()
        {
            return _rolledThisTurn;
        }

        public void SetRolledThisTurn(bool rolledThisTurn)
        {
            _rolledThisTurn = rolledThisTurn;
            _gameUpdater.PlayerRolledThisTurn(this, rolledThisTurn);
        }
    }
}
