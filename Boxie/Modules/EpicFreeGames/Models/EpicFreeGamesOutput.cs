namespace Boxie.Modules.EpicFreeGames.Models
{
    public class EpicFreeGamesOutput
    {
        public List<EpicOfferGame> CurrentGames { get; set; } = new();
        public List<EpicOfferGame> NextGames { get; set; } = new();
    }
}
