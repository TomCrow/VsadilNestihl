using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VsadilNestihl.GUI.GameCanvas
{
    public interface IDrawable
    {
        event Action PositionUpdated;

        int GetDepth();
        void Draw(Graphics graphics);
        bool IsMouseOver(int mouseX, int mouseY);
        void SetMouseOver(bool mouseOver);
        void SetMousePressed(bool pressed);
        void Click();
    }
}
