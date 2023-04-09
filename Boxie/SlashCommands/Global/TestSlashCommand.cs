using Boxie.Services.Logging;
using Discord.WebSocket;

namespace Boxie.SlashCommands.Global
{
    public class TestSlashCommand : SlashCommand
    {
        public TestSlashCommand(IServiceProvider serviceProvider, ILoggingService loggingService) : base(name, description, serviceProvider, loggingService)
        {

        }

        public const string name = "test-test";
        public const string description = "This is a test slash command (123)";

        public override async Task HandleAsync(SocketSlashCommand command)
        {
            await command.RespondAsync($"You executed {command.Data.Name}: \n {Description}");
        }
    }
}
