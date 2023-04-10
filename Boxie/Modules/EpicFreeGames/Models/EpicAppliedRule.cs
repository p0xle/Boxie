namespace Boxie.Modules.EpicFreeGames.Models
{
    public class EpicAppliedRule
    {
        public string? Id { get; set; }
        public DateTime EndDate { get; set; }
        public EpicDiscountSetting? DiscountSetting { get; set; }
    }
}
