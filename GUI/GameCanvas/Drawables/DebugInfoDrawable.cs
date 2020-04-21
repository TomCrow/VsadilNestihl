using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Player;

namespace VsadilNestihl.GUI.GameCanvas.Drawables
{
    public class DebugInfoDrawable : Drawable
    {
        private readonly Dictionary<int, IPlayerData> _players;
        private int _currentPlayerId;

        public DebugInfoDrawable(Point p, Dictionary<int, IPlayerData> players)
        {
            X = p.X;
            Y = p.Y;
            _players = players;

            Depth = -1000;
            MouseOverDisabled = true;
        }

        public void UpdateCurrentPlayerId(int currentPlayerId)
        {
            _currentPlayerId = currentPlayerId;
        }

        public override void Draw(Graphics graphics)
        {
            if (_players == null)
                return;

            var nextY = Y;
            foreach (var playerData in _players)
            {
                var color = playerData.Key == _currentPlayerId ? Color.Red : Color.Black;
                graphics.DrawString($"{playerData.Value.Name}, koňto: {playerData.Value.Money}", new Font("Arial", 10f), new SolidBrush(color), X, nextY);
                nextY += 15;
            }
        }
    }
}
