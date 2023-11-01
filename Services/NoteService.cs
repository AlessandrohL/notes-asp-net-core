using System.Text.Encodings.Web;
using Microsoft.EntityFrameworkCore;
using Todo_app.Data;
using Todo_app.Models.Entities;
using Todo_app.Models.ViewModels;
using Todo_app.Services.Contracts;

namespace Todo_app.Services
{
  public class NoteService : INoteService
  {
    private readonly ApplicationDbContext _context;

    public NoteService(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<List<Note>> GetAllNotes()
    {
      return await _context.Notes
        .AsNoTracking()
        .OrderByDescending(n => n.DateCreated)
        .Where(n => !n.IsDeleted)
        .Include(n => n.State)
        .Include(n => n.Priority)
        .Include(n => n.NoteTags)
           .ThenInclude(nt => nt.Tag)
        .ToListAsync();
    }

    public async Task<bool> CreateNote(NoteViewModel model)
    {
      Note note = new Note()
      {
        Title = HtmlEncoder.Default.Encode(model.Title),
        Description = HtmlEncoder.Default.Encode(model.Description),
        DateCreated = DateTime.Now,
        ExpirationDate = model.ExpirationDate,
        PriorityId = model.PriorityId,
        StateId = model.StateId,
      };

      if (model.TagsIds != null && model.TagsIds.Any())
      {
        note.NoteTags = model.TagsIds
            .Select(tagId => new NoteTag { TagId = tagId })
            .ToList();
      };

      _context.Add(note);
      int correct = await _context.SaveChangesAsync();

      return correct > 0;
    }

    public async Task<bool> UpdateNote(NoteViewModel model)
    {
      if (!model.Id.HasValue) return false;

      Note note = await FindNoteById(model.Id.Value, true);

      if (note is null) return false;

      Note noteValues = new Note
      {
        Id = model.Id.Value,
        Title = HtmlEncoder.Default.Encode(model.Title),
        Description = HtmlEncoder.Default.Encode(model.Description),
        ExpirationDate = model.ExpirationDate,
        DateCreated = note.DateCreated,
        PriorityId = model.PriorityId,
        StateId = model.StateId,
      };

      _context.Entry(note).CurrentValues.SetValues(noteValues);

      note.NoteTags = model.TagsIds
        .Select(id => new NoteTag { TagId = id })
        .ToList();

      int rowsAffected = await _context.SaveChangesAsync();

      return rowsAffected > 0;
    }

    public async Task<bool> DeleteNote(Guid? id)
    {
      if (!id.HasValue) return false;

      Note note = await FindNoteById(id.Value, false);

      if (note is null) return false;

      note.IsDeleted = true;
      await _context.SaveChangesAsync();

      return true;
    }

    public async Task<Note> FindNoteById(Guid id, bool includeProps)
    {
      if (!includeProps)
      {
        return await _context.Notes
        .Where(n => n.Id == id)
        .FirstOrDefaultAsync();
      }

      return await _context.Notes
        .Where(n => n.Id == id)
        .Include(n => n.State)
        .Include(n => n.Priority)
        .Include(n => n.NoteTags)
          .ThenInclude(nt => nt.Tag)
        .FirstOrDefaultAsync();
    }

    public async Task<int> Count()
    {
      return await _context.Notes.CountAsync();
    }
  }
}