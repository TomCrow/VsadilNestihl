using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VsadilNestihl.GUI.GameCanvas;

namespace VsadilNestihl.GUI.GameWindow
{
    public partial class FormGameWindow : Form, IGameWindowView
    {
        private readonly GameWindowGui _gameWindowGui;

        public FormGameWindow()
        {
            InitializeComponent();

            _gameWindowGui = new GameWindowGui(this);
        }
        
        public GameWindowGui GetGameWindowGui()
        {
            return _gameWindowGui;
        }
        
        public void AddDrawable(IDrawable drawable)
        {
            gameCanvas.AddDrawable(drawable);
        }

        public void AddDrawables(IEnumerable<IDrawable> drawables)
        {
            gameCanvas.AddDrawables(drawables);
        }

        private void gameCanvas_Load(object sender, EventArgs e)
        {
            _gameWindowGui.GameWindowLoaded();
        }
    }
}
