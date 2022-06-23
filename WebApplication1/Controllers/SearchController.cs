using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers {
    public class SearchController : Controller {

        public async Task<ActionResult> Index(string searchString) 
        {
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{Constants.baseurl}/search?term={searchString}&limit=5"),
                Headers =
                {
                    { "X-RapidAPI-Host", Constants.host },
                    { "X-RapidAPI-Key", Constants.extraApikey },
                },
            };
            Shazam result;
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<Shazam>(content);
            }
            return View(result); 
        }

        public async Task<ActionResult> Details(string id) 
        {
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{Constants.baseurl}/songs/get-details?key={id}"),
                Headers =
                {
                    { "X-RapidAPI-Host", Constants.host },
                    { "X-RapidAPI-Key", Constants.extraApikey },
                },
            };
            TrackInfo result;
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<TrackInfo>(content);
            }            
            Track newItem;
            if (result.Sections[1].Text == null)
            {
                Uri uri = new Uri(result.Sections[1].Youtubeurl.Actions[0].Uri);
                string videoid = uri.Segments.Last();
                string videouri = $"https://www.youtube.com/embed/{videoid}";
                newItem = new(
                    result.Key, result.Title, result.Subtitle,
                    result.Images.Background, result.Images.Coverart,
                    result.Genres.Primary, "The track has no lyrics",
                    "So threre is no footer for lyrics",
                    result.Sections[1].Youtubeurl.Caption,
                    videouri
                );
            }
            else
            {
                Uri uri = new Uri(result.Sections[2].Youtubeurl.Actions[0].Uri);
                string videoid = uri.Segments.Last();
                string videouri = $"https://www.youtube.com/embed/{videoid}";
                string lyrics = string.Join(".", result.Sections[1].Text.ToArray()); ///////////
                newItem = new(
                    result.Key, result.Title, result.Subtitle,
                    result.Images.Background, result.Images.Coverart,
                    result.Genres.Primary, lyrics,
                    result.Sections[1].Footer,
                    result.Sections[2].Youtubeurl.Caption,
                    videouri
                );
            }
            return View(newItem);
        }       
    }
}
