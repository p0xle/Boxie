namespace Boxie.Modules.EpicFreeGames.Models
{
    public class EpicOfferGame
    {
        public string? Title { get; set; }
        public string? Id { get; set; }
        public string? Namespace { get; set; }
        public string? Description { get; set; }
        public string? EffectiveDate { get; set; }
        public string? OfferType { get; set; }
        public bool? ExpiryDate { get; set; }
        public string? Status { get; set; }
        public bool? IsCodeRedemptionOnly { get; set; }
        public List<EpicKeyImage> KeyImages { get; set; } = new();
        public EpicSeller Seller { get; set; } = new();
        public string? ProductSlug { get; set; }
        public string? UrlSlug { get; set; }
        public List<EpicItem> Items { get; set; } = new();
        public List<EpicCustomAttribute> CustomAttributes { get; set; } = new();
        public List<EpicCategory> Categories { get; set; } = new();
        public List<EpicTag> Tags { get; set; } = new();
        public EpicPrice? Price { get; set; }
        public EpicPromotions Promotions { get; set; } = new();

        public bool IsBaseGame(bool includeAll = false) => includeAll || OfferType == "BASE_GAME";
        public bool HasPromotionalOffers() => Promotions?.PromotionalOffers?.Count != 0;
        public bool HasUpcomingPromotionalOffers() => Promotions?.UpcomingPromotionalOffers?.Count != 0;
        public bool IsFree() => Price?.TotalPrice?.DiscountPrice == 0;
        public bool WillBeFree() => Promotions?.UpcomingPromotionalOffers?[0]?.PromotionalOffers?[0]?.DiscountSetting?.DiscountPercentage == 0;
        public bool InThisWeek()
        {
            return Promotions?.PromotionalOffers?[0]?.PromotionalOffers?[0]?.StartDate < DateTime.Now.Date 
                && Promotions?.PromotionalOffers?[0]?.PromotionalOffers?[0]?.EndDate > DateTime.Now.Date;
        }
        public bool InNextWeek()
        {
            var date = DateTime.Now.AddDays(7);
            return Promotions?.UpcomingPromotionalOffers?[0]?.PromotionalOffers?[0]?.StartDate < date
                && Promotions?.UpcomingPromotionalOffers?[0]?.PromotionalOffers?[0]?.EndDate > date;
        }
    }
}
