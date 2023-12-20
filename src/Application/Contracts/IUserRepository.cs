

using Application.Dto_s.UserDto;
using Domain.Models;

namespace Application.Contracts
{
    public interface IUserRepository
    {
        Task<Guid> AddUser(UserModel userModel);
    }
}
