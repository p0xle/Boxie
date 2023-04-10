using Boxie.Modules.EpicFreeGames.Models;
using RestSharp;
using Newtonsoft.Json;

namespace Boxie.Modules.EpicFreeGames
{
    public class EpicGamesModule
    {
        private readonly RestClientOptions _restClientOptions;

        public EpicGamesModule()
        {
            _restClientOptions = new RestClientOptions("https://store-site-backend-static.ak.epicgames.com")
            {
                MaxTimeout = -1,
            };
        }

        public async Task<List<EpicOfferGame>> GetGamesAsync()
        {
            using RestClient? client = new RestClient(_restClientOptions);
            RestRequest request = new RestRequest("/freeGamesPromotions?country=DE&locale=de", Method.Get);
            request.AddHeader("Access-Control-Allow-Origin", "*");
            
            RestResponse response = await client.ExecuteAsync(request);
            response.ThrowIfError();

            if (response.Content is null)
            {
                return new List<EpicOfferGame>();
            }

            EpicResponse data = JsonConvert.DeserializeObject<EpicResponse>(response.Content) ?? new EpicResponse();

            return data?.Data?.Catalog?.SearchStore?.Elements ?? new List<EpicOfferGame>();
        }
    }
}
