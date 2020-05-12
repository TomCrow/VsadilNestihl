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
using VsadilNestihl.GUI.GameCanvas.Animators;
using VsadilNestihl.GUI.GameCanvas.Drawables;
using VsadilNestihl.GUI.GameCanvas.Helpers;

namespace VsadilNestihl.GUI.GameWindow
{
    public class GameWindowGui : IGameView
    {
        private readonly IGameWindowView _view;
        private readonly Dictionary<int, PlayerDrawable> _playerDrawables = new Dictionary<int, PlayerDrawable>();
        private readonly Dictionary<int, ConcretePlace> _playerConcretePlaces = new Dictionary<int, ConcretePlace>();
        private readonly Dictionary<PlayerDrawable, PlayerAnimator> _playerAnimators = new Dictionary<PlayerDrawable, PlayerAnimator>();

        private readonly BoardDrawable _boardDrawable;
        private DebugInfoDrawable _debugInfoDrawable = new DebugInfoDrawable(new Point(), null);

        public IGameData GameData { get; private set; }
        public IPlayerController PlayerController { get; private set; }

        public event Action Loaded;
        
        public GameWindowGui(IGameWindowView gameWindowView)
        {
            _view = gameWindowView;

            _boardDrawable = new BoardDrawable(new Point(0, 0));
            _view.AddDrawable(_boardDrawable);

            var diceDrawable = new DiceDrawable(new Point(724 / 2, 724 / 2));
            diceDrawable.Clicked += DiceDrawableOnClicked;
            _view.AddDrawable(diceDrawable);

            /*var boardPositionsDrawables = CommonDrawables.GetBoardPlacePositions(BoardPositionClicked);
            _view.AddDrawables(boardPositionsDrawables);*/

            var boardIconsDrawables = CommonDrawables.GetBoardIconPositions(BoardIconClicked);
            _view.AddDrawables(boardIconsDrawables);
        }

        public void TEST_EndTurn()
        {
            PlayerController.EndTurn();
        }

        public void SetGameData(IGameData gameData)
        {
            GameData = gameData;

            _debugInfoDrawable = new DebugInfoDrawable(new Point(145, 145), gameData.GetPlayers());
            _debugInfoDrawable.UpdateCurrentPlayerId(gameData.GetCurrentPlayerId());
            _view.AddDrawable(_debugInfoDrawable);
        }

        public void SetPlayerController(IPlayerController playerController)
        {
            PlayerController = playerController;
        }

        public void GameWindowLoaded()
        {
            Loaded?.Invoke();
        }

        public void ChatSendMessageClick(string message)
        {
            PlayerController?.ChatSendMessage(message);
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

                var playerAnimator = new PlayerAnimator(playerDrawable);
                _playerAnimators.Add(playerDrawable, playerAnimator);

                var concretePlace = (ConcretePlace)playerData.Place.GetPlaceId();
                _playerConcretePlaces[playerId] = concretePlace;
            }

            var distinctConcretePlaces = _playerConcretePlaces.Values.Distinct().ToList();
            foreach (var concretePlace in distinctConcretePlaces)
            {
                var playerIds = _playerConcretePlaces.Where(x => x.Value == concretePlace).Select(x => x.Key).ToList();
                var playerDrawables = _playerDrawables.Where(x => playerIds.Contains(x.Key)).Select(x => x.Value).ToList();
                var playerAnimators = _playerAnimators.Where(x => playerDrawables.Contains(x.Key)).Select(x => x.Value).ToList();

                var leftCornerPoint = PlacesPositions.GetPlayerPosition(concretePlace);
                PlayerPositionSetterHelper.SetPlayersPositions(playerAnimators, leftCornerPoint);
            }

            _debugInfoDrawable.UpdateCurrentPlayerId(GameData.GetCurrentPlayerId());

            _view.AddDrawables(_playerDrawables.Values);
        }

        public void ChatServerMessage(string message)
        {
            _view.AddChatMessage($"SERVER: {message}");
        }

        public void ChatPlayerMessage(int playerId, string message)
        {
            var playerData = GameData.GetPlayerById(playerId);
            _view.AddChatMessage($"{playerData.Name}: {message}");
        }

        public void ShowGameActionException(string message)
        {
            var mouseLocation = _view.GetCurrentMouseLocation();
            var gameActionExceptionMessageDrawable = new OverMouseMessageDrawable(
                mouseLocation,
                message,
                Color.DarkRed, 
                Color.White);
            _view.AddDrawable(gameActionExceptionMessageDrawable);

            var timer = new Timer();
            timer.Interval = 1500;
            timer.Tick += (sender, args) =>
            {
                timer.Enabled = false;
                timer.Dispose();
                _view.RemoveDrawable(gameActionExceptionMessageDrawable);
            };
            timer.Start();
        }

        public void PlayerPassedPlace(int playerId, int placeId)
        {
            var player = GameData.GetPlayerById(playerId);
            var concretePlace = (ConcretePlace)placeId;
            _playerConcretePlaces[playerId] = concretePlace;


            /*var playerDrawable = _playerDrawables[playerId];
            var playerAnimator = _playerAnimators[playerDrawable];
            var placePosition = PlacesPositions.GetPlayerPosition(concretePlace);

            playerAnimator.MoveTo(placePosition.X + 25, placePosition.Y + 25);*/

            // TODO: animace skakani figurky
            
            

            var playerIds = _playerConcretePlaces.Where(x => x.Value == concretePlace).Select(x => x.Key).ToList();
            var playerDrawables = _playerDrawables.Where(x => playerIds.Contains(x.Key)).Select(x => x.Value).ToList();
            var playerAnimators = _playerAnimators.Where(x => playerDrawables.Contains(x.Key)).Select(x => x.Value).ToList();

            var leftCornerPoint = PlacesPositions.GetPlayerPosition(concretePlace);
            PlayerPositionSetterHelper.SetPlayersPositions(playerAnimators, leftCornerPoint);

            //_playerConcretePlaces[playerId] = concretePlace;

            /*var playerIds = _playerConcretePlaces.Where(x => x.Value == concretePlace).Select(x => x.Key).ToList();
            var playerDrawables = _playerDrawables.Where(x => playerIds.Contains(x.Key)).Select(x => x.Value).ToList();
            
            PlayerPositionSetterHelper.SetPlayersPositions(playerDrawables, leftCornerPoint);*/
        }

        public void PlayerSetPlace(int playerId, int placeId)
        {
            /*var player = GameData.GetPlayerById(playerId);
            var concretePlace = (ConcretePlace)placeId;
            _playerConcretePlaces[playerId] = concretePlace;

            var playerIds = _playerConcretePlaces.Where(x => x.Value == concretePlace).Select(x => x.Key).ToList();
            var playerDrawables = _playerDrawables.Where(x => playerIds.Contains(x.Key)).Select(x => x.Value).ToList();
            var leftCornerPoint = PlacesPositions.GetPlayerPosition(concretePlace);
            PlayerPositionSetterHelper.SetPlayersPositions(playerDrawables, leftCornerPoint);*/
        }

        public void PlayerRolledDice(int playerId, int rolledCount)
        {
            /*_debugInfoDrawable.Hodil = rolledCount.ToString();
            _view.RefreshCanvas();*/
        }

        public void NextRound()
        {
            _debugInfoDrawable.UpdateCurrentPlayerId(GameData.GetCurrentPlayerId());
            _view.RefreshCanvas();
        }

        private void DiceDrawableOnClicked()
        {
            PlayerController.RollDice();
        }

        private void BoardPositionClicked(ConcretePlace concretePlace)
        {
            Console.WriteLine($"Place clicked: {concretePlace}");
        }

        private void BoardIconClicked(ConcretePlace concretePlace)
        {
            Console.WriteLine($"Icon clicked: {concretePlace}");

            var place = GameData.GetPlaceById((int) concretePlace);
            if (place is IHorse horse)
            {
                var underShadowDrawable = new UnderShadowDrawable(new Rectangle(_boardDrawable.GetX(),
                    _boardDrawable.GetY(), _boardDrawable.GetWidth(), _boardDrawable.GetHeight()));
                var cardDrawable = new HorseCardDrawable(new Point(724 / 2, 724 / 2), horse);

                underShadowDrawable.Clicked += () =>
                {
                    _view.RemoveDrawable(underShadowDrawable);
                    _view.RemoveDrawable(cardDrawable);
                };

                _view.AddDrawable(underShadowDrawable);
                _view.AddDrawable(cardDrawable);
            }
        }
    }
}
