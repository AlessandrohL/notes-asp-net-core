using Microsoft.EntityFrameworkCore;
using Todo_app.Data;
using Todo_app.Models.Entities;
using Todo_app.Services.Contracts;

namespace Todo_app.Services
{
  public class PriorityService : IPriorityService
  {
    private readonly ApplicationDbContext _context;

    public PriorityService(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<List<Priority>> GetAllPriorities()
    {
      return await _context.Priorities.ToListAsync();
    }
  }
}