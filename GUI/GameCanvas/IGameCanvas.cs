using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.GUI.GameCanvas
{
    public interface IGameCanvas
    {
        void AddDrawable(IDrawable drawable);
        void AddDrawables(IEnumerable<IDrawable> drawables);
        void RemoveDrawable(IDrawable drawable);
        void RefreshCanvas();
    }
}
