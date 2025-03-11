using Application.Interfaces;
using Domain.Entities;
using Infrastructrure.Persistence;
using Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructrure.Command
{
    public class TasksCommand : ITasksCommand
    {
        private readonly CrmDbContext _context;
        public TasksCommand(CrmDbContext context)
        {
            _context = context;
        }

        public async Task CreateTask(Tasks task)
        {
           _context.Tasks.Add(task);
           await _context.SaveChangesAsync();
        }

        public async Task UpdateTask(Tasks task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }
    }
}
