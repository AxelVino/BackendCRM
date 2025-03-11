using Application.Interfaces;
using Domain.Entities;
using Infrastructrure.Persistence;

namespace Infrastructrure.Command
{
    public class ProjectCommand : IProjectCommand
    {
        private readonly CrmDbContext context;
        public ProjectCommand(CrmDbContext context)
        {
            this.context = context;
        }

        public async Task InsertProject(Projects project)
        {
            context.Add(project);
            await context.SaveChangesAsync();
        }

        public async Task UpdateProject(Projects project)
        {
            context.Update(project);
            await context.SaveChangesAsync();
        }
    }
}
