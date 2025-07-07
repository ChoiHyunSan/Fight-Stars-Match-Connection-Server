
public static class Config
{
    public static readonly string JwtSecret;
    public static readonly string MySqlConn;

    static Config()
    {
        JwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET")
                ?? "qwlkfduiwqhrfkeunfsdukfasfzjbcxffeqkufhqerkuhdkfzushfasdfsfqetqet";


        MySqlConn = Environment.GetEnvironmentVariable("MYSQL_CONN")
            ?? "Server=localhost;Port=3306;Database=fightstars;Uid=devuser;Pwd=devpass;";

    }


}

