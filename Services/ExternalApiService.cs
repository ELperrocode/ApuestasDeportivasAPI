using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

public class ExternalApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _baseUrl;

    public ExternalApiService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["TheSportsDBApiKey"];
        _baseUrl = "https://www.thesportsdb.com/api/v1/json";
    }

    public async Task<List<Partido>> GetPartidos(string leagueId)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/{_apiKey}/eventsnextleague.php?id={leagueId}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<Dictionary<string, List<Partido>>>(content);
        return data["events"] ?? new List<Partido>();
    }
}
