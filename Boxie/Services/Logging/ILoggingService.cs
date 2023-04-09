using Discord;

namespace Boxie.Services.Logging
{
    public interface ILoggingService
    {
        public Task LogAsync(string msg, LogLevel logLevel = LogLevel.Debug);
        public Task LogAsync(LogMessage msg);
    }
}
