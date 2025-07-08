
using Google.Protobuf.Protocol.Match;
using Server.Contents.Manager;

namespace Server.Contents
{
    public static class MatchManager
    {
        public static async Task Match(ClientSession clientSession, C_Matching packet)
        {
            Console.WriteLine($"Match Request, Character ID : {packet.MatchInfo.CharacterId}");

            // 1. JWT 검증 (JWT 파싱)
            var principal = JwtUtils.ValidateToken(packet.Token); 
            if(principal == null)
            {
                SendFailResult(clientSession, S_Matching.Types.AuthResult.InvalidToken);
                return;
            }

            // 2. 매칭 정보 검증 (DB 접근)
            var userId = JwtUtils.GetUserId(principal);
            if(userId == 0L)
            {
                SendFailResult(clientSession, S_Matching.Types.AuthResult.UserNotFound);
                return;
            }
            if(!await DbHelper.HasCharacterAndSkinAsync(userId, packet.MatchInfo.CharacterId, packet.MatchInfo.SkinId))
            {
                SendFailResult(clientSession, S_Matching.Types.AuthResult.InvalidRequest);
                return;
            }

            // 3. 매칭 요청 처리 (Redis 접근이 필요)
            if (!await RedisHelper.EnqueueMatchAsync(MatchRequest.create(userId, packet)))
            {
                SendFailResult(clientSession, S_Matching.Types.AuthResult.AlreadyInMatch);
                return;
            }

            Console.WriteLine($"User ID : {userId}, Character ID : {packet.MatchInfo.CharacterId}, Skin ID : {packet.MatchInfo.SkinId}");
            Console.WriteLine("Enqueue Match Info In Redis");
        }

        private static void SendFailResult(ClientSession clientSession, S_Matching.Types.AuthResult result)
        {
            S_Matching packet = new S_Matching
            {
                AuthResult = result
            };
            clientSession.Send(packet);
        }
    }
}
