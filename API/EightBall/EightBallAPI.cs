using Newtonsoft.Json;
using RestSharp;

namespace BillyTheBot.API.EightBall;

public class EightBallAPI
{
    private static readonly RestClientOptions Options = new("https://eightballapi.com/api?question=&lucky=false");
    private static RestClient _client = new(Options);

    public static async Task<string> GetReading()
    {
        var request = new RestRequest();
        request.AddHeader("Content-Type", "application/json");
        var response = await _client.GetAsync(request);

        var message = JsonConvert.DeserializeObject<EightBallResponse>(response.Content).reading;
        return message;
    }
}