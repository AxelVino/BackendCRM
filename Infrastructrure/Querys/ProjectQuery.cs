using Application.Interfaces;
using Domain.Entities;
using Infrastructrure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructrure.Querys
{
    public class ProjectQuery : IProjectQuery
    {
        private readonly CrmDbContext _context;

        public ProjectQuery(CrmDbContext context)
        {
            _context = context;
        }
        public async Task<Projects> GetProjectById(Guid id)
        {
            return await _context.Projects.FirstOrDefaultAsync(p => p.ProjectID == id);
        }

        public async Task<Projects> GetProjectByName(string name)
        {
            return await _context.Projects.FirstOrDefaultAsync(p => p.ProjectName == name);
        }

        public async Task<Projects> GetProjectByTaskId(Guid id)
        {
            Projects searchedProject = null;
            bool flag = false;
            List<Projects> list = await _context.Projects.Include(p => p.Tasks).ToListAsync();
            for (int i = 1; i <= list.Count; i++)
            {
                Projects project = list[i-1];
                if (project.Tasks == null || project.Tasks.Count == 0) // Verificar si es null o está vacía
                {
                    continue;
                }
                foreach (var task in project.Tasks)
                {
                    if (task.TaskID == id)
                    {
                        searchedProject = project;
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
            }

            return searchedProject;
        }

        public async Task<List<Projects>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<List<Projects>> GetProjectsList(string? name, int? campaign, int? client, int? offset, int? size)
        {
            var query = _context.Projects.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(a => a.ProjectName.Contains(name));
            }
            if (campaign.HasValue)
            {
                query = query.Where(a => a.CampaignType == campaign.Value);
            }
            if (client.HasValue)
            {
                query = query.Where(a => a.ClientID == client.Value);
            }

            // Establece un valor predeterminado si offset o size no están definidos
            var pageSize = size.GetValueOrDefault(10); // Valor predeterminado de 10
            var pageOffset = offset.GetValueOrDefault(0); // Valor predeterminado de 0

            query = query.Skip(pageOffset).Take(pageSize);

            return await query.ToListAsync();
        }

    }
}
