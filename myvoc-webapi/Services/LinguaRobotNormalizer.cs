using myvoc_webapi.DTOs;
using myvoc_webapi.Models;

namespace myvoc_webapi.Services;

public class LinguaRobotNormalizer
{
    public WordResponseDto Normalize(LinguaRobotResponse raw)
    {
        var entry = raw.Entries.FirstOrDefault(); // usually safe

        return new WordResponseDto
        {
            Word = entry.Word,
            Pronunciation = ExtractPronunciations(entry),
            Meanings = ExtractMeanings(entry)
        };
    }

    private PronunciationSetDto ExtractPronunciations(Entry entry)
    {
        var result = new PronunciationSetDto();

        foreach (var p in entry.Pronunciations)
        {
            var region = p.Context?.Regions?.FirstOrDefault()?.ToLower();

            var dto = new PronunciationDto
            {
                IPA = p.Transcriptions?.FirstOrDefault().Text,
                AudioUrl = p.Audio?.Url
            };

            if (region?.Contains("united states") == true)
                result.US = dto;
            else if (region?.Contains("united kingdom") == true)
                result.UK = dto;
            else if (region?.Contains("australia") == true)
                result.AU = dto;
            else if (result.Default == null)
                result.Default = dto;
        }

        // fallback logic
        result.Default ??= result.US ?? result.UK ?? result.AU ?? new PronunciationDto();

        return result;
    }

    private List<MeaningDto> ExtractMeanings(Entry entry)
    {
        var list = new List<MeaningDto>();

        foreach (var lexeme in entry.Lexemes)
        {
            var m = new MeaningDto
            {
                PartOfSpeech = lexeme.PartOfSpeech,
                Definitions = lexeme.senses?.Select(s => s.definition).ToList()
            };

            list.Add(m);
        }

        return list;
    }
}