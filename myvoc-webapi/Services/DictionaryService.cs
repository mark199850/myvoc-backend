using Microsoft.EntityFrameworkCore;
using myvoc_webapi.DTOs;
using System.Text.Json;

public class DictionaryService(DictionaryContext context)
{

    public async Task<DictionaryWordDto?> GetWordDefinitionAsync(string langCode, string word, string pos)
    {
        var entity = await context.DictionaryEntries
        .AsNoTracking()
        .Where(e => e.Data.RootElement.GetProperty("word").GetString() == word 
                 && e.Data.RootElement.GetProperty("lang_code").GetString() == langCode
                 && e.Data.RootElement.GetProperty("pos").GetString() == pos)
        .FirstOrDefaultAsync();

        if (entity == null) return null;

        var root = entity.Data.RootElement;
        string meaning = "Definition not found";

        if (root.TryGetProperty(propertyName: "senses", out var senses)
        &&
        senses.GetArrayLength() > 0
        &&
        senses[0].TryGetProperty(propertyName: "glosses", out var glosses)
        &&
        glosses.GetArrayLength() > 0
        )
        {
            // Get the first item [0], then get 'glosses'
            meaning = glosses[1].GetString() ?? meaning;
        }

        return new DictionaryWordDto
        {
            Id = $"{langCode}_{pos}_{word}",
            Word = word,
            PartOfSpeech = pos,
            Meaning = meaning
        };
    }

    public async Task<List<DictionarySearchResultDto>> SearchWordsAsync(string langCode, string query)
    {
        var term = query.ToLower(); 

        var results = await context.DictionaryEntries
            .AsNoTracking()
            .Where(e => 
                e.Data.RootElement.GetProperty("lang_code").GetString() == langCode 
                && e.Data.RootElement.GetProperty("word").GetString()
                .StartsWith(term))
            .Select(e => new DictionarySearchResultDto 
            {
                Id = $"{langCode}_{e.Data.RootElement.GetProperty("pos").GetString()}_{e.Data.RootElement.GetProperty("word").GetString()}",
                Word = e.Data.RootElement.GetProperty("word").GetString() ?? string.Empty,
                PartOfSpeech = e.Data.RootElement.GetProperty("pos").GetString()  ?? string.Empty
            })
            .Take(50)
            .ToListAsync();

        return results;
    }

    public async Task<List<LanguageDto>> GetLanguagesAsync()
    {
        return await context.Languages
            .OrderByDescending(l => l.EntryCount)
            .ToListAsync();
    }

}