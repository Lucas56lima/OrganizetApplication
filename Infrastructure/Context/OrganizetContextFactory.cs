using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SQLitePCL;

namespace Infrastructure.Context
{
    public class OrganizetContextFactory : IDesignTimeDbContextFactory<OrganizetContextDb>
    {
        string connectionDefault = @"Data Source=Database/Database.db";

        public OrganizetContextDb CreateDbContext(string[] args)
        {
            Batteries.Init();
            var optionsBuilder = new DbContextOptionsBuilder<OrganizetContextDb>();

            optionsBuilder.UseSqlite(connectionDefault);
            return new OrganizetContextDb(optionsBuilder.Options);
        }
    }
}
