using Boxie.Services.Logging;
using Boxie.SlashCommands.Guild.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace Boxie.SlashCommands.Guild
{
    public abstract class GuildSlashCommand : SlashCommandBase
    {
        public GuildSlashCommand(string name, string description, IServiceProvider serviceProvider, ILoggingService loggingService) : base(name, description, serviceProvider, loggingService)
        {
        }

        public override async Task CreateAsync()
        {
            try
            {
                IGuildSlashCommandFactory testCommandFactory = _serviceProvider.GetRequiredService<IGuildSlashCommandFactory>();
                SlashCommandStorage slashCommands = _serviceProvider.GetRequiredService<SlashCommandStorage>();

                if (await testCommandFactory.CreateAsync(Name, Description))
                {
                    slashCommands.Add(this);
                }
            }
            catch (Exception ex)
            {
                await _loggingService.LogAsync(ex.Message, LogLevel.Error);
            }
        }
    }
}
