using Boxie.Services.Logging;
using Discord.WebSocket;

namespace Boxie.SlashCommands.Guild
{
    public class ColinSlashCommand : GuildSlashCommand
    {
        public ColinSlashCommand(IServiceProvider serviceProvider, ILoggingService loggingService) : base("Colin", "Ich bin Colin", serviceProvider, loggingService, isDisabled: true)
        {
        }

        public override Task HandleAsync(SocketSlashCommand command)
        {
            command.RespondAsync("Hallo ich bin Colin");
            return Task.CompletedTask;
        }
    }
}
