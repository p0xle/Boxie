using Boxie.Models;
using Boxie.Services.Logging;
using Boxie.SlashCommands;
using Boxie.SlashCommands.Extensions;
using Boxie.SlashCommands.Global.Extensions;
using Boxie.SlashCommands.Handler;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Boxie
{
    public class Program
    {
        public Program()
        {
            _config = LoadConfig();

            _serviceProvider = CreateProvider(_config);

            _client = _serviceProvider.GetRequiredService<DiscordSocketClient>();
            _loggingService = _serviceProvider.GetRequiredService<ILoggingService>();
            _slashCommands = _serviceProvider.GetRequiredService<SlashCommandStorage>();
        }

        private readonly IServiceProvider _serviceProvider;
        private readonly ILoggingService _loggingService;
        private readonly DiscordSocketClient _client;
        private readonly SlashCommandStorage _slashCommands;

        private readonly Config _config;

        private const string defaultConfigPath = "config.json";

        public static void Main(string[] args)
            => new Program().RunAsync(args).GetAwaiter().GetResult();

        private static Config LoadConfig(string filePath = defaultConfigPath)
        {
            try
            {
                var fileContent = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Config>(fileContent) ?? new Config();
            }
            catch (Exception)
            {
                Console.WriteLine("Error loading Config");
                throw;
            }
        }

        private async Task RunAsync(string[] args)
        {
            _client.Ready += Client_Ready;

            ISlashCommandHandler slashCommandHandler = _serviceProvider.GetRequiredService<ISlashCommandHandler>();
            _client.SlashCommandExecuted += slashCommandHandler.Handle;

            await _client.LoginAsync(TokenType.Bot, _config.Token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private async Task Client_Ready()
        {
            await _serviceProvider.CreateGlobalSlashCommands();
        }

        private IServiceProvider CreateProvider(Config config)
        {
            var discordSocketConfig = new DiscordSocketConfig()
            {
                
            };

            var collection = new ServiceCollection()
                .AddSingleton(discordSocketConfig)
                .AddSingleton<DiscordSocketClient>()
                .AddSingleton<ILoggingService, LoggingService>()
                .AddSingleton(config)
                .AddSingleton<SlashCommandStorage>()
                .AddSlashCommandsBase()
                .AddGlobalSlashCommands();

            return collection.BuildServiceProvider();
        }
    }
}