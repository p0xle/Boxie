using Boxie.SlashCommands.Global.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace Boxie.SlashCommands.Global.Extensions
{
    public static class GlobalSlashCommandsExtensions
    {
        public static IServiceCollection AddGlobalSlashCommands(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<TestSlashCommand>()
                .AddScoped<IGlobalSlashCommandFactory, GlobalSlashCommandFactory>();

            return serviceCollection;
        }

        public static async Task CreateGlobalSlashCommands(this IServiceProvider serviceProvider)
        {
            await serviceProvider.GetRequiredService<TestSlashCommand>().CreateAsync();
        }
    }
}
