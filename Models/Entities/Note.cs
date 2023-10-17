namespace Todo_app.Models.Entities
{
  public class Note
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public int PriorityId { get; set; }
    public Priority Priority { get; set; }
    public int StateId { get; set; }
    public State State { get; set; }
    public bool IsDeleted { get; set; } = false;
    public List<NoteTag> NoteTags { get; set; }
  }
}