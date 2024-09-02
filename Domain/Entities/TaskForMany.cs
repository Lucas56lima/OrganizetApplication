namespace Domain.Entities
{
    public class TaskForMany
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatorUserId { get; set; }
        public required string Sector {  get; set; }
        public bool IsActive { get; set; } = true;
    }
}
