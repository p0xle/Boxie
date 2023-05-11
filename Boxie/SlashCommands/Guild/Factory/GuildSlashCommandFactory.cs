using Boxie.Models;
using Boxie.Services.Logging;
using Discord;
using Discord.Net;
using Discord.WebSocket;
using Newtonsoft.Json;

namespace Boxie.SlashCommands.Guild.Factory
{
    public class GuildSlashCommandFactory : IGuildSlashCommandFactory
    {
        private readonly ILoggingService _loggingService;
        private readonly DiscordSocketClient _client;
        private readonly SlashCommandBuilder _builder;
        private readonly SocketGuild _guild;
        private readonly Config _config;

        public GuildSlashCommandFactory(ILoggingService loggingService, DiscordSocketClient client, Config config)
        {
            _loggingService = loggingService;
            _client = client;
            _builder = new SlashCommandBuilder();
            _config = config;
            _guild = _client.GetGuild(config.GuildId ?? 0);
        }

        public async Task<bool> CreateAsync(string name, string description)
        {
            if (_config.GuildId is 0)
            {
                return false;
            }

            _builder.WithName(name.ToLower());
            _builder.WithDescription(description);

            try
            {
                await _guild.CreateApplicationCommandAsync(_builder.Build());
                return true;
            }
            catch (HttpException exception)
            {
                var json = JsonConvert.SerializeObject(exception.Errors, Formatting.Indented);
                await _loggingService.LogAsync(json, LogLevel.Error);
                return false;
            }
        }
    }
}
