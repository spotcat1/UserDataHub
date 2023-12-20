using Application.Contracts;
using Application.Dto_s.UserDto;
using Domain.Models;
using FluentValidation;
using Infrastructure.Persistants;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<Guid> AddUser(UserModel userModel)
        {
            throw new NotImplementedException();
        }
    }
}
