using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserServices
    {
        Task<List<UserResponse>> GetUserList();
        Task<Users> GetUserById(int id);
    }
}
