using ServerCore;
using System.Net;
using Google.Protobuf.Protocol.Match;
using Google.Protobuf;
using Server.Contents;

namespace Server
{
	public class ClientSession : PacketSession
	{
		public int SessionId { get; set; }
        public long UserId { get; set; }
        public event Action<ClientSession>? Disconnected;

        public void Send(IMessage packet)
		{
			string msgName = packet.Descriptor.Name.Replace("_", string.Empty);
			MsgId msgId = (MsgId)Enum.Parse(typeof(MsgId), msgName);

			ushort size = (ushort)packet.CalculateSize();
            byte[] sendBuffer = new byte[size + 4];
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
            Disconnected?.Invoke(this);

            SessionManager.Instance.Remove(this);
        }

		public override void OnSend(int numOfBytes)
		{
			//Console.WriteLine($"Transferred bytes: {numOfBytes}");
		}
	}
}
