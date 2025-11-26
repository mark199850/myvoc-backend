namespace myvoc_webapi.DTOs;

public class PronunciationSetDto
{
    public PronunciationDto US { get; set; }
    public PronunciationDto UK { get; set; }
    public PronunciationDto AU { get; set; }
    public PronunciationDto Default { get; set; }
}