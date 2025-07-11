
using Google.Protobuf.Protocol.Match;
using Server.Contents.Manager;
using System.Collections.Concurrent;

namespace Server.Contents
{
    public static class MatchManager
    {
        private static readonly ConcurrentDictionary<long, ClientSession> MatchSessions = new();

        private static bool TryAddMatchSession(long userId, ClientSession session)
        {
            if (!MatchSessions.TryAdd(userId, session)) return false;
            session.userId = userId;
            session.disconnected += OnSessionDisconnected;
            return true;
        }

        public static ClientSession? FindClientSession(long userId)
        {
            MatchSessions.TryGetValue(userId, out var session);
            return session;
        }   

        private static void OnSessionDisconnected(ClientSession session)
        {
            MatchSessions.TryRemove(session.userId, out _);
            RedisHelper.CancelMatchAsync(session.userId).Wait();
        }

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

            var gameUserId = await DbHelper.GetGameUserIdAsync(userId);
            if (gameUserId == 0L)
            {
                SendFailResult(clientSession, S_Matching.Types.AuthResult.UserNotFound);
                return;
            }
            
            if(!await DbHelper.HasCharacterAndSkinAsync(gameUserId, packet.MatchInfo.CharacterId, packet.MatchInfo.SkinId))
            {
                SendFailResult(clientSession, S_Matching.Types.AuthResult.InvalidRequest);
                return;
            }
        
            TryAddMatchSession(gameUserId, clientSession);

            // 3. 매칭 요청 처리 (Redis 접근이 필요)
            if (!await RedisHelper.EnqueueMatchAsync(MatchRequest.Create(gameUserId, packet)))
            {
                SendFailResult(clientSession, S_Matching.Types.AuthResult.AlreadyInMatch);
                return;
            }

            Console.WriteLine($"User ID : {gameUserId}, Character ID : {packet.MatchInfo.CharacterId}, Skin ID : {packet.MatchInfo.SkinId}");
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
