using Boxie.Services.Logging;
using Boxie.SlashCommands.Global.Factory;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace Boxie.SlashCommands
{
    public abstract class SlashCommand
    {
        public string Name => _name.ToLower();
        public string Description { get; }

        protected readonly IServiceProvider _serviceProvider;
        protected readonly ILoggingService _loggingService;

        private readonly string _name;

        public SlashCommand(string name, string description, IServiceProvider serviceProvider, ILoggingService loggingService)
        {
            _name = name;
            Description = description;

            _serviceProvider = serviceProvider;
            _loggingService = loggingService;
        }

        public abstract Task HandleAsync(SocketSlashCommand command);

        public async Task CreateAsync()
        {
            try
            {
                IGlobalSlashCommandFactory testCommandFactory = _serviceProvider.GetRequiredService<IGlobalSlashCommandFactory>();
                SlashCommandStorage slashCommands = _serviceProvider.GetRequiredService<SlashCommandStorage>();

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
