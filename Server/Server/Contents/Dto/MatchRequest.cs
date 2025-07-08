namespace Server.Contents
{
    public class MatchRequest
    {
        public long UserId { get; set; }
        public long CharacterId { get; set; }
        public long SkinId { get; set; }
        public string ConnectionServerId { get; set; }
        public string Mode { get; set; }
    }
}
