namespace Boxie.Modules.EpicFreeGames.Models.Extensions
{
    public static class EpicOfferTypeExtensions
    {
        public static string ToFriendlyString(this EpicOfferType offerType)
        {
            switch (offerType)
            {
                case EpicOfferType.BASE_GAME:
                    return "Game";
                case EpicOfferType.DLC:
                    return "DLC";
                case EpicOfferType.OTHERS:
                default:
                    return "";
            }
        }
    }
}
