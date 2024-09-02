using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class OrganizetContextDb : DbContext
    {
        public OrganizetContextDb(DbContextOptions<OrganizetContextDb> options) : base(options) { }
        public DbSet<TaskForUser> TasksForUsers { get; set; }
        public DbSet<TaskForMany> TasksForMany { get; set; }
        public DbSet<TaskForManySector> TaskForManySectors { get; set; }
        public DbSet<StickNoteTask> StickNoteTasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
