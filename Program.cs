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

        private static void MergeBitmaps(Bitmap bitmapFore, Bitmap bitmapBack)
        {
            // Define output polygon and coverage rectangle
            var curvePoints = new Point[] {
                new Point(833, 278), new Point(1876, 525),
                new Point(1876, 837), new Point(833, 830)
            };
            var outRect = new Rectangle(833, 278, 1043, 559);

            // Create clipping region from points
            System.Drawing.Drawing2D.GraphicsPath clipPath = new System.Drawing.Drawing2D.GraphicsPath();
            clipPath.AddPolygon(curvePoints);

            try
            {
                Bitmap imgB = bitmapBack;
                Bitmap imgF = bitmapFore;
                Bitmap m = new Bitmap(bitmapBack);
                System.Drawing.Graphics myGraphic = System.Drawing.Graphics.FromImage(m);

                myGraphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                myGraphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                myGraphic.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                // Draw foreground image into clipping region
                myGraphic.SetClip(clipPath, System.Drawing.Drawing2D.CombineMode.Replace);
                myGraphic.DrawImage(imgF, outRect);
                myGraphic.ResetClip();

                myGraphic.Save();
                m.Save(@"test.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
