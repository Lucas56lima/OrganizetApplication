namespace Domain.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Message { get; set; }
        public int SectorId {  get; set; }
        public string Color { get; set; }
        public string ColorHover { get; set; }
        public DateOnly CreateDate { get; set; }
        public string CreateHour { get; set; }
        public bool IsRead { get; set; } = false;
        public bool IsNew { get; set; } = true;
        public bool IsActive { get; set; } = true;
    }
}
