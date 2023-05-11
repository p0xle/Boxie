using Boxie.Services.Logging;
using Discord.WebSocket;

namespace Boxie.SlashCommands
{
    public abstract class SlashCommandBase
    {
        public string Name => _name.ToLower();
        public string Description { get; }
        public bool IsDisabled { get; }

        protected readonly IServiceProvider _serviceProvider;
        protected readonly ILoggingService _loggingService;

        private readonly string _name;

        public SlashCommandBase(string name, string description, bool isDisabled, IServiceProvider serviceProvider, ILoggingService loggingService)
        {
            _name = name;
            Description = description;
            IsDisabled = isDisabled;

            _serviceProvider = serviceProvider;
            _loggingService = loggingService;
        }

        public abstract Task HandleAsync(SocketSlashCommand command);
        public abstract Task CreateAsync();
    }
}
