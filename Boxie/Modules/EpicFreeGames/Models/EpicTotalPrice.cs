namespace Boxie.Modules.EpicFreeGames.Models
{
    public class EpicTotalPrice
    {
        public int DiscountPrice { get; set; }
        public int OriginalPrice { get; set; }
        public int VoucherDiscount { get; set; }
        public int Discount { get; set; }
        public string? CurrencyCode { get; set; }
        public EpicCurrencyInfo? CurrencyInfo { get; set; }
        public EpicFmtPrice? FmtPrice { get; set; }
    }
}
