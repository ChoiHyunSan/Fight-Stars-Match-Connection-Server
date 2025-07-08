namespace Server.Contents.Manager
{
    using StackExchange.Redis;
    using System.Text.Json;

    public class RedisHelper
    {
        private static readonly Lazy<ConnectionMultiplexer> _lazy =
            new(() => ConnectionMultiplexer.Connect(Config.RedisConn));
        private static IDatabase DB => _lazy.Value.GetDatabase();
        private static ConnectionMultiplexer Redis => _lazy.Value;

        private const int MatchTtl = 30000;

        private const string EnqueueLua = 
            @"if redis.call('SETNX', KEYS[2], 1) == 0 then return 0 end
            redis.call('EXPIRE', KEYS[2], ARGV[2])
            redis.call('RPUSH',  KEYS[1], ARGV[1])
            return 1";

        public static async Task<bool> EnqueueMatchAsync(MatchRequest req)
        {
            var json = JsonSerializer.Serialize(req);
            var ok = (int)await DB.ScriptEvaluateAsync(
                EnqueueLua,
                new RedisKey[] { $"match:queue:{req.Mode}", $"in_match:{req.UserId}" },
                new RedisValue[] { json, MatchTtl });
            return ok == 1;
        }

        public static Task CancelMatchAsync(long uid) =>
            DB.KeyDeleteAsync($"in_match:{uid}");

        public static ISubscriber GetSubscriber()
        {
            return Redis.GetSubscriber();
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
