using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TaskForManySectorRepository(OrganizetContextDbLocal context, OrganizetContextDbServer contextServer) : ITaskForManySectorRepository
    {
        private readonly OrganizetContextDbLocal _context = context;
        private readonly OrganizetContextDbServer _contextServer = contextServer;
        public async Task <IEnumerable<TaskViewModel>> GetTaskForManySectorByTaskId(int idTaskForMany)
        {
            try
            {
                var taskForManyDb = await _context.TasksForManySectors                                
                                .Join(_context.TasksForMany,
                                    taskForManySectors => taskForManySectors.TaskId,
                                    taskForMany => taskForMany.Id,
                                    (taskForManySectors, taskForMany) => new { taskForManySectors, taskForMany })
                                .Join(_context.Sectors,
                                    combined => combined.taskForManySectors.SectorId,
                                    sector => sector.Id,
                                    (combined, sector) => new { combined, sector })
                                .Join(_context.Status,
                                    combinedWithSector => combinedWithSector.combined.taskForManySectors.Status,
                                    status => status.Id,
                                    (combinedWithSector, status) => new TaskViewModel
                                    {
                                        Id = combinedWithSector.combined.taskForMany.Id,
                                        Title = combinedWithSector.combined.taskForMany.Title,
                                        CreateDate = combinedWithSector.combined.taskForMany.CreateDate,
                                        CreatorUserId = combinedWithSector.combined.taskForMany.CreatorUserId,
                                        SectorId = combinedWithSector.sector.Id,
                                        Sector = combinedWithSector.sector.Name,
                                        Color = combinedWithSector.sector.Color,
                                        ColorHover = combinedWithSector.sector.ColorHover,
                                        Status = status.Name // Corrigido para atribuir status.Name
                                    })
                                .Where(u => u.Id == idTaskForMany)
                                .OrderByDescending(x => x.CreateDate)
                                .ToListAsync();

                return taskForManyDb;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<IEnumerable<TaskViewModel>> GetTaskForManySector(int sectorId)
        {
            try
            {
                var taskForManyDb = await _contextServer.TasksForManySectors
                               .Join(_contextServer.TasksForMany,
                                   taskForManySectors => taskForManySectors.TaskId,
                                   taskForMany => taskForMany.Id,
                                   (taskForManySectors, taskForMany) => new { taskForManySectors, taskForMany })
                               .Join(_contextServer.Sectors,
                                   combined => combined.taskForManySectors.SectorId,
                                   sector => sector.Id,
                                   (combined, sector) => new { combined, sector })
                               .Join(_contextServer.Status,
                                   combinedWithSector => combinedWithSector.combined.taskForManySectors.Status,
                                   status => status.Id,
                                   (combinedWithSector, status) => new TaskViewModel
                                   {
                                       Id = combinedWithSector.combined.taskForMany.Id,
                                       Title = combinedWithSector.combined.taskForMany.Title,
                                       CreateDate = combinedWithSector.combined.taskForMany.CreateDate,
                                       CreatorUserId = combinedWithSector.combined.taskForMany.CreatorUserId,
                                       SectorId = combinedWithSector.sector.Id,
                                       Sector = combinedWithSector.sector.Name,
                                       Color = combinedWithSector.sector.Color,
                                       ColorHover = combinedWithSector.sector.ColorHover,
                                       Status = status.Name // Corrigido para atribuir status.Name
                                   })
                               .Where(u => u.SectorId == sectorId && u.Status != "Concluído")
                               .OrderByDescending(x => x.Id)
                               .ToListAsync();
                return taskForManyDb;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }       

        public async Task<TaskForManySector> PostTaskForManySector(TaskForManySector taskforManySector)
        {
            try
            {
                await _context.TasksForManySectors.AddAsync(taskforManySector);
                await _context.SaveChangesAsync();
                await _contextServer.TasksForManySectors.AddAsync(taskforManySector);
                await _contextServer.SaveChangesAsync();
                return taskforManySector;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }

        }

        public async Task<IEnumerable<int>> GetSectorsByTaskId(int idTask)
        {
            try
            {
                var sectors = await _context.TasksForManySectors
                        .Where(u => u.TaskId == idTask)
                        .Select(u => u.SectorId)
                        .ToListAsync();

                return sectors;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<IEnumerable<TaskViewModel>> GetTasksForManySectorCompleted(int sectorId, DateOnly initialDate, DateOnly endDate)
        {
            try
            {
                var taskForManyDb = await _context.TasksForManySectors
                               .Join(_context.TasksForMany,
                                   taskForManySectors => taskForManySectors.TaskId,
                                   taskForMany => taskForMany.Id,
                                   (taskForManySectors, taskForMany) => new { taskForManySectors, taskForMany })
                               .Join(_context.Sectors,
                                   combined => combined.taskForManySectors.SectorId,
                                   sector => sector.Id,
                                   (combined, sector) => new { combined, sector })
                               .Join(_context.Status,
                                   combinedWithSector => combinedWithSector.combined.taskForManySectors.Status,
                                   status => status.Id,
                                   (combinedWithSector, status) => new TaskViewModel
                                   {
                                       Id = combinedWithSector.combined.taskForMany.Id,
                                       Title = combinedWithSector.combined.taskForMany.Title,
                                       CreateDate = combinedWithSector.combined.taskForMany.CreateDate,
                                       CreateHour = combinedWithSector.combined.taskForMany.CreateHour,
                                       CreatorUserId = combinedWithSector.combined.taskForMany.CreatorUserId,
                                       SectorId = combinedWithSector.sector.Id,
                                       Sector = combinedWithSector.sector.Name,
                                       Color = combinedWithSector.sector.Color,
                                       ColorHover = combinedWithSector.sector.ColorHover,
                                       Status = status.Name 
                                   })
                               .Where(u => u.SectorId == sectorId && u.Status == "Concluído"
                               && u.CreateDate >= initialDate && u.CreateDate <= endDate)
                               .OrderByDescending(x => x.Id)
                               .ToListAsync();
                return taskForManyDb;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }
    }
}
