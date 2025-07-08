using Google.Protobuf.Protocol.Match;
using Server.Contents;
using Server.Contents.Manager;
using System.Text.Json;

public class MatchSubscriberWorker
{
    public static async Task StartAsync()
    {
        var sub = RedisHelper.GetSubscriber();
        string ch = $"conn:{Config.ServerId}";

        await sub.SubscribeAsync(ch, async (_, message) =>
        {
            try
            {
                RoomInfo info = JsonSerializer.Deserialize<RoomInfo>(message!)!;

                Console.WriteLine($"GameServer IP : {info.Ip}, User ID : {info.UserId}");
                
                var clientSession = MatchManager.FindClientSession(info.UserId);
                if(clientSession == null)
                {
                    return;
                }

                S_Matching packet = new S_Matching
                {
                    Ip = info.Ip,
                    Port = info.Port,
                    RoomId = info.RoomId,
                    Password = info.Password,
                    AuthResult = S_Matching.Types.AuthResult.Success
                };
                clientSession.Send(packet);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[REDIS SUB] parse error: {ex.Message}");
            }
        });

        Console.WriteLine($"[REDIS SUB] subscribed to {ch}");
    }

    public record RoomInfo(string Ip, int Port, string RoomId, string Password, long UserId);
}

