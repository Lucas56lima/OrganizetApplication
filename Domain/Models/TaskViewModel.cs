namespace Domain.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateOnly CreateDate { get; set; }
        public string CreateHour { get; set; }
        public int CreatorUserId { get; set; }
        public int SectorId { get; set; }
        public string Sector { get; set; }
        public string Color { get; set; }
        public string ColorHover { get; set; }
        public string Status { get; set; }
    }
}
