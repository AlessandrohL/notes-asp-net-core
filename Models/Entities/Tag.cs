namespace Todo_app.Models.Entities
{
  public class Tag
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<NoteTag> NoteTags { get; set; }
  }
}