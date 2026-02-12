using Microsoft.EntityFrameworkCore;

public class DictionaryContext(DbContextOptions<DictionaryContext> options) : DbContext(options)
{
    public required DbSet<DictionaryEntry> DictionaryEntries { get; set; }
    public required DbSet<LanguageDto> Languages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DictionaryEntry>().ToTable("raw_dictionary");

        modelBuilder.Entity<DictionaryEntry>()
            .Property(e => e.Id)
            .HasColumnName("id");

        modelBuilder.Entity<DictionaryEntry>()
            .Property(e => e.Data)
            .HasColumnName("data");

        modelBuilder.Entity<LanguageDto>(entity =>
        {
            entity.ToView("view_languages");
            entity.HasNoKey();
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.EntryCount).HasColumnName("entry_count");
        });
    }
}