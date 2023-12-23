﻿

using Application.Dto_s.UserDto;
using Domain.Models;

namespace Application.Contracts
{
    public interface IUserRepository
    {
        Task<Guid> AddUser(UserModel userModel);

        Task<string> UpdateUser(Guid Id,UserModel userModel);

        Task<bool> ReservedIdentityCode(string identitycode);

        Task<bool> GenderExistance(Guid genderId);

        Task<bool> UserExistance(Guid UserId);
    }
}
