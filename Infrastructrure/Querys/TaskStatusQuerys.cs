using Application.Interfaces;
using Infrastructrure.Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Exceptions;

namespace Infrastructrure.Querys
{
    public class TaskStatusQuerys : ITaskStatusQuerys
    {
        private readonly CrmDbContext _context;
        public TaskStatusQuerys(CrmDbContext context) 
        {
            _context = context;
        }

        public async Task<Domain.Entities.TaskStatus> GetTaskStatusById(int statusId)
        {
            return await _context.TaskStatus
                .FirstOrDefaultAsync(p => p.Id == statusId);
        }

        public async Task<List<Domain.Entities.TaskStatus>> GetTaskStatusList()
        {
            return await _context.TaskStatus.ToListAsync();
        }
    }
}
