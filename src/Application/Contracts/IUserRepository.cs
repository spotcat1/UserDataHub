

using Application.Dto_s.UserDto;
using Domain.Models;

namespace Application.Contracts
{
    public interface IUserRepository
    {
        Task<Guid> AddUser(UserModel userModel);

        Task<string> UpdateUser(Guid Id,UserModel userModel);

        Task<bool> ReservedIdentityCode(string identitycode,Guid id);

        Task<bool> GenderExistance(Guid genderId);

        Task<bool> UserExistance(Guid UserId);

        Task<UserModel> GetUserById(Guid Id);

        Task<List<UserModel>> GetAllUsers(string? FirstFilterOn = null , string? FirstFilterQuery = null,
            string? SecondFilterOn = null , string? SecondFilterQuery = null,
            string? FirstOrderBy = null, bool FirstIsAscending = true,
            string? SecondOrderBy = null,bool SecondIsAscending = true,
            int pageNumber = 1 , int PageSize = 100);

        Task<string> SoftDeleteUser(Guid id);

        Task<string> DeleteUser(Guid id);
    }
}
