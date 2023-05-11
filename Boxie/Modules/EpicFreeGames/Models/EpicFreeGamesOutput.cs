namespace Boxie.Modules.EpicFreeGames.Models
{
    public class EpicFreeGamesOutput
    {
        public List<EpicOfferGame> Current { get; set; } = new();
        public List<EpicOfferGame> Next { get; set; } = new();
    }
}
