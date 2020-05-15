using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VsadilNestihl.Networking.Messages;
using VsadilNestihl.Networking.Messages.Chat;
using VsadilNestihl.Networking.Messages.Game;
using VsadilNestihl.Networking.Messages.GameControlls;
using VsadilNestihl.Networking.Messages.Lobby;

namespace VsadilNestihl.Networking.SerializationEngines
{
    public class IdJsonSerialization : ISerializationEngine
    {
        public static Dictionary<int, Type> MessagesIds = new Dictionary<int, Type>()
        {
            // General
            {1, typeof(Disconnect)},
            {2, typeof(Heartbeat)},

            // Lobby
            {3, typeof(PlayerJoinRequest)},
            {4, typeof(LobbyActionException)},
            {5, typeof(SetPlayerId)},
            {6, typeof(LobbyPlayersUpdate)},
            {7, typeof(PlayerPositionSwitchRequest)},
            {8, typeof(PlayerColorSwitchRequest)},
            {12, typeof(GameStarting)},

            // Chat
            {9, typeof(ChatPlayerMessageRequest)},
            {10, typeof(ChatPlayerMessage)},
            {11, typeof(ChatServerMessage)},

            // Game
            {21, typeof(GameActionException)},
            {13, typeof(GameStarted)},
            {14, typeof(PlayerSetMoney)},
            {15, typeof(PlayerRolledDice)},
            {16, typeof(PlayerRolledThisTurn)},
            {17, typeof(PlayerSetPlace)},
            {18, typeof(NextRound)},
            {22, typeof(PlayerPassedPlace)},

            // Controlls
            {19, typeof(RollDice)},
            {20, typeof(EndTurn)}
        };

        public byte[] Serialize(IMessage message)
        {
            if (message is Messages.Heartbeat)
                return new byte[0];
            int messageId = LookupMessageId(message);

            string serialized = JsonConvert.SerializeObject(message);
            var messageBytes = Encoding.UTF8.GetBytes(serialized);
            byte[] bytes = new byte[messageBytes.Length + 4];
            bytes[0] = (byte)(messageId);
            bytes[1] = (byte)(messageId >> 8);
            bytes[2] = (byte)(messageId >> 16);
            bytes[3] = (byte)(messageId >> 24);
            messageBytes.CopyTo(bytes, 4);
            return bytes;
        }

        public IMessage Deserialize(byte[] bytes)
        {
            if (!bytes.Any())
                return new Messages.Heartbeat();

            var messageId = 0;
            messageId |= bytes[0];
            messageId |= (((int)bytes[1]) << 8);
            messageId |= (((int)bytes[2]) << 16);
            messageId |= (((int)bytes[3]) << 24);

            var messageType = LookupMessageType(messageId);
            var messageBytes = new byte[bytes.Length - 4];
            Array.Copy(bytes, 4, messageBytes, 0, bytes.Length - 4);
            var messageJson = Encoding.UTF8.GetString(messageBytes);
            var message = JsonConvert.DeserializeObject(messageJson, messageType) as IMessage;
            return message;
        }

        private int LookupMessageId(IMessage message)
        {
            foreach (var messIdPair in MessagesIds)
            {
                if (message.GetType() == messIdPair.Value)
                    return messIdPair.Key;
            }
            throw new Exception("Failed to lookup message id by type.");
        }

        private Type LookupMessageType(int id)
        {
            if (MessagesIds.ContainsKey(id))
                return MessagesIds[id];
            throw new Exception("Failed to lookup message type by id.");
        }
    }
}
