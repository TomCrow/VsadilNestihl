using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Networking.Messages;

namespace VsadilNestihl.Networking.SerializationEngines
{
    public interface ISerializationEngine
    {
        byte[] Serialize(IMessage message);
        IMessage Deserialize(byte[] bytes);
    }
}
