using Discord.WebSocket;

namespace Boxie.SlashCommands.Handler
{
    public interface ISlashCommandHandler
    {
        Task Handle(SocketSlashCommand command);
    }
}