using System;

namespace Domain.Entities
{
    public class TaskForUser
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatorUserId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
