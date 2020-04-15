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
    public partial class FormNetworkGame : Form, INetworkGameView
    {
        private readonly NetworkGameGui _networkGameGui;

        public FormNetworkGame()
        {
            InitializeComponent();

            _networkGameGui = new NetworkGameGui(this);
        }

        public NetworkGameGui GetNetworkGame()
        {
            return _networkGameGui;
        }

        public void AddDrawable(IDrawable drawable)
        {
            gameCanvas.AddDrawable(drawable);
        }

        public void AddDrawables(IEnumerable<IDrawable> drawables)
        {
            gameCanvas.AddDrawables(drawables);
        }
    }
}
