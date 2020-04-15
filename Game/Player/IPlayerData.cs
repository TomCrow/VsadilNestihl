using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VsadilNestihl.Game.Board;

namespace VsadilNestihl.Game.Player
{
    public interface IPlayerData
    {
        int PlayerId { get; }
        string Name { get; }
        Color Color { get; }
        IPlace Place { get; set; }
        int Money { get; set; }
    }
}
