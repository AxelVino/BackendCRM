using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProjectCommand
    {
        Task InsertProject(Projects project); 
        Task UpdateProject(Projects project);

    }
}
