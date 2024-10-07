using Domain.Entities;
using Domain.Interfaces;
using System.Xml.Linq;

namespace Service.Services
{
    public class SectorService : ISectorService
    {
        private readonly ISectorRepository _sectorRepository;
        public SectorService(ISectorRepository sectorRepository)
        {
            _sectorRepository = sectorRepository;
        }

        public async Task<IEnumerable<Sector>> GetAllSectors()
        {
            var sectors = await _sectorRepository.GetAllSectors();
            if(sectors == null)
            {
                return Enumerable.Empty<Sector>();
            }

            return sectors;
        }

        public async Task<Sector> GetSectorById(int id)
        {
            return await _sectorRepository.GetSectorById(id);
        }

        public async Task<Sector> GetSectorByName(string name)
        {
            return await _sectorRepository.GetSectorByName(name);
        }
    }
}
