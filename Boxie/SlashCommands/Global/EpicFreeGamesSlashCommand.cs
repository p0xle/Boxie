using Boxie.Services.Logging;
using Discord.WebSocket;

namespace Boxie.SlashCommands.Global
{
    public class EpicFreeGamesSlashCommand : SlashCommand
    {
        public EpicFreeGamesSlashCommand(IServiceProvider serviceProvider, ILoggingService loggingService) : base("Free-Epic-Games", "Will return the current and upcoming free games in the Epic Games Launcher", serviceProvider, loggingService)
        {
        }

        public override async Task HandleAsync(SocketSlashCommand command)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://free-epic-games.p.rapidapi.com/free"),
                Headers =
                {
                    { "X-RapidAPI-Key", "41ffb177camshfc7a9c1667ee6efp198dc0jsne1b44e0932f6" },
                    { "X-RapidAPI-Host", "free-epic-games.p.rapidapi.com" },
                },
            };
            
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            await command.RespondAsync(body);
        }
    }
}
