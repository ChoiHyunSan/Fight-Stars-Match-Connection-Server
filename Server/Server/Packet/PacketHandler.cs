using Google.Protobuf;
using Google.Protobuf.Protocol.Match;
using Server;
using Server.Contents;
using ServerCore;

class PacketHandler
{
    public static async void C_MatchingHandler(PacketSession session, IMessage message)
    {
        C_Matching? packet = message as C_Matching;
        ClientSession? clientSession = session as ClientSession;
        if (packet == null || clientSession == null)
        {
            Console.WriteLine("Received invalid C_Matching packet.");
            return;
        }
        await MatchManager.Match(clientSession, packet);
    }
}
