namespace Domain.Models
{
    public class StickNoteViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int TaskId { get; set; }
        public int SectorId {  get; set; }
        public string Sector { get; set; }
        public string Color {  get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
    }
}
