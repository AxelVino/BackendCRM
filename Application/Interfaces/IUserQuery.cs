using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserQuery
    {
        Task<List<Users>> GetUserList();
        Task<Users> GetUserById(int id);
    }
}
