using Todo_app.Models.Entities;

namespace Todo_app.Services.Contracts
{
  public interface IStateService
  {
    Task<List<State>> GetAllStates();
  }
}