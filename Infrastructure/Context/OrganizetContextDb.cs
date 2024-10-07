using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class OrganizetContextDbLocal : DbContext
    {
        public OrganizetContextDbLocal(DbContextOptions<OrganizetContextDbLocal> options) : base(options)
        {
        }

        public DbSet<TaskForUser> TasksForUsers { get; set; }
        public DbSet<TaskForManySector> TasksForManySectors { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<TaskForMany> TasksForMany { get; set; }
        public DbSet<StickNoteTaskForMany> SticksNotesTasksForMany { get; set; }
        public DbSet<StickNoteTaskForUser> StickNotesTasksForUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sector>()
                .HasIndex(s => s.Name)
                .IsUnique();
            modelBuilder.Entity<Sector>().HasData
                (
                    new Sector { Id = 1, Name = "Fiscal", Color = "#DA70D6", ColorHover = "#8B008B", IsActive = true },
                    new Sector { Id = 2, Name = "Financeiro", Color = "#32CD32", ColorHover = "#006400", IsActive = true },
                    new Sector { Id = 3, Name = "Compras", Color = "#4169E1", ColorHover = "#191970", IsActive = true },
                    new Sector { Id = 4, Name = "Suporte TI", Color = "#00008B", ColorHover = "#483D8B", IsActive = true },
                    new Sector { Id = 5, Name = "Planejamento", Color = "#836FFF", ColorHover = "#6A5ACD", IsActive = true },
                    new Sector { Id = 6, Name = "Marketing", Color = "#9370DB", ColorHover = "#7B68EE", IsActive = true },
                    new Sector { Id = 7, Name = "Recursos Humanos", Color = "#FF8C00", ColorHover = "#FF4500", IsActive = true }
                );
            modelBuilder.Entity<Status>()
                .HasIndex(s => s.Name)
                .IsUnique();
            modelBuilder.Entity<Status>().HasData
                (
                    new Status { Id = 1, Name = "Para Fazer", IsActive = true },
                    new Status { Id = 2, Name = "Em Andamento", IsActive = true },
                    new Status { Id = 3, Name = "Concluído", IsActive = true }
                );
        }
    }

    public class OrganizetContextDbServer : DbContext
    {
        public OrganizetContextDbServer(DbContextOptions<OrganizetContextDbServer> options) : base(options)
        {
        }

        public DbSet<TaskForUserBackUp> TasksForUsers { get; set; }
        public DbSet<TaskForManySector> TasksForManySectors { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<TaskForMany> TasksForMany { get; set; }
        public DbSet<StickNoteTaskForMany> SticksNotesTasksForMany { get; set; }
        public DbSet<StickNoteTaskForUserBackUp> StickNotesTasksForUsers { get; set; }
        public DbSet<UserBackUp> Users { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Notification>Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sector>()
                .HasIndex(s => s.Name)
                .IsUnique();

            modelBuilder.Entity<Sector>().HasData
                (
                    new Sector { Id = 1, Name = "Fiscal", Color = "#DA70D6", ColorHover = "#8B008B", IsActive = true },
                    new Sector { Id = 2, Name = "Financeiro", Color = "#32CD32", ColorHover = "#006400", IsActive = true },
                    new Sector { Id = 3, Name = "Compras", Color = "#4169E1", ColorHover = "#191970", IsActive = true },
                    new Sector { Id = 4, Name = "Suporte TI", Color = "#00008B", ColorHover = "#483D8B", IsActive = true },
                    new Sector { Id = 5, Name = "Planejamento", Color = "#836FFF", ColorHover = "#6A5ACD", IsActive = true },
                    new Sector { Id = 6, Name = "Marketing", Color = "#9370DB", ColorHover = "#7B68EE", IsActive = true },
                    new Sector { Id = 7, Name = "Recursos Humanos", Color = "#FF8C00", ColorHover = "#FF4500", IsActive = true }
                );
            modelBuilder.Entity<Status>()
                .HasIndex(s => s.Name)
                .IsUnique();
            modelBuilder.Entity<Status>().HasData
                (
                    new Status { Id = 1, Name = "Para Fazer", IsActive = true },
                    new Status { Id = 2, Name = "Em Andamento", IsActive = true },
                    new Status { Id = 3, Name = "Concluído", IsActive = true }
                );
            modelBuilder.Entity<TaskForUserBackUp>()
                .Property(t => t.CreateDate)
                .HasColumnType("date");
            modelBuilder.Entity<TaskForMany>()
                .Property(t => t.CreateDate)
                .HasColumnType("date");
            modelBuilder.Entity<Notification>()
                .Property(t => t.CreateDate)
                .HasColumnType("date");
        }
    }
}
