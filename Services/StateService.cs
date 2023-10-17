using Microsoft.EntityFrameworkCore;
using Todo_app.Data;
using Todo_app.Models.Entities;
using Todo_app.Services.Contracts;

namespace Todo_app.Services
{
  public class StateService : IStateService
  {

    private readonly ApplicationDbContext _context;

    public StateService(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<List<State>> GetAllStates()
    {
      return await _context.States.ToListAsync();
    }
  }
}