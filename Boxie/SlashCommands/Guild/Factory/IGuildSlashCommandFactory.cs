namespace Boxie.SlashCommands.Guild.Factory
{
    public interface IGuildSlashCommandFactory
    {
        Task<bool> CreateAsync(string name, string description);
    }
}
