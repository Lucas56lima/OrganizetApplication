using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TaskForUserRepository(OrganizetContextDbLocal context, OrganizetContextDbServer contextServer) : ITaskForUserRepository
    {
        private readonly OrganizetContextDbLocal _context = context;
        private readonly OrganizetContextDbServer _contextServer = contextServer;

        public async Task<TaskForUser> GetTaskForUserById(int idTaskForUser)
        {
            try
            {
                var taskForManyDb = await _context.TasksForUsers
                            .Where(u => u.Id == idTaskForUser && u.IsActive == true)
                            .FirstOrDefaultAsync();

                return taskForManyDb;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<TaskForUser> GetTaskForUserByTitle(string titleTaskForTitle)
        {
            try
            {
                var taskForManyDb = await _context.TasksForUsers
                            .Where(u => u.Title == titleTaskForTitle && u.IsActive == true)
                            .FirstOrDefaultAsync();

                return taskForManyDb;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<IEnumerable<TaskViewModel>> GetTasksForUser()
        {
            try
            {
                return await _context.TasksForUsers
                            .Join(_context.Sectors,
                            taskForUser => taskForUser.Status,
                            sector => sector.Id,
                            (taskForUser, sector) => new { taskForUser, sector })
                            .Join(_context.Status,
                            combined => combined.taskForUser.Status,
                            status => status.Id,
                            (combined, status) => new TaskViewModel
                            {
                                Id = combined.taskForUser.Id,
                                Title = combined.taskForUser.Title,
                                CreateDate = combined.taskForUser.CreateDate,
                                Sector = combined.sector.Name,
                                Status = status.Name
                            })
                            .Where(u => u.Status != "Concluído")
                            .OrderByDescending(x => x.CreateDate)
                            .ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<IEnumerable<TaskViewModel>> GetTasksForUserCompleted(DateOnly initalDate, DateOnly endDate)
        {
            try
            {
                return await _context.TasksForUsers
                            .Join(_context.Sectors,
                            taskForUser => taskForUser.Status,
                            sector => sector.Id,
                            (taskForUser, sector) => new { taskForUser, sector })
                            .Join(_context.Status,
                            combined => combined.taskForUser.Status,
                            status => status.Id,
                            (combined, status) => new TaskViewModel
                            {
                                Id = combined.taskForUser.Id,
                                Title = combined.taskForUser.Title,
                                CreateDate = combined.taskForUser.CreateDate,
                                Sector = combined.sector.Name,
                                Status = status.Name
                            })
                            .Where(u => u.Status == "Concluído" && u.CreateDate >= initalDate && u.CreateDate <= endDate)
                            .OrderByDescending(x => x.CreateDate)
                            .ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }

        public async Task<TaskForUser> PostTaskForUser(TaskForUser taskforUser)
        {
            try
            {
                await _context.TasksForUsers.AddAsync(taskforUser);
                await _context.SaveChangesAsync();

                TaskForUser newTaskForUser = new TaskForUser
                {                    
                    Title = taskforUser.Title,
                    Description = taskforUser.Description,
                    CreatorUserId = taskforUser.CreatorUserId,
                    CreateDate = taskforUser.CreateDate,
                    SectorId = taskforUser.SectorId,
                    Status = taskforUser.Status,
                    IsActive = true
                };
                //TaskForUserBackUp newTaskForUser
                //await _contextServer.TasksForUsers.AddAsync(newTaskForUser);
                //await _contextServer.SaveChangesAsync();
                return taskforUser;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco", ex);
            }
        }
               
    }
}
