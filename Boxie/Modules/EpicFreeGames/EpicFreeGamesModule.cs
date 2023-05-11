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
            List<EpicOfferGame> games = await _module.GetGamesAsync();

            List<EpicOfferGame> current = GetCurrent(games);
            List<EpicOfferGame> next = GetNext(games);

            return new EpicFreeGamesOutput()
            {
                Current = current,
                Next = next
            };
        }

        private static List<EpicOfferGame> GetCurrent(List<EpicOfferGame> games)
        {
            return games.Where(
                w => w.HasPromotionalOffers()
                    && w.IsFree()
                    && w.InThisWeek()
                ).ToList();
        }

        private static List<EpicOfferGame> GetNext(List<EpicOfferGame> games)
        {
            return games.Where(
                g => g.HasUpcomingPromotionalOffers() 
                    && g.WillBeFree() 
                    && g.InNextWeek()
                ).ToList();
        }
    }
}
