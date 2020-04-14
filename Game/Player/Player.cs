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
        public IPosition Position { get; set; }

        public Dices.IDice Dice { get; set; } = new Dices.Dice();

        public Player(string name, Color color)
        {
            Name = name;
            Color = color;
        }

        public void SetGameManager(GameManager gameManager, int playerId)
        {
            PlayerId = playerId;

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

        public void SetPosition(IPosition position)
        {
            Position = position;
            _gameUpdater.PlayerSetPosition(this, position);
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
