namespace Domain.Entities
{
    public class StickNoteTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int TaskId { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
