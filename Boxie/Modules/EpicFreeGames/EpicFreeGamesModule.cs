using Boxie.Modules.EpicFreeGames.Models;

namespace Boxie.Modules.EpicFreeGames
{
    public class EpicFreeGamesModule
    {
        private readonly EpicGamesModule _module;

        public EpicFreeGamesModule()
        {
            _module = new EpicGamesModule();
        }

        public async Task<EpicFreeGamesOutput> GetGamesAsync()
        {
            var games = await _module.GetGamesAsync();

            var currentGames = GetCurrentGames(games);
            var nextGames = GetNextGames(games);

            return new EpicFreeGamesOutput()
            {
                CurrentGames = currentGames,
                NextGames = nextGames
            };
        }

        private static List<EpicOfferGame> GetCurrentGames(List<EpicOfferGame> games)
        {
            return games.Where(w => w.IsBaseGame() && w.HasPromotionalOffers() && w.IsFree() && w.InThisWeek()).ToList();
        }

        private static List<EpicOfferGame> GetNextGames(List<EpicOfferGame> games)
        {
            return games.Where(w => w.IsBaseGame() && w.HasUpcomingPromotionalOffers() && w.WillBeFree() && w.InNextWeek()).ToList();
        }
    }
}
