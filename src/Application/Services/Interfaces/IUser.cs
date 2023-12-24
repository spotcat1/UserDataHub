﻿

using Application.Dto_s.UserDto;

namespace Application.Services.Interfaces
{
    public interface IUser
    {
        Task<Guid> AddUser(AddUpdateUserDto dto);
        Task<string> UpdateUser(Guid id, AddUpdateUserDto dto);

        Task<GetUserbyIdDto> GetUserById(Guid id);

        Task<List<GetAllUsersDto>> GetAllUsers(string? FirstFilterOn = null ,string? FisFilterQuery = null,
            string? SecondFilterOn = null , string? SecondFilterQuery = null );
    }
}
