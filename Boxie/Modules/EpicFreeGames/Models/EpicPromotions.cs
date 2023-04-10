namespace Boxie.Modules.EpicFreeGames.Models
{
    public class EpicPromotions
    {
        public List<EpicPromotionalOffers> PromotionalOffers { get; set; } = new();
        public List<EpicPromotionalOffers> UpcomingPromotionalOffers { get; set; } = new();
    }
}
