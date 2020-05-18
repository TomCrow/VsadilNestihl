using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Networking.Messages;

namespace VsadilNestihl.Networking
{
    interface IServerSideMessageDispatcher
    {
        void Dispatch(IMessage message, Receiver receiver);
    }
}
