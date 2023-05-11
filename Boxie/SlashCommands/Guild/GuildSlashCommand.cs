using Boxie.Services.Logging;
using Boxie.SlashCommands.Guild.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace Boxie.SlashCommands.Guild
{
    public abstract class GuildSlashCommand : SlashCommandBase
    {
        public GuildSlashCommand(string name, string description, IServiceProvider serviceProvider, ILoggingService loggingService, bool isDisabled = false) : base(name, description, isDisabled, serviceProvider, loggingService)
        {
        }

        public override async Task CreateAsync()
        {
            // Don't create disabled SlashCommands
            if (IsDisabled)
            {
                return;
            }

            try
            {
                IGuildSlashCommandFactory testCommandFactory = _serviceProvider.GetRequiredService<IGuildSlashCommandFactory>();
                SlashCommandStorage slashCommands = _serviceProvider.GetRequiredService<SlashCommandStorage>();

                // this will return false if no guild id is set in the config and therefore not register the command
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
