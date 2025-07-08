
using Google.Protobuf.Protocol.Match;
using Server.Contents.Manager;

namespace Server.Contents
{
    public static class MatchManager
    {
        public static async Task match(ClientSession clientSession, C_Matching packet)
        {
            Console.WriteLine($"{packet.MatchInfo.CharacterId}");

            // 1. JWT 검증 (JWT 파싱)
            var pricipal = JwtUtils.ValidateToken(packet.Token); 
            if(pricipal == null)
            {
                SendFailResult(clientSession, S_Matching.Types.AuthResult.InvalidToken);
                return;
            }

            // 2. 매칭 정보 검증 (DB 접근)
            var userId = JwtUtils.GetUserId(pricipal);
            if(userId == 0L)
            {
                SendFailResult(clientSession, S_Matching.Types.AuthResult.InvalidToken);
                return;
            }
            Console.WriteLine($"User ID : {userId}, Character ID : {packet.MatchInfo.CharacterId}, Skin ID : {packet.MatchInfo.SkinId}");

            if(!await DbHelper.HasCharacterAndSkinAsync(userId, packet.MatchInfo.CharacterId, packet.MatchInfo.SkinId))
            {
                SendFailResult(clientSession, S_Matching.Types.AuthResult.UserNotFound);
            }

            // 3. 매칭 요청 처리 (Redis 접근이 필요)
            var ok = await RedisHelper.EnqueueMatchAsync(
                new MatchRequest
                {
                    UserId = userId,
                    CharacterId = packet.MatchInfo.CharacterId,
                    SkinId = packet.MatchInfo.SkinId,
                    ConnectionServerId = Config.ServerId,
                    Mode = packet.MatchInfo.Mode
                }   
            );
            if (!ok)
            {
                // TODO : ALREDY_IN_MATCH Enum 값을 추가해서 수정하기
                SendFailResult(clientSession, S_Matching.Types.AuthResult.AccessDenied);
                return;
            }
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
