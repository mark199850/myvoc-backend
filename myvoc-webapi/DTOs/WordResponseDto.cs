namespace myvoc_webapi.DTOs;

public class WordResponseDto
{
    public string Word { get; set; }
    public PronunciationSetDto Pronunciation { get; set; }
    public List<MeaningDto> Meanings { get; set; }
}