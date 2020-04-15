using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.GUI.GameWindow
{
    public class NetworkGameGui
    {
        private readonly INetworkGameView _view;

        public NetworkGameGui(INetworkGameView networkGameView)
        {
            _view = networkGameView;
        }
    }
}
