using Application.Interfaces;
using Domain.Entities;
using Infrastructrure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructrure.Querys
{
    public class TasksQuery : ITasksQuery
    {
        private readonly CrmDbContext _context;
        public TasksQuery(CrmDbContext context)
        {
            _context = context;
        }

        public async Task<Tasks> GetTaskById(Guid taskId)
        {
            return await _context.Tasks
                .FirstOrDefaultAsync(g => g.TaskID == taskId);
        }

        public async Task<List<Tasks>> GetTasksList(Guid projectid)
        {
            return await _context.Tasks
                .Include(p => p.Users)
                .Include(p => p.TaskStatus)
                .Where(p => p.ProjectID == projectid).ToListAsync();
        }
    }
}
