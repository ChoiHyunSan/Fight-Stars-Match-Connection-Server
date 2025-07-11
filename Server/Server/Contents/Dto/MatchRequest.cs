using Google.Protobuf.Protocol.Match;

namespace Server.Contents
{
    public class MatchRequest
    {
        public long userId { get; set; }
        public long characterId { get; set; }
        public long skinId { get; set; }
        public string connectionServerId { get; set; }
        public string mode { get; set; }

        public static MatchRequest Create(long userId, C_Matching packet)
        {
            return new MatchRequest
            {
                userId = userId,
                characterId = packet.MatchInfo.CharacterId,
                skinId = packet.MatchInfo.SkinId,
                connectionServerId = Config.ServerId,
                mode = packet.MatchInfo.Mode
            };
        }
    }
}
