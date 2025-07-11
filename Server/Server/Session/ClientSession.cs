using ServerCore;
using System.Net;
using Google.Protobuf.Protocol.Match;
using Google.Protobuf;

namespace Server
{
	public class ClientSession : PacketSession
	{
		public int sessionId { get; set; }
        public long userId { get; set; }
        public event Action<ClientSession>? disconnected;

        public void Send(IMessage packet)
		{
			var msgName = packet.Descriptor.Name.Replace("_", string.Empty);
			var msgId = (MsgId)Enum.Parse(typeof(MsgId), msgName);

			var size = (ushort)packet.CalculateSize();
            var sendBuffer = new byte[size + 4];
            Array.Copy(BitConverter.GetBytes((ushort)size + 4), 0, sendBuffer, 0, sizeof(ushort));
            Array.Copy(BitConverter.GetBytes((ushort)msgId), 0, sendBuffer, 2, sizeof(ushort));
			Array.Copy(packet.ToByteArray(), 0, sendBuffer, 4, size);

			Send(new ArraySegment<byte>(sendBuffer));
        }

		public override void OnConnected(EndPoint endPoint)
		{
			Console.WriteLine($"OnConnected : {endPoint}");
        }

		public override void OnRecvPacket(ArraySegment<byte> buffer)
		{
			PacketManager.Instance.OnRecvPacket(this, buffer);
		}

		public override void OnDisconnected(EndPoint endPoint)
		{
            Console.WriteLine($"OnDisConnected : {endPoint}");
            disconnected?.Invoke(this);

            SessionManager.Instance.Remove(this);
        }

		public override void OnSend(int numOfBytes)
		{
			
		}
	}
}
