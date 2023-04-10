using Boxie.Modules.EpicFreeGames;
using Boxie.Services.Logging;
using Discord.WebSocket;
using System.Text;

namespace Boxie.SlashCommands.Guild
{
    public class EpicFreeGamesSlashCommand : GuildSlashCommand
    {
        private readonly EpicFreeGamesModule _freeGamesModule;

        public EpicFreeGamesSlashCommand(IServiceProvider serviceProvider, ILoggingService loggingService, EpicFreeGamesModule freeGamesModule) : base("Free-Epic-Games", "Gibt die aktuellen und zukünftigen Gratis Spiele im Epic Games Launcher zurück.", serviceProvider, loggingService)
        {
            _freeGamesModule = freeGamesModule;
        }

        public override async Task HandleAsync(SocketSlashCommand command)
        {
            try
            {
                var data = await _freeGamesModule.GetGamesAsync();
                if (data is null || data.CurrentGames.Count == 0)
                {
                    await command.RespondAsync("Die aktuellen Gratis Spiele konnten nicht geladen werden", ephemeral: true);
                    return;
                }

                StringBuilder builder = new();
                builder.AppendLine("Aktuelle Gratis Spiele:");
                foreach (var current in data.CurrentGames)
                {
                    builder.AppendLine(current.Title);
                }
                builder.AppendLine();
                builder.AppendLine("Zukünftige Gratis Spiele:");
                foreach (var next in data.NextGames)
                {
                    builder.AppendLine(next.Title);
                }

                await command.RespondAsync(builder.ToString());
            }
            catch (Exception ex)
            {
                await _loggingService.LogAsync(ex.Message, LogLevel.Error);
                await command.RespondAsync("Beim Laden der Gratis Spiele ist ein Fehler aufgetreten. Bitte versuchen Sie es später erneut", ephemeral: true);
                return;
            }
        }
    }
}
