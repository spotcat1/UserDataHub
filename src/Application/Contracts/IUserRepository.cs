

using Application.Dto_s.UserDto;
using Domain.Entities;
using Domain.Models;

namespace Application.Contracts
{
    public interface IUserRepository:IGenericRepository<UserEntity>
    {
        Task<Guid> AddUser(UserModel userModel);

        Task<string> UpdateUser(Guid Id,UserModel userModel);

        Task<bool> ReservedIdentityCode(string identitycode,Guid id);

        Task<bool> GenderExistance(Guid genderId);

        Task<bool> UserExistance(Guid UserId);

        Task<UserModel> GetUserById(Guid Id, bool ShowIfIsDeleted = false);

        Task<List<UserModel>> GetAllUsers(string? FirstFilterOn = null , string? FirstFilterQuery = null,
            string? SecondFilterOn = null , string? SecondFilterQuery = null,
            string? FirstOrderBy = null, bool FirstIsAscending = true,
            string? SecondOrderBy = null,bool SecondIsAscending = true,bool ShowDeletedOnes = false, 
            int pageNumber = 1 , int PageSize = 100);

        Task<string> SoftDeleteUser(Guid id);

        Task<string> DeleteUser(Guid id);
    }
}
