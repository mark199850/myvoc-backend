using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using myvoc_webapi.Models;
using myvoc_webapi.Services;

namespace myvoc_webapi.Controllers;

// [ApiController]
// [Route("[controller]")]
// public class WordController : ControllerBase
// {
//     [HttpGet]
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     [ProducesResponseType(StatusCodes.Status400BadRequest)]
//     [ProducesResponseType(StatusCodes.Status404NotFound)]
//     [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//
//     public async Task<IEnumerable<LinguaRobotResponse>> Get()
//     {
//         var json = await File.ReadAllTextAsync("example.json"); // or from HttpClient
//         var options = new JsonSerializerOptions
//         {
//             PropertyNameCaseInsensitive = true
//         };
//         
//         LinguaRobotResponse? response = JsonSerializer.Deserialize<LinguaRobotResponse>(json, options);
//
//         if (response?.Entries != null)
//         {
//             foreach (var entry in response.Entries)
//             {
//                 Console.WriteLine($"Word: {entry.Word}");
//                 if (entry.Pronunciations != null)
//                 {
//                     foreach (var pron in entry.Pronunciations)
//                     {
//                         var transcription = pron.Transcriptions?.FirstOrDefault()?.Text ?? "N/A";
//                         Console.WriteLine($"Pronunciation: {transcription}");
//                     }
//                 }
//             }
//         }
//     }
// }

[Route("api/[controller]")]
[ApiController]
public class WordController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly LinguaRobotNormalizer _normalizer;

    public WordController(IHttpClientFactory httpClientFactory, LinguaRobotNormalizer normalizer)
    {
        _httpClientFactory = httpClientFactory;
        _normalizer = normalizer;
    }

    [HttpGet("{word}")]
    public async Task<IActionResult> GetWord(string word)
    {
        var httpClient = _httpClientFactory.CreateClient("word");
        
        var endpoint = $"language/v1/entries/en/{word}";
        HttpResponseMessage response = await httpClient.GetAsync(endpoint);

        if (!response.IsSuccessStatusCode)
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);

        string json = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        LinguaRobotResponse raw = JsonSerializer.Deserialize<LinguaRobotResponse>(json, options);
        
        if (raw == null)
            return BadRequest("Could not parse LinguaRobot response");

        var clean = _normalizer.Normalize(raw);
        return new JsonResult(clean);
    }
}