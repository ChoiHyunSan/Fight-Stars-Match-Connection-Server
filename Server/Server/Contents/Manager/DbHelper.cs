using Dapper;
using MySql.Data.MySqlClient;

namespace Server.Contents.Manager
{
    public class DbHelper
    {
        private static readonly string _connectionString = "server=...;uid=...;pwd=...;database=...;";

        public static async Task<bool> OwnsCharacterAndSkinAsync(long userId, long characterId, long skinId)
        {
            using var conn = new MySqlConnection(_connectionString);
            string sql = @"
            SELECT EXISTS (
                SELECT 1
                FROM user_characters uc
                JOIN user_skins us ON uc.game_user_id = us.game_user_id
                WHERE uc.game_user_id = @UserId
                AND uc.character_id = @CharacterId
                AND us.skin_id = @SkinId
            )";

            return await conn.ExecuteScalarAsync<bool>(sql, new { UserId = userId, CharacterId = characterId, SkinId = skinId });
        }
    }

}
