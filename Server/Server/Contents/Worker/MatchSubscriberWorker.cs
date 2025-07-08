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
                // TODO : 클라이언트가 아직 매칭 대기중이라면, 매칭 정보를 전달한다.
                Console.WriteLine($"GameServer IP : {info.Ip}, User ID : {info.UserId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[REDIS SUB] parse error: {ex.Message}");
            }
        });

        Console.WriteLine($"[REDIS SUB] subscribed to {ch}");
    }

    public record RoomInfo(string Ip, int Port, string RoomId, long UserId);
}

