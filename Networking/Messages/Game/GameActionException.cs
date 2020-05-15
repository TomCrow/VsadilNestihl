using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Networking.Messages.Game
{
    [Serializable]
    public class GameActionException : IMessage
    {
        public string Message { get; set; }

        public GameActionException() { }
        public GameActionException(string message)
        {
            Message = message;
        }
    }
}
