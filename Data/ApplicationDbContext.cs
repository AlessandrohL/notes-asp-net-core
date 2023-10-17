using Microsoft.EntityFrameworkCore;
using Todo_app.Models.Entities;
using Todo_app.Models.Entities.Configuration;

namespace Todo_app.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfiguration(new TagConfig());
      modelBuilder.ApplyConfiguration(new NoteConfig());
      modelBuilder.ApplyConfiguration(new NoteTagConfig());
    }

    public DbSet<Tag> Tags { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<NoteTag> NoteTags { get; set; }
    public DbSet<Priority> Priorities { get; set; }
    public DbSet<State> States { get; set; }
  }
}