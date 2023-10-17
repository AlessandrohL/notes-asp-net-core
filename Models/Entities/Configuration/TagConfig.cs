using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Todo_app.Models.Entities.Configuration
{
  public class TagConfig : IEntityTypeConfiguration<Tag>
  {
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
      builder.HasKey(prop => prop.Id);

      builder.Property(prop => prop.Name)
        .HasMaxLength(50)
        .IsRequired();

      builder.Property(prop => prop.Description)
        .IsRequired();
    }
  }
}