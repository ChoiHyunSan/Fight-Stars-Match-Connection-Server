using Dapper;
using MySql.Data.MySqlClient;

namespace Server.Contents.Manager
{
    public static class DbHelper
    {
        private static readonly string _connStr = Config.MySqlConn;

        public static async Task<long> GetGameUserIdAsync(long authUserId)
        {
            const string sql = @"
                SELECT id 
                    FROM game_users 
                    WHERE auth_user = @UserId LIMIT 1";

            await using var conn = new MySqlConnection(_connStr);
            await conn.OpenAsync();

            return await conn.ExecuteScalarAsync<long>(sql, new { UserId = authUserId });
        }
        
        public static async Task<bool> HasCharacterAndSkinAsync(
            long gameUserId, long characterId, long skinId)
        {
            const string sql = @"
                SELECT EXISTS (
                  SELECT 1
                  FROM user_characters uc
                  JOIN user_skins us ON uc.game_user_id = us.game_user_id
                  WHERE uc.game_user_id = @GameUserId
                    AND uc.character_id = @CharacterId
                    AND us.skin_id      = @SkinId
                )";

            await using var conn = new MySqlConnection(_connStr);
            await conn.OpenAsync();

            return await conn.ExecuteScalarAsync<bool>(sql,
                new { GameUserId = gameUserId, CharacterId = characterId, SkinId = skinId });
        }
    }

}
