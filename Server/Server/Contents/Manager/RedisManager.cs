namespace Server.Contents.Manager
{
    using StackExchange.Redis;
    using System.Text.Json;

    public class RedisManager
    {
        private static readonly ConnectionMultiplexer _redis = ConnectionMultiplexer.Connect("localhost");
        private static readonly IDatabase _db = _redis.GetDatabase();

        public static async Task EnqueueMatchRequestAsync(MatchRequest request)
        {
            string key = $"match:queue:{request.Mode}";
            string json = JsonSerializer.Serialize(request);
            await _db.ListRightPushAsync(key, json);
        }
    }
    public class MatchRequest
    {
        public long UserId { get; set; }
        public long CharacterId { get; set; }
        public long SkinId { get; set; }
        public string ConnectionServerId { get; set; }
        public string Mode { get; set; } 
    }
}
