namespace Boxie.Modules.EpicFreeGames.Models
{
    public class EpicResultSearchStore
    {
        public List<EpicOfferGame> Elements { get; set; } = new();
        public EpicResponsePaging? Paging { get; set; }
    }
}
