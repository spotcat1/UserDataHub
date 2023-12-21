

using Application.Contracts;
using Application.Dto_s.UserDto;
using Application.Services.Interfaces;
using Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Implementations
{
    public class User : IUser
    {
        private readonly IValidator<AddUpdateUserDto> _validator;
        private readonly IUserRepository _userRepository;

        public User(IValidator<AddUpdateUserDto> validator, IUserRepository userRepository)
        {
            _validator = validator;
            _userRepository = userRepository;
        }

        public async Task<Guid> AddUser(AddUpdateUserDto dto)
        {

            dto.FirstName = RemoveSpaces(dto.FirstName);
            dto.LastName = RemoveSpaces(dto.LastName);
            dto.Identitycode = RemoveSpaces(dto.Identitycode);

            if (dto.Nationality != null)
            {
                dto.Nationality = RemoveSpaces(dto.Nationality);
            }
            


            var ValidationResult = _validator.Validate(dto);

            if (!ValidationResult.IsValid)
            {
                throw new Exception(string.Join(",", ValidationResult.Errors.Select(x => x.ErrorMessage)));
            }

            

            var UserInstanceModel = new UserModel
            {
                GenderId = dto.GenderId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                IdentityCode = dto.Identitycode,
                BirthDate = dto.BirthDate,
                ImageFile = dto.ImageFile,
                Nationality = dto.Nationality,

            };

            // business logic


            return await _userRepository.AddUser(UserInstanceModel);
        } 




        public string RemoveSpaces(string input)
        {
            return input.Replace(" ", "");
        }

       
    }
}
