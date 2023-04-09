using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Boxie.Services.Logging
{
    public class LoggingService : ILoggingService
    {
        public LoggingService(DiscordSocketClient client)
        {
            client.Log += LogAsync;
        }

        public Task LogAsync(LogMessage msg)
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

        public Task LogAsync(string msg, LogLevel logLevel = LogLevel.Debug)
        {
            Console.WriteLine($"[General/{logLevel}] {msg}");
            return Task.CompletedTask;
        }
    }
}
