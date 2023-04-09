using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Boxie.Services
{
    public class LoggingService
    {
        public LoggingService(DiscordSocketClient client, CommandService command)
        {
            client.Log += LogAsync;
            command.Log += LogAsync;
        }

        private Task LogAsync(LogMessage msg)
        {
            if (msg.Exception is CommandException cmdException)
            {
                Console.WriteLine($"[Command/{msg.Severity}] {cmdException.Command.Aliases[0]}" +
                    $" failed to execute in {cmdException.Context.Channel}.");
                return Task.CompletedTask;
            }

            Console.WriteLine($"[General/{msg.Severity}] {msg}");
            return Task.CompletedTask;
        }
    }
}
