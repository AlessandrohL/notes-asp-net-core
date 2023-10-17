using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Todo_app.Models.Entities.Configuration
{
  public class NoteConfig : IEntityTypeConfiguration<Note>
  {
    public void Configure(EntityTypeBuilder<Note> builder)
    {
      builder.HasKey(prop => prop.Id);

      builder.Property(prop => prop.Title)
        .HasMaxLength(150)
        .IsUnicode(true)
        .IsRequired();

      builder.Property(prop => prop.Description)
        .HasColumnType("text")
        .IsUnicode(true)
        .IsRequired();

      builder.HasOne(prop => prop.Priority)
        .WithMany();

      builder.HasOne(prop => prop.State)
        .WithMany();
    }
  }
}