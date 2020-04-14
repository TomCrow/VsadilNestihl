using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Game.Exceptions
{
    class FatalGameException : Exception
    {
        public FatalGameException(string message) : base(message)
        {
            
        }
    }
}
