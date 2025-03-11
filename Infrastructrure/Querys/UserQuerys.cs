using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infrastructrure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructrure.Querys
{
    public class UserQuerys : IUserQuery
    {
        private readonly CrmDbContext _context;
        public UserQuerys (CrmDbContext context)
        {
            _context = context;
        }

        public async Task<Users> GetUserById(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(p => p.UserID == id);
        }

        public async Task<List<Users>> GetUserList()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
