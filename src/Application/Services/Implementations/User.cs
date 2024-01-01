﻿

using Application.Contracts;
using Application.Dto_s.UserDto;
using Application.Exceptions;
using Application.Services.Interfaces;
using Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace Application.Services.Implementations
{
    public class User : IUser
    {
        //private readonly IValidator<AddUpdateUserDto> _validator;
        private readonly IUserRepository _userRepository;

        public User( IUserRepository userRepository)
        {
            //_validator = validator;
            _userRepository = userRepository;

        }

        public async Task<Guid> AddUser(AddUpdateUserDto dto)
        {

            //if (dto.FirstName != null)
            //{
            //    dto.FirstName = Regex.Replace(dto.FirstName.Trim(), @"\s+", " ");
            //}

            //if (dto.LastName != null)
            //{
            //    dto.LastName = Regex.Replace(dto.LastName.Trim(), @"\s+", " ");
            //}

            if (dto.IdentityCode != null)
            {
                dto.IdentityCode = RemoveSpaces(dto.IdentityCode);
            }

            //if (dto.Nationality != null)
            //{
            //    dto.Nationality = Regex.Replace(dto.Nationality.Trim(), @"\s+", " ");
            //}



            //var ValidationResult = _validator.Validate(dto);

            //if (!ValidationResult.IsValid)
            //{
            //    throw new CustomValidationException(ValidationResult.Errors);
            //}





            var UserInstanceModel = new UserModel
            {
                GenderId = dto.GenderId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                IdentityCode = dto.IdentityCode,
                BirthDate = dto.BirthDate,
                ImageFile = dto.ImageFile,
                Nationality = dto.Nationality,
                IsDeleted = dto.IsDeleted,

            };

            // business logic


            return await _userRepository.AddUser(UserInstanceModel);
        }

        public async Task<string> UpdateUser(Guid id, AddUpdateUserDto dto)
        {


            //if (dto.FirstName != null)
            //{
            //    dto.FirstName = Regex.Replace(dto.FirstName.Trim(), @"\s+", " ");
            //}

            //if (dto.LastName != null)
            //{
            //    dto.LastName = Regex.Replace(dto.LastName.Trim(), @"\s+", " ");
            //}

            if (dto.IdentityCode != null)
            {
                dto.IdentityCode = RemoveSpaces(dto.IdentityCode);
            }

            //if (dto.Nationality != null)
            //{
            //    dto.Nationality = Regex.Replace(dto.Nationality.Trim(), @"\s+", " ");
            //}



            //var ValidationResult = _validator.Validate(dto);

            //if (!ValidationResult.IsValid)
            //{
            //    throw new CustomValidationException(ValidationResult.Errors);
            //}





            var UserInstanceModel = new UserModel
            {
                GenderId = dto.GenderId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                IdentityCode = dto.IdentityCode,
                BirthDate = dto.BirthDate,
                ImageFile = dto.ImageFile,
                Nationality = dto.Nationality,
                IsDeleted = dto.IsDeleted,

            };


            return await _userRepository.UpdateUser(id, UserInstanceModel);


        }



        public string RemoveSpaces(string input)
        {
            return input.Replace(" ", "");
        }

        public async Task<GetUserbyIdDto> GetUserById(Guid id,bool ShowIdIsDeleted = false)
        {
            var UserToReturn = await _userRepository.GetUserById(id,ShowIdIsDeleted);

          

            var UserToReturnDto = new GetUserbyIdDto
            {
                GenderTitle = UserToReturn.Gender.Title,
                FirstName = UserToReturn.FirstName,
                LastName = UserToReturn.LastName,
                BirthDate = UserToReturn.BirthDate,
                Identitycode = UserToReturn.IdentityCode,
                Nationality = UserToReturn.Nationality,
                ImageFile = UserToReturn.ImageId,
            };

            return UserToReturnDto;
        }

        public async Task<List<GetAllUsersDto>> GetAllUsers(string? FirstFilterOn = null, string? FirstFilterQuery = null,
            string? SecondFilterOn = null, string? SecondFilterQuery = null, string? FirstOrderBy = null, bool FirstIsAscending = true,
            string? SecondOrderBy = null, bool SecondIsAscending = true,bool ShowDeletedOnes = false,
            int PageNumber = 1, int PageSize = 100)
        {
            if (FirstFilterOn != null)
            {
                FirstFilterOn = RemoveSpaces(FirstFilterOn);

                if (FirstFilterQuery != null)
                {
                    FirstFilterQuery = RemoveSpaces(FirstFilterQuery);
                }
            }


            if (SecondFilterOn != null)
            {
                SecondFilterOn = RemoveSpaces(SecondFilterOn);

                if (SecondFilterQuery != null)
                {
                    SecondFilterQuery = RemoveSpaces(SecondFilterQuery);
                }
            }

            if (FirstOrderBy != null)
            {
                FirstOrderBy = RemoveSpaces(FirstOrderBy);
            }

            if (SecondOrderBy != null)
            {
                SecondOrderBy = RemoveSpaces(SecondOrderBy);
            }
          






            var UsersToReturn = await _userRepository.GetAllUsers(FirstFilterOn, FirstFilterQuery, SecondFilterOn, SecondFilterQuery,FirstOrderBy,FirstIsAscending,
                SecondOrderBy,SecondIsAscending, ShowDeletedOnes,PageNumber,PageSize);
            var listOfUsersDto = new List<GetAllUsersDto>();
            foreach (var user in UsersToReturn)
            {
                var Users = new GetAllUsersDto()
                {
                    Id = user.Id,
                    GenderTitle = user.UserGenderName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    BirthDate = user.BirthDate,
                    Identitycode = user.IdentityCode,
                    Nationality = user.Nationality,
                    ImageFile = user.ImageId,
                };
                listOfUsersDto.Add(Users);
            }

            return listOfUsersDto;
        }
    }
}
