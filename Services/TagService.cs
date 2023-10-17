using Microsoft.EntityFrameworkCore;
using Todo_app.Data;
using Todo_app.Models.Entities;
using Todo_app.Services.Contracts;

namespace Todo_app.Services
{
  public class TagService : ITagService
  {
    private readonly ApplicationDbContext _context;

    public TagService(ApplicationDbContext context)
    {
      _context = context;
    }


    public async Task<List<Tag>> GetAllTags()
    {
      return await _context.Tags.ToListAsync();
    }
  }
}