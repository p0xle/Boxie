using Boxie.Services.Logging;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxie.SlashCommands.Guild
{
    public class DemoSlashCommand : GuildSlashCommand
    {
        public DemoSlashCommand(IServiceProvider serviceProvider, ILoggingService loggingService) : base(name: "demoGuildCommand", "this is just a demo / template command", serviceProvider, loggingService, isDisabled: false)
        {
        }

        public override Task HandleAsync(SocketSlashCommand command)
        {
            command.RespondAsync("This is a functioning test command");
            return Task.CompletedTask;
        }
    }
}
