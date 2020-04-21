using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.GUI.GameWindow
{
    public interface IGameWindowView : GameCanvas.IGameCanvas
    {
        GameWindowGui GetGameWindowGui();
        void AddChatMessage(string message);
        void ShowGameActionException(string message);
    }
}
