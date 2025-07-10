using System.Text.Json;
using Google.Protobuf.Protocol.Match;
using Server.Contents;

namespace Server.Worker;

public static class MatchSubscriberWorker
{
    public static async Task StartAsync()
    {
        var sub = RedisHelper.GetSubscriber();
        var ch = $"conn:{Config.ServerId}";

        await sub.SubscribeAsync(ch, async (_, message) =>
        {
            try
            {
                var info = JsonSerializer.Deserialize<RoomInfo>(message!)!;
                Console.WriteLine($"GameServer IP : {info.Ip}, User ID : {info.UserId}");
                
                var clientSession = MatchManager.FindClientSession(info.UserId);
                if(clientSession == null)
                {
                    return;
                }
                
                clientSession.Send(new S_Matching
                {
                    Ip = info.Ip,
                    Port = info.Port,
                    RoomId = info.RoomId,
                    Password = info.Password,
                    AuthResult = S_Matching.Types.AuthResult.Success
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[REDIS SUB] parse error: {ex.Message}");
            }
        });

        Console.WriteLine($"[REDIS SUB] subscribed to {ch}");
    }
}