using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SQLitePCL;

namespace Infrastructure.Context
{
    public class OrganizetContextLocalFactory : IDesignTimeDbContextFactory<OrganizetContextDbLocal>
    {
        string connectionDefault = @"Data Source=C:\\Users\\Usuário\\Database\\Database.db";        
        public OrganizetContextDbLocal CreateDbContext(string[] args)
        {
            Batteries.Init();
            var optionsBuilder = new DbContextOptionsBuilder<OrganizetContextDbLocal>();

            optionsBuilder.UseSqlite(connectionDefault);
            return new OrganizetContextDbLocal(optionsBuilder.Options);
        }
    }


    public class OrganizetContextServerFactory : IDesignTimeDbContextFactory<OrganizetContextDbServer>
    {
        string connectionSecond = @"Host=localhost;Port=5432;Database=Database;Username=postgres;Password=15975323";
        public OrganizetContextDbServer CreateDbContext(string[] args)
        {
            Batteries.Init();
            var optionsBuilder = new DbContextOptionsBuilder<OrganizetContextDbServer>();

            optionsBuilder.UseNpgsql(connectionSecond);
            return new OrganizetContextDbServer(optionsBuilder.Options);
        }
    }
}
