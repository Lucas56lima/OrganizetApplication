using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ISectorRepository
    {
        Task<IEnumerable<Sector>> GetAllSectors();
        Task<Sector> GetSectorByName(string name);
        Task<Sector> GetSectorById(int id);
    }
}
