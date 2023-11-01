using Todo_app.Models.Entities;
using Todo_app.Models.ViewModels;

namespace Todo_app.Services.Contracts
{
  public interface INoteService
  {
    Task<List<Note>> GetAllNotes();
    Task<bool> CreateNote(NoteViewModel model);
    Task<bool> DeleteNote(Guid? id);
    Task<Note> FindNoteById(Guid id, bool includeProps);
    Task<bool> UpdateNote(NoteViewModel model);
  }
}