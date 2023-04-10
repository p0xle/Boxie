using Boxie.SlashCommands.Guild.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace Boxie.SlashCommands.Guild.Extensions
{
    public static class GuildSlashCommandsExtensions
    {
        public static IServiceCollection AddGlobalSlashCommands(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<IGuildSlashCommandFactory, GuildSlashCommandFactory>()
                .AddScoped<EpicFreeGamesSlashCommand>();

            return serviceCollection;
        }

        public static async Task CreateGlobalSlashCommands(this IServiceProvider serviceProvider)
        {
            await serviceProvider.GetRequiredService<EpicFreeGamesSlashCommand>().CreateAsync();
        }
    }
}
