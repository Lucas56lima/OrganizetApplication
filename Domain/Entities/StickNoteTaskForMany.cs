namespace Domain.Entities
{
    public class StickNoteTaskForMany
    {
        public int Id { get; set; }        
        public string Content { get; set; }
        public int TaskId { get; set; }
        public int SectorId {  get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
