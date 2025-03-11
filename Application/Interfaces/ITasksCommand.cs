using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITasksCommand
    {
        Task CreateTask(Tasks task);
        Task UpdateTask(Tasks task);
    }
}
