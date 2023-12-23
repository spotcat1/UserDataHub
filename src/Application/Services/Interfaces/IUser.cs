

using Application.Dto_s.UserDto;

namespace Application.Services.Interfaces
{
    public interface IUser
    {
        Task<Guid> AddUser(AddUpdateUserDto dto);
        Task<string> UpdateUser(Guid id, AddUpdateUserDto dto);
    }
}
