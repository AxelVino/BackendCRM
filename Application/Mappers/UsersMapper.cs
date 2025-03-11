using Application.Interfaces.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class UsersMapper : IUsersMapper
    {
        public async Task<List<UserResponse>> GetAllUsersResponse(List<Users> users)
        {
            List<UserResponse> newList = new List<UserResponse>();
            foreach (var user in users)
            {
                var response = new UserResponse
                {
                    Id = user.UserID,
                    Name = user.Name,
                    Email = user.Email,
                };
                newList.Add(response);
            }
            return await Task.FromResult(newList);
        }

        public Task<UserResponse> GetUserResponse(Users user)
        {
            var response = new UserResponse
            {
                Id = user.UserID,
                Name = user.Name,
                Email = user.Email,
            };
            return Task.FromResult(response);
        }
    }
}
