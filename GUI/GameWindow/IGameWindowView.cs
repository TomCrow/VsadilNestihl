using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.GUI.GameWindow
{
    public interface IGameWindowView
    {
        GameWindowGui GetGameWindowGui();
        void AddDrawableToBoard(GameCanvas.IDrawable drawable);
    }
}
