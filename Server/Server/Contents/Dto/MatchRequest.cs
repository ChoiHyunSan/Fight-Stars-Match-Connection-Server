using Google.Protobuf.Protocol.Match;

namespace Server.Contents
{
    public class MatchRequest
    {
        public long UserId { get; set; }
        public long CharacterId { get; set; }
        public long SkinId { get; set; }
        public string ConnectionServerId { get; set; }
        public string Mode { get; set; }

        public static MatchRequest Create(long userId, C_Matching packet)
        {
            return new MatchRequest
            {
                UserId = userId,
                CharacterId = packet.MatchInfo.CharacterId,
                SkinId = packet.MatchInfo.SkinId,
                ConnectionServerId = Config.ServerId,
                Mode = packet.MatchInfo.Mode
            };
        }
    }
}
