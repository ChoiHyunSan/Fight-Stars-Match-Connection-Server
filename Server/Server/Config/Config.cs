
using System.Net;

public static class Config
{
    public static readonly string Host;
    public static readonly int Port;

    public static readonly string JwtSecret;
    public static readonly string MySqlConn;
    public static readonly string RedisConn;
    public static readonly string ServerId;

    public static readonly int MatchTtl;

    static Config()
    {
        Host = Environment.GetEnvironmentVariable("HOST")
            ?? Dns.GetHostName();

        Port = Environment.GetEnvironmentVariable("PORT") is string portStr && int.TryParse(portStr, out var port)
            ? port
            : 6666;

        JwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET")
                ?? "qwlkfduiwqhrfkeunfsdukfasfzjbcxffeqkufhqerkuhdkfzushfasdfsfqetqet";

        MySqlConn = Environment.GetEnvironmentVariable("MYSQL_CONN")
            ?? "Server=localhost;Port=3306;Database=fightstars;Uid=devuser;Pwd=devpass;";

        RedisConn = Environment.GetEnvironmentVariable("REDIS_CONN")
            ?? "localhost:6379";

        ServerId = Environment.GetEnvironmentVariable("CONN_SERVER_ID") 
            ?? "ConnSrv-1";

        MatchTtl = Environment.GetEnvironmentVariable("MATCH_TTL") is string matchTtlStr && int.TryParse(matchTtlStr, out var matchTtl)
            ? matchTtl
            : 30000; 
    }


}

