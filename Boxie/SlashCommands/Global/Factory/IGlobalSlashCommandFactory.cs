namespace Boxie.SlashCommands.Global.Factory
{
    public interface IGlobalSlashCommandFactory
    {
        Task<bool> CreateAsync(string name, string description);
    }
}