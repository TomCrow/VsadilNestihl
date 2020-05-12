using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board;
using VsadilNestihl.Game.Player;

namespace VsadilNestihl.Game
{
    public interface IGameData
    {
        Dictionary<int, IPlayerData> GetPlayers();
        IPlayerData GetPlayerById(int playerId);
        int GetCurrentPlayerId();
        bool GetCurrentPlayerRolledThisTurn();
        IPlace GetPlaceById(int placeId);
    }
}
