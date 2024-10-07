namespace Domain.Entities
{
    public class TaskForManySector
    {   
        public int Id { get; set; }  
        public int TaskId { get; set; }
        public int SectorId { get; set; }
        public int Status {  get; set; }
        public bool IsActive { get; set; } = true;
    }
}
