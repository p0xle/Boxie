using Boxie.SlashCommands.Global;
using Discord.WebSocket;

namespace Boxie.SlashCommands.Handler
{
    public class SlashCommandHandler : ISlashCommandHandler
    {
        private readonly SlashCommandStorage _slashCommands;

        public SlashCommandHandler(SlashCommandStorage slashCommands)
        {
            _slashCommands = slashCommands;
        }

        public async Task Handle(SocketSlashCommand command)
        {
            SlashCommandBase? slashCommand = _slashCommands.Find(f => f.Name.Equals(command.Data.Name));
            if (slashCommand is not null)
            {
                await slashCommand.HandleAsync(command);
            }
        }
    }
}
