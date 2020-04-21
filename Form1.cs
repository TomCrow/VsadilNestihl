using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VsadilNestihl.Game;
using VsadilNestihl.Game.Board;
using VsadilNestihl.Game.Board.DostihyASazky;
using VsadilNestihl.Game.Player;
using VsadilNestihl.Game.PlayerControllers;

namespace VsadilNestihl
{
    partial class Form1 : Form, IGameUpdater
    {
        private GameManager _gameManager;
        public List<LocalPlayerController> PlayerControllers;

        public Form1()
        {
            InitializeComponent();
        }

        private void PictureBoxPlayerOnPaint(object sender, PaintEventArgs e)
        {
            if (!(sender is PictureBox pictureBox))
                return;

            Graphics g = e.Graphics;

            if (pictureBox.Parent != null)
            {
                var index = pictureBox.Parent.Controls.GetChildIndex(pictureBox);
                for (var i = pictureBox.Parent.Controls.Count - 1; i > index; i--)
                {
                    var c = pictureBox.Parent.Controls[i];
                    if (c.Bounds.IntersectsWith(Bounds) && c.Visible)
                    {
                        using (var bmp = new Bitmap(c.Width, c.Height, g))
                        {
                            c.DrawToBitmap(bmp, c.ClientRectangle);
                            g.TranslateTransform(c.Left - Left, c.Top - Top);
                            g.DrawImageUnscaled(bmp, Point.Empty);
                            g.TranslateTransform(Left - c.Left, Top - c.Top);
                        }
                    }
                }
            }
        }

        public void SetGameManager(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void GameUpdated()
        {
            if (_gameManager.CurrentPlayer != null)
            {
                buttonRoll.Text = _gameManager.CurrentPlayer.Name;
            }

            panelStart.BackColor = Color.Black;
            panel1.BackColor = Color.Black;
            panel2.BackColor = Color.Black;
            panel3.BackColor = Color.Black;
            panel4.BackColor = Color.Black;
            panel5.BackColor = Color.Black;
            panel6.BackColor = Color.Black;
            panel7.BackColor = Color.Black;
            panel8.BackColor = Color.Black;
            panel9.BackColor = Color.Black;
            panel10.BackColor = Color.Black;
            panel11.BackColor = Color.Black;
            panel12.BackColor = Color.Black;
            panel13.BackColor = Color.Black;
            panel14.BackColor = Color.Black;
            panel15.BackColor = Color.Black;
            panel16.BackColor = Color.Black;
            panel17.BackColor = Color.Black;
            panel18.BackColor = Color.Black;
            panel19.BackColor = Color.Black;
            panel20.BackColor = Color.Black;
            panel21.BackColor = Color.Black;
            panel22.BackColor = Color.Black;
            panel23.BackColor = Color.Black;
            panel24.BackColor = Color.Black;
            panel25.BackColor = Color.Black;
            panel26.BackColor = Color.Black;
            panel27.BackColor = Color.Black;
            panel28.BackColor = Color.Black;
            panel29.BackColor = Color.Black;
            panel30.BackColor = Color.Black;
            panel31.BackColor = Color.Black;
            panel32.BackColor = Color.Black;
            panel33.BackColor = Color.Black;
            panel34.BackColor = Color.Black;
            panel35.BackColor = Color.Black;
            panel36.BackColor = Color.Black;
            panel37.BackColor = Color.Black;
            panel38.BackColor = Color.Black;
            panel39.BackColor = Color.Black;

            foreach (var player in _gameManager.Players)
            {
                try
                {
                    var panel = GetPanelByPosition(player.Place);
                    panel.BackColor = player.Color;
                }
                catch { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _gameManager.CurrentPlayer.RollDice();
        }

        private Panel GetPanelByPosition(IPlace place)
        {
            var dostihyPlace = place as Place;
            if (dostihyPlace == null)
                throw new InvalidEnumArgumentException();

            switch (dostihyPlace.ConcretePlace)
            {
                case ConcretePlace.Start: return panelStart;
                case ConcretePlace.Fantome: return panel1;
                case ConcretePlace.Finance1: return panel2;
                case ConcretePlace.Gavora: return panel3;
                case ConcretePlace.Clinic1: return panel4;
                case ConcretePlace.Trainer1: return panel5;
                case ConcretePlace.LadyAnne: return panel6;
                case ConcretePlace.Chance1: return panel7;
                case ConcretePlace.Pasek: return panel8;
                case ConcretePlace.Koran: return panel9;
                case ConcretePlace.Distanc: return panel10;
                case ConcretePlace.Neklan: return panel11;
                case ConcretePlace.Transportation: return panel12;
                case ConcretePlace.Portlanc: return panel13;
                case ConcretePlace.Japan: return panel14;
                case ConcretePlace.Trainer2: return panel15;
                case ConcretePlace.Kostrava: return panel16;
                case ConcretePlace.Finance2: return panel17;
                case ConcretePlace.Lukava: return panel18;
                case ConcretePlace.Melak: return panel19;
                case ConcretePlace.Parking: return panel20;
                case ConcretePlace.Grifel: return panel21;
                case ConcretePlace.Chance2: return panel22;
                case ConcretePlace.Mohyla: return panel23;
                case ConcretePlace.Metal: return panel24;
                case ConcretePlace.Trainer3: return panel25;
                case ConcretePlace.Tara: return panel26;
                case ConcretePlace.Furioso: return panel27;
                case ConcretePlace.Staje: return panel28;
                case ConcretePlace.Genius: return panel29;
                case ConcretePlace.Doping: return panel30;
                case ConcretePlace.Shagga: return panel31;
                case ConcretePlace.Dahoman: return panel32;
                case ConcretePlace.Finance3: return panel33;
                case ConcretePlace.Gira: return panel34;
                case ConcretePlace.Trainer4: return panel35;
                case ConcretePlace.Chance3: return panel36;
                case ConcretePlace.Narcius: return panel37;
                case ConcretePlace.Clinic2: return panel38;
                case ConcretePlace.Napoli: return panel39;
            }

            throw new IndexOutOfRangeException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _gameManager.CurrentPlayer.EndTurn();
        }

        public void GameStarted()
        {
        }

        public void ChatPlayerMessage(Player player, string message)
        {
            throw new NotImplementedException();
        }

        public void PlayerSetMoney(Player player, int money)
        {
        }

        public void PlayerRolledDice(Player player, int rolledCount)
        {
        }
        
        public void NextRound(Player currentPlayer)
        {
            GameUpdated();
        }

        public void GameStarted(List<Player> players)
        {
        }

        public void ChatServerMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void PlayerRolledThisTurn(Player player, bool rolledThisTurn)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void PlayerSetPlace(Player player, IPlace place)
        {
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void buttonEndTrn_Click(object sender, EventArgs e)
        {

        }
    }
}
