using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Game
{
    public interface IGameView
    {
        event Action Loaded;

        void ReloadAllPlayers();
    }
}
