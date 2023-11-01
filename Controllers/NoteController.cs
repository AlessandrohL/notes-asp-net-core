using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Todo_app.Models;
using Todo_app.Models.Entities;
using Todo_app.Models.ViewModels;
using Todo_app.Services.Contracts;
using Todo_app.Services;
using System.Text.Encodings.Web;

namespace Todo_app.Controllers;

public class NoteController : Controller
{
    private readonly INoteService _noteService;
    private readonly IPriorityService _priorityService;
    private readonly IStateService _stateService;
    private readonly ITagService _tagService;

    public NoteController(
        INoteService noteService,
        IPriorityService priorityService,
        IStateService stateService,
        ITagService tagService
        )
    {
        _noteService = noteService;
        _priorityService = priorityService;
        _stateService = stateService;
        _tagService = tagService;
    }

    public async Task<IActionResult> Index()
    {
        List<Note> notes = await _noteService.GetAllNotes();
        return View(notes);
    }

    public async Task<IActionResult> Create()
    {
        List<Priority> priorities = await _priorityService.GetAllPriorities();
        List<State> states = await _stateService.GetAllStates();
        List<Tag> tags = await _tagService.GetAllTags();

        ViewBag.Priorities = new SelectList(priorities, "Id", "Name");
        ViewBag.States = new SelectList(states, "Id", "Name");
        ViewBag.Tags = new SelectList(tags, "Id", "Name");

        return View(new NoteViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(NoteViewModel model)
    {
        if (ModelState.IsValid)
        {
            bool created = await _noteService.CreateNote(model);

            TempData["statusNote"] = created
            ? "Nota creada correctamente"
            : "Ha ocurrido un error";

            return RedirectToAction("Index");
        }

        List<Priority> priorities = await _priorityService.GetAllPriorities();
        List<State> states = await _stateService.GetAllStates();
        List<Tag> tags = await _tagService.GetAllTags();

        ViewBag.Priorities = new SelectList(priorities, "Id", "Name");
        ViewBag.States = new SelectList(states, "Id", "Name");
        ViewBag.Tags = new SelectList(tags, "Id", "Name");

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        bool noteDeleted = await _noteService.DeleteNote(id);

        TempData["statusNote"] = noteDeleted
            ? "Nota eliminada correctamente"
            : "No se pudo eliminar la nota";

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        Note note = await _noteService.FindNoteById(id, true);

        if (note is null) return RedirectToAction("Index");

        List<Priority> priorities = await _priorityService.GetAllPriorities();
        List<State> states = await _stateService.GetAllStates();
        List<Tag> tags = await _tagService.GetAllTags();

        ViewBag.Priorities = new SelectList(priorities, "Id", "Name");
        ViewBag.States = new SelectList(states, "Id", "Name");
        ViewBag.Tags = new SelectList(tags, "Id", "Name");

        var model = new NoteViewModel
        {
            Id = note.Id,
            Title = note.Title,
            Description = note.Description,
            ExpirationDate = note.ExpirationDate,
            PriorityId = note.PriorityId,
            StateId = note.StateId,
            TagsIds = note.NoteTags
                .Select(nt => nt.TagId)
                .ToList()
        };

        return View("Create", model);
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Update(NoteViewModel model)
    {
        bool noteUpdated = await _noteService.UpdateNote(model);

        TempData["statusNote"] = noteUpdated
            ? "Nota actualizada correctamente"
            : "No se pudo actualizar la nota";

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Detail(Guid id)
    {
        Note note = await _noteService.FindNoteById(id, true);

        if (note is null) return NotFound(new { Status = "404", Error = "Nota no encontrada" });

        object noteObj = new
        {
            Title = note.Title,
            Description = note.Description,
            DateCreated = note.DateCreated,
            ExpirationDate = note.ExpirationDate,
            Priority = note.Priority,
            State = note.State,
            Tags = note.NoteTags
                .Select(nt => nt.Tag)
                .Select(t => new
                {
                    Name = t.Name,
                    Description = t.Description
                })
                .ToList()
        };

        return Json(noteObj);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
