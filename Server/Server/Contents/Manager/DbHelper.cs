using Dapper;
using MySql.Data.MySqlClient;

namespace Server.Contents.Manager
{
    public class DbHelper
    {
        private static readonly string _connStr = Config.MySqlConn;

        public static async Task<bool> HasCharacterAndSkinAsync(long userId, long characterId, long skinId)
        {
            const string sql = @"
                SELECT EXISTS (
                  SELECT 1
                  FROM user_characters uc
                  JOIN user_skins us
                    ON uc.game_user_id = us.game_user_id
                  WHERE uc.game_user_id = (
                    SELECT id FROM game_users WHERE auth_user = @UserId
                  )
                    AND uc.character_id = @CharacterId
                    AND us.skin_id = @SkinId
                )";

            await using var conn = new MySqlConnection(_connStr);
            
            await conn.OpenAsync();

            return await conn.ExecuteScalarAsync<bool>(sql,
                new { UserId = userId, CharacterId = characterId, SkinId = skinId });
        }
    }

}
