namespace Todo_app.Models.Entities
{
  public class NoteTag
  {
    public Guid NoteId { get; set; }
    public Note Note { get; set; }

    public int TagId { get; set; }
    public Tag Tag { get; set; }
  }
}