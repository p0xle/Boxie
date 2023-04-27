using Boxie.SlashCommands.Guild.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace Boxie.SlashCommands.Guild.Extensions
{
    public static class GuildSlashCommandsExtensions
    {
        public static IServiceCollection AddGuildSlashCommands(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<IGuildSlashCommandFactory, GuildSlashCommandFactory>()
                .AddScoped<EpicFreeGamesSlashCommand>()
                .AddScoped<ColinSlashCommand>();

            return serviceCollection;
        }

        public static async Task CreateGuildSlashCommands(this IServiceProvider serviceProvider)
        {
            await serviceProvider.GetRequiredService<EpicFreeGamesSlashCommand>().CreateAsync();
            await serviceProvider.GetRequiredService<ColinSlashCommand>().CreateAsync();
        }
    }
}
