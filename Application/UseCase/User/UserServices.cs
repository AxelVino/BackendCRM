using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.UseCase.User
{
    public class UserServices: IUserServices
    {
        private readonly IUserQuery _query;
        private readonly IUsersMapper _mapper;
        public UserServices(IUserQuery query, IUsersMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        public async Task<Users> GetUserById(int id)
        {
            var user = await _query.GetUserById(id);
            if (user == null)
            {
                throw new ExceptionBadRequest("Incorrect data entered, try again.");
            }
            return user;
        }

        public async Task<List<UserResponse>> GetUserList()
        {
            return await _mapper.GetAllUsersResponse(await _query.GetUserList());
        }
    }
}
