namespace Boxie.Modules.EpicFreeGames.Models
{
    public class EpicPromotionalOffer
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public EpicDiscountSetting? DiscountSetting { get; set; }

    }
}
