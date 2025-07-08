
public static class Config
{
    public static readonly string JwtSecret;
    public static readonly string MySqlConn;
    public static readonly string RedisConn;
    public static readonly string ServerId;

    static Config()
    {
        JwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET")
                ?? "qwlkfduiwqhrfkeunfsdukfasfzjbcxffeqkufhqerkuhdkfzushfasdfsfqetqet";

        MySqlConn = Environment.GetEnvironmentVariable("MYSQL_CONN")
            ?? "Server=localhost;Port=3306;Database=fightstars;Uid=devuser;Pwd=devpass;";

        RedisConn = Environment.GetEnvironmentVariable("REDIS_CONN")
            ?? "localhost:6379";

        ServerId = Environment.GetEnvironmentVariable("CONN_SERVER_ID") 
            ?? "ConnSrv-1";
    }


}

