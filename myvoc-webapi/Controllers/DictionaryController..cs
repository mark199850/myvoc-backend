using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DictionaryController : ControllerBase
{
    private readonly DictionaryService _service;

    public DictionaryController(DictionaryService service)
    {
        _service = service;
    }

    [HttpGet("{langCode}/{pos}/{word}")]
    public async Task<IActionResult> Get(string langCode, string word, string pos)
    {
        var result = await _service.GetWordDefinitionAsync(langCode,word, pos);

        if (result == null) 
            return NotFound($"Word '{word}' not found in language '{langCode}'.");

        return Ok(result);
    }

    [HttpGet("search/{langCode}/{query}")]
    public async Task<IActionResult> Search(string langCode, string query)
    {
        if (string.IsNullOrWhiteSpace(query) || query.Length < 2)
            return BadRequest("Search query must be at least 2 characters.");

        var results = await _service.SearchWordsAsync(langCode, query);
        return Ok(results);
    }

    [HttpGet("languages")]
    public async Task<IActionResult> GetLanguages()
    {
        var languages = await _service.GetLanguagesAsync();
        return Ok(languages);
    }
}