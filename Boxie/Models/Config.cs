namespace Boxie.Models
{
    public class Config
    {
        public string Token { get; init; }
        public ulong GuildId { get; init; }
        public bool DeleteGlobalCommandsOnStartup { get; init; }
        public bool DeleteGuildCommandsOnStartup { get; init; }
    }
}
