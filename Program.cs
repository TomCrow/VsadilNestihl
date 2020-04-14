using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VsadilNestihl.Game;
using VsadilNestihl.Game.Board;
using VsadilNestihl.Game.Board.DostihyASazky;
using VsadilNestihl.Game.Player;

namespace VsadilNestihl
{
    static class Program
    {
        /// <summary>
        /// Hlavní vstupní bod aplikace.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /*var frm = new Form1();


            var gameSettings = new GameSettings {StartMoney = 30000};
            var boardFactory = new BoardFactory();
            var player1 = new Player("Hrac 1", Color.Blue);
            var player2 = new Player("Hráč 2", Color.Red);
            
            var player1Controller = new LocalPlayerController(player1);
            var player2Controller = new LocalPlayerController(player2);

            var game = new GameManager(boardFactory.CreateBoard(), gameSettings, frm, new List<Player> {player1, player2});
            

            frm.SetGameManager(game);
            frm.PlayerControllers = new List<LocalPlayerController> {player1Controller, player2Controller};

            game.Start();*/

            Application.Run(new GUI.Menu.FormMenu());
        }
    }
}
