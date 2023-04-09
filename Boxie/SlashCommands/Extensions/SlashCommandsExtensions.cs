using Boxie.SlashCommands.Handler;
using Microsoft.Extensions.DependencyInjection;

namespace Boxie.SlashCommands.Extensions
{
    public static class SlashCommandsExtensions
    {
        public static IServiceCollection AddSlashCommandsBase(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<SlashCommandStorage>()
                .AddSingleton<ISlashCommandHandler, SlashCommandHandler>();

            return serviceCollection;
        }
    }
}
