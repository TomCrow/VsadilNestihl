using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.GUI.Menu
{
    public interface IMenuView
    {
        MenuGui GetMenuGui();
        string GetPlayerName();
        int GetHostPort();
        string GetJoinIp();
        int GetJoinPort();
        void ShowNameRequired();
        void ShowException(Exception exception);
        void SetLoading(bool loading);
    }
}
