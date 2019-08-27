using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GifFind.API.Models;
using GifFind.API.Models.DTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace GifFind.Services
{
    public class GiphyClientService : IAppClient
    {
        // Allow only for G rating Gifs
        private const string RATING = "G";
        private const string LANG = "en";

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public GiphyClientService(HttpClient httpClient, IConfiguration configuration)
        {
            this._httpClient = httpClient;
            this._configuration = configuration;
        }

        public async Task<RootObject> SearchAsync(string query, int limit = 100, int offset = 0)
        {
            var apiKey = _configuration.GetValue<string>("giphy:apiKey");

            var uri = $"https://api.giphy.com/v1/gifs/search?api_key={apiKey}&q={query}&limit={limit}&offset={offset}&rating={RATING}&lang={LANG}";

            var response = await _httpClient.GetStringAsync(uri);

            var result = JsonConvert.DeserializeObject<RootObject>(response);

            return result;

            //var images = new List<GifPackage>();

            //foreach(var gif in metaData.data)
            //{
            //    images.Add(new GifPackage()
            //    {
            //        id = gif.id,
            //        orginURL = gif.source,
            //        sourceURL = gif.url,
            //        title = gif.title,
            //        gifImage = new GifImage()
            //        {
            //            original = gif.images.original,
            //            original_still = gif.images.original_still,
            //            previewGif = gif.images.preview_gif
            //        }
            //    });
            //}

            //return images;
        }
    }
}
