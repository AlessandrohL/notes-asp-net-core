using System.ComponentModel.DataAnnotations;

namespace Todo_app.Models.ViewModels
{
  public class NoteViewModel
  {
    public Guid? Id { get; set; }

    [Required(ErrorMessage = "El título es obligatorio.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria.")]
    public string Description { get; set; }

    public DateTime? ExpirationDate { get; set; }

    [Required(ErrorMessage = "Seleccione una prioridad.")]
    public int PriorityId { get; set; }

    [Required(ErrorMessage = "Seleccione un estado.")]
    public int StateId { get; set; }

    public List<int> TagsIds { get; set; }
  }
}