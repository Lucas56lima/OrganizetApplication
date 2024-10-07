namespace Domain.Entities
{
    public class UserBackUp
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int SectorId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
