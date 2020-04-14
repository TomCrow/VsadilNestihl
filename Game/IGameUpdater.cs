using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Game
{
    public interface IGameUpdater
    {
        void GameStarted(List<Player.Player> players);
        void PlayerSetMoney(Player.Player player, int money);
        void PlayerRolledDice(Player.Player player, int rolledCount);
        void PlayerRolledThisTurn(Player.Player player, bool rolledThisTurn);
        void PlayerSetPlacePosition(Player.Player player, Board.IPlace place, Board.IPosition position);
        void NextRound(Player.Player currentPlayer);
    }
}
