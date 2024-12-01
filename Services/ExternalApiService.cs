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

    public async Task<List<Liga>> GetLeagues()
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/{_apiKey}/all_leagues.php");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<Dictionary<string, List<Liga>>>(content);
        return data["leagues"].FindAll(league => league.strSport == "Soccer") ?? new List<Liga>();
    }

   public async Task<List<Partido>> GetUpcomingMatches(string leagueId)
    {
        var currentYear = DateTime.Now.Year;
        var season = $"{currentYear}-{currentYear + 1}";
        var response = await _httpClient.GetAsync($"{_baseUrl}/{_apiKey}/eventsseason.php?id={leagueId}&s={season}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<Dictionary<string, List<Partido>>>(content);
        var matches = data["events"] ?? new List<Partido>();

        // Asignar odds aleatorios a cada partido
        var random = new Random();
        foreach (var match in matches)
        {
            match.Odds = (decimal)(random.NextDouble() * (5.0 - 1.5) + 1.5); // Odds entre 1.5 y 5.0
        }

        return matches;
    }

}