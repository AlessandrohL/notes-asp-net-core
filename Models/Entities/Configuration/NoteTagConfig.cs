using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Todo_app.Models.Entities.Configuration
{
  public class NoteTagConfig : IEntityTypeConfiguration<NoteTag>
  {
    public void Configure(EntityTypeBuilder<NoteTag> builder)
    {
      builder.HasKey(nt => new { nt.NoteId, nt.TagId });

      builder
        .HasOne(n => n.Note)
        .WithMany(nt => nt.NoteTags)
        .HasForeignKey(nt => nt.NoteId);

      builder
        .HasOne(n => n.Tag)
        .WithMany(nt => nt.NoteTags)
        .HasForeignKey(nt => nt.TagId);
    }
  }
}