using Boxie.SlashCommands.Global.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace Boxie.SlashCommands.Global.Extensions
{
    public static class GlobalSlashCommandsExtensions
    {
        public static IServiceCollection AddGlobalSlashCommands(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<IGlobalSlashCommandFactory, GlobalSlashCommandFactory>()
                .AddScoped<EpicFreeGamesSlashCommand>()
                .AddScoped<TestSlashCommand>();

            return serviceCollection;
        }

        public static async Task CreateGlobalSlashCommands(this IServiceProvider serviceProvider)
        {
            await serviceProvider.GetRequiredService<TestSlashCommand>().CreateAsync();
            await serviceProvider.GetRequiredService<EpicFreeGamesSlashCommand>().CreateAsync();
        }
    }
}
