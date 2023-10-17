using Todo_app.Models.Entities;

namespace Todo_app.Services.Contracts
{
  public interface IPriorityService
  {
    Task<List<Priority>> GetAllPriorities();
  }
}