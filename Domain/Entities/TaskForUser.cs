namespace Domain.Entities
{
    public class TaskForUser
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly CreateDate { get; set; }
        public string CreateHour { get; set; }
        public int CreatorUserId { get; set; }  
        public int SectorId { get; set; }
        public int Status { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
