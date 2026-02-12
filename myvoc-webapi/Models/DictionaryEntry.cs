using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

public class DictionaryEntry
{
    public int Id { get; set; }

    // This maps the JSONB column to a flexible C# object
    [Column(TypeName = "jsonb")]
    public required JsonDocument Data { get; set; }
}