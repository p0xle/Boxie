using Microsoft.Extensions.DependencyInjection;

namespace Boxie.Modules.EpicFreeGames.Extensions
{
    public static class EpicFreeGamesExtensions
    {
        public static IServiceCollection AddEpicFreeGamesModule(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<EpicFreeGamesModule>();
            return serviceCollection;
        }
    }
}
