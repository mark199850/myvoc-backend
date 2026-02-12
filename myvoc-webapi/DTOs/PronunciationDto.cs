namespace myvoc_webapi.DTOs;

public class PronunciationDto
{
    public required string? IPA { get; set; }
    public required string? AudioUrl { get; set; }
}