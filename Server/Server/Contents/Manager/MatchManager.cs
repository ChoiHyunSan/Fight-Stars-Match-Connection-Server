
using Google.Protobuf.Protocol.Match;

namespace Server.Contents
{
    public static class MatchManager
    {
        public static void match(ClientSession clientSession, C_Matching packet)
        {
            Console.WriteLine($"{packet.MatchInfo.CharacterId}");

            // 1. JWT 검증 (JWT 파싱)


            // 2. 매칭 정보 검증 (DB 접근)


            // 3. 매칭 요청 처리 (Redis 접근이 필요)

        }
    }
}
