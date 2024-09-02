namespace Domain.Entities
{
    public class TaskForManySector
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int CreatorTaskId { get; set; }
        public string TaskSector { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
