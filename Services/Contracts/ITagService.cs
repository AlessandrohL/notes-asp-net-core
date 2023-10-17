using Todo_app.Models.Entities;

namespace Todo_app.Services.Contracts
{
  public interface ITagService
  {
    Task<List<Tag>> GetAllTags();
  }
}