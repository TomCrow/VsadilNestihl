using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.GUI.Menu
{
    public interface IMenuView
    {
        Menu GetMenu();
        string GetPlayerName();
        int GetHostPort();
        string GetJoinIp();
        int GetJoinPort();
    }
}
