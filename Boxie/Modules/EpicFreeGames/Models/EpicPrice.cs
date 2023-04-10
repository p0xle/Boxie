namespace Boxie.Modules.EpicFreeGames.Models
{
    public class EpicPrice
    {
        public EpicTotalPrice? TotalPrice { get; set; }
        public List<EpicLineOffer> LineOffers { get; set; } = new();
    }
}
