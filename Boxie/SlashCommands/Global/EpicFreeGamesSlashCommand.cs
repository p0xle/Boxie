using Boxie.Modules.EpicFreeGames;
using Boxie.Modules.EpicFreeGames.Models;
using Boxie.Modules.EpicFreeGames.Models.Extensions;
using Boxie.Services.Logging;
using Discord.WebSocket;
using System.Text;

namespace Boxie.SlashCommands.Global
{
    public class EpicFreeGamesSlashCommand : GlobalSlashCommand
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
                if (data is null || data.Current.Count == 0)
                {
                    await command.RespondAsync("Die aktuellen Gratis Spiele konnten nicht geladen werden", ephemeral: true);
                    return;
                }

                StringBuilder builder = new();
                builder.AppendLine("Gratis Epic Games Spiele");
                builder.AppendLine("Diese Woche:");
                foreach (var current in data.Current)
                {
                    builder.Append(current.Title);
                    if (current.OfferType is EpicOfferType.DLC)
                    {
                        builder.Append($" ({current.OfferType.ToFriendlyString()})");
                    }
                    builder.AppendLine();
                }
                builder.AppendLine();
                builder.AppendLine("Nächste Woche:");
                foreach (var next in data.Next)
                {
                    builder.Append(next.Title);
                    if (next.OfferType is EpicOfferType.DLC)
                    {
                        builder.Append($" ({next.OfferType})");
                    }
                    builder.AppendLine();
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
