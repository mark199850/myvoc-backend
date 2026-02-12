namespace myvoc_webapi.DTOs;

public class DictionarySearchResultDto
{
    public required string Id { get; set; }
    public required string Word { get; set; }
    public required string PartOfSpeech { get; set; }
}