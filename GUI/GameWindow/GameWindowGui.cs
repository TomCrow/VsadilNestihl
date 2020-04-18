using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VsadilNestihl.Game;
using VsadilNestihl.Game.Board.DostihyASazky;
using VsadilNestihl.Game.Player;
using VsadilNestihl.Game.PlayerControllers;
using VsadilNestihl.GUI.GameCanvas.Drawables;
using VsadilNestihl.GUI.GameCanvas.Helpers;

namespace VsadilNestihl.GUI.GameWindow
{
    public class GameWindowGui : IGameView
    {
        private readonly IGameWindowView _view;
        private readonly Dictionary<int, PlayerDrawable> _playerDrawables = new Dictionary<int, PlayerDrawable>();
        private readonly Dictionary<int, ConcretePlace> _playerConcretePlaces = new Dictionary<int, ConcretePlace>();

        private readonly DebugInfoDrawable _debugInfoDrawable;

        public IGameData GameData { get; private set; }
        public IPlayerController PlayerController { get; private set; }

        public event Action Loaded;
        
        public GameWindowGui(IGameWindowView gameWindowView)
        {
            _view = gameWindowView;

            var boardDrawable = new BoardDrawable(new System.Drawing.Point(0, 0));
            _view.AddDrawable(boardDrawable);

            var diceDrawable = new DiceDrawable(new System.Drawing.Point(724 / 2, 724 / 2));
            diceDrawable.Clicked += DiceDrawableOnClicked;
            _view.AddDrawable(diceDrawable);

            var boardPositionsDrawables = CommonDrawables.GetBoardPositions(BoardPositionClicked);
            _view.AddDrawables(boardPositionsDrawables);

            _debugInfoDrawable = new DebugInfoDrawable(new Point(145, 145));
            _view.AddDrawable(_debugInfoDrawable);
        }

        public void TEST_EndTurn()
        {
            PlayerController.EndTurn();
        }

        public void SetGameData(IGameData gameData)
        {
            GameData = gameData;
        }

        public void SetPlayerController(IPlayerController playerController)
        {
            PlayerController = playerController;
        }

        public void GameWindowLoaded()
        {
            Loaded?.Invoke();
        }

        public void ReloadAllPlayers()
        {
            _playerDrawables.Clear();

            foreach (var playerDataKeyVal in GameData.GetPlayers())
            {
                var playerId = playerDataKeyVal.Key;
                var playerData = playerDataKeyVal.Value;
                var playerDrawable = new PlayerDrawable(playerData.Color);
                _playerDrawables.Add(playerId, playerDrawable);

                var concretePlace = (ConcretePlace)playerData.Place.GetPlaceId();
                _playerConcretePlaces[playerId] = concretePlace;
            }

            var distinctConcretePlaces = _playerConcretePlaces.Values.Distinct().ToList();
            foreach (var concretePlace in distinctConcretePlaces)
            {
                var playerIds = _playerConcretePlaces.Where(x => x.Value == concretePlace).Select(x => x.Key).ToList();
                var playerDrawables = _playerDrawables.Where(x => playerIds.Contains(x.Key)).Select(x => x.Value).ToList();

                var leftCornerPoint = PlacesPositions.GetByPlaceAndPosition(concretePlace, 0);
                PlayerPositionSetterHelper.SetPlayersPositions(playerDrawables, leftCornerPoint);
            }

            if (GameData.GetPlayerById(GameData.GetCurrentPlayerId()) != null)
                _debugInfoDrawable.NaTahu = GameData.GetPlayerById(GameData.GetCurrentPlayerId()).Name;
            
            _view.AddDrawables(_playerDrawables.Values);
        }

        public void ShowGameActionException(string message)
        {
            _view.ShowGameActionException(message);
        }

        public void UpdatePlayerPlace(int playerId)
        {
            var player = GameData.GetPlayerById(playerId);
            var concretePlace = (ConcretePlace) player.Place.GetPlaceId();
            _playerConcretePlaces[playerId] = concretePlace;

            var playerIds = _playerConcretePlaces.Where(x => x.Value == concretePlace).Select(x => x.Key).ToList();
            var playerDrawables = _playerDrawables.Where(x => playerIds.Contains(x.Key)).Select(x => x.Value).ToList();
            var leftCornerPoint = PlacesPositions.GetByPlaceAndPosition(concretePlace, 0);
            PlayerPositionSetterHelper.SetPlayersPositions(playerDrawables, leftCornerPoint);
        }

        public void PlayerRolledDice(int playerId, int rolledCount)
        {
            _debugInfoDrawable.Hodil = rolledCount.ToString();
            _view.RefreshCanvas();
        }

        public void NextRound()
        {
            _debugInfoDrawable.NaTahu = GameData.GetPlayerById(GameData.GetCurrentPlayerId()).Name;
            _debugInfoDrawable.Hodil = "";
            _view.RefreshCanvas();
        }

        private void DiceDrawableOnClicked()
        {
            PlayerController.RollDice();
        }

        private void BoardPositionClicked(ConcretePlace concretePlace, int positionId)
        {
            Console.WriteLine($"Place clicked: {concretePlace} position: {positionId}");
        }
    }
}
