

using Application.Dto_s.UserDto;
using Domain.Models;

namespace Application.Contracts
{
    public interface IUserRepository
    {
        Task<Guid> AddUser(UserModel userModel);

        Task<bool> ReservedIdentityCode(string identitycode);

        Task<bool> GenderExistance(Guid genderId);
    }
}
