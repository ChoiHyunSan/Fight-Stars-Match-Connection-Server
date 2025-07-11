using System.Text.Json;
using StackExchange.Redis;

namespace Server.Contents
{
    public static class RedisHelper
    {
        private static readonly Lazy<ConnectionMultiplexer> Lazy =
            new(() => ConnectionMultiplexer.Connect(Config.RedisConn));
        private static IDatabase Db => Lazy.Value.GetDatabase();
        private static ConnectionMultiplexer Redis => Lazy.Value;

        private const string EnqueueLua = 
            @"if redis.call('SETNX', KEYS[2], 1) == 0 then return 0 end
            redis.call('EXPIRE', KEYS[2], ARGV[2])
            redis.call('RPUSH',  KEYS[1], ARGV[1])
            return 1";

        public static async Task<bool> EnqueueMatchAsync(MatchRequest req)
        {
            var json = JsonSerializer.Serialize(req);
            var ok = (int)await Db.ScriptEvaluateAsync(
                EnqueueLua,
                [$"match:queue:{req.mode}", $"in_match:{req.userId}"],
                [json, Config.MatchTtl]);
            return ok == 1;
        }

        public static Task CancelMatchAsync(long uid) =>
            Db.KeyDeleteAsync($"in_match:{uid}");

        public static ISubscriber GetSubscriber()
        {
            return Redis.GetSubscriber();
        }
    }
}
