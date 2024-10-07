namespace Domain.Entities
{
    public class StickNoteTaskForUserBackUp
    {        
        public int Id { get; set; }
        public int StickNoteId {  get; set; }
        public string Content { get; set; }
        public int TaskId { get; set; }
        public int SectorId { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string Status { get; set; }
        public bool IsActive { get; set; } = true;
        
    }
}
