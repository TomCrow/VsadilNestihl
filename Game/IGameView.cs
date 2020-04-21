using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.PlayerControllers;

namespace VsadilNestihl.Game
{
    public interface IGameView
    {
        event Action Loaded;

        void SetPlayerController(IPlayerController playerController);
        void ReloadAllPlayers();
        void ChatServerMessage(string message);
        void ChatPlayerMessage(int playerId, string message);
        void ShowGameActionException(string message);
        void UpdatePlayerPlace(int playerId);
        void PlayerRolledDice(int playerId, int rolledCount);
        void NextRound();
    }
}
