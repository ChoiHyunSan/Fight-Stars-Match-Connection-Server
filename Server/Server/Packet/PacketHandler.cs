using Google.Protobuf;
using Google.Protobuf.Protocol.Match;
using Server;
using Server.Contents;
using ServerCore;

class PacketHandler
{
    public static async void C_MatchingHandler(PacketSession session, IMessage message)
    {
        if (message is not C_Matching packet || session is not ClientSession clientSession)
        {
            Console.WriteLine("Received invalid C_Matching packet.");
            return;
        }
        await MatchManager.Match(clientSession, packet);
    }
}
