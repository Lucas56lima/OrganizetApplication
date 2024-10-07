using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Infrastructure.Repositories
{
    public class SectorRepository(OrganizetContextDbLocal context,OrganizetContextDbServer contextServer) : ISectorRepository
    {
        private readonly OrganizetContextDbLocal _context = context;
        private readonly OrganizetContextDbServer _contextServer = contextServer;
        public async Task<IEnumerable<Sector>> GetAllSectors()
        {
            var sectors = await _context.Sectors
                        .Where(u => u.IsActive == true)
                        .ToListAsync();

            return sectors;
        }

        public async Task<Sector> GetSectorById(int id)
        {

            var sector = await _context.Sectors
                         .Where(u => u.Id == id && u.IsActive == true)
                         .FirstOrDefaultAsync();
            return sector;
        }

        public async Task<Sector> GetSectorByName(string name)
        {
            var sector = await _context.Sectors
                         .Where(u => u.Name == name && u.IsActive == true)
                         .FirstOrDefaultAsync();
            return sector;
        }
    }
}
