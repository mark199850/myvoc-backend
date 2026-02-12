namespace myvoc_webapi.DTOs;

public class DictionaryWordDto
{
    public required string Id { get; set; }
    public required string Word { get; set; }
    public required string PartOfSpeech { get; set; }
    public string? Meaning { get; set; }
}