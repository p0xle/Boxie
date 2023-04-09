using Boxie.Services.Logging;
using Discord;
using Discord.Net;
using Discord.WebSocket;
using Newtonsoft.Json;

namespace Boxie.SlashCommands.Global.Factory
{
    public class GlobalSlashCommandFactory : IGlobalSlashCommandFactory
    {
        private readonly ILoggingService _loggingService;
        private readonly DiscordSocketClient _client;
        private readonly SlashCommandBuilder _builder;

        public GlobalSlashCommandFactory(ILoggingService loggingService, DiscordSocketClient client)
        {
            _loggingService = loggingService;
            _client = client;
            _builder = new SlashCommandBuilder();
        }

        public async Task<bool> CreateAsync(string name, string description)
        {
            _builder.WithName(name.ToLower());
            _builder.WithDescription(description);

            try
            {
                await _client.CreateGlobalApplicationCommandAsync(_builder.Build());
                return true;
            }
            catch (HttpException exception)
            {
                var json = JsonConvert.SerializeObject(exception.Errors, Formatting.Indented);
                await _loggingService.LogAsync(json);
                return false;
            }
        }
    }
}
