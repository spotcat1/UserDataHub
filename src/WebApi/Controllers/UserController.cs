using Application.Contracts;
using Application.Dto_s.UserDto;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        private readonly IUserRepository _userRepository;

        public UserController(IUser user, IUserRepository userRepositor)
        {
            _user = user;
            _userRepository = userRepositor;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Guid>> AddUserV1([FromForm]AddUpdateUserDto dto)
        {
            var ExistGender = await _userRepository.GenderExistance(dto.GenderId);

            if (!ExistGender)
            {
                return BadRequest("شناسه جنسی یافت نشد");
            }


            var ReservedIdentityCode = await _userRepository.ReservedIdentityCode(dto.Identitycode);

            if (ReservedIdentityCode)
            {
                return BadRequest("کد ملی وارد شده متعلق به شخص دیگری است");
            }

            return await _user.AddUser(dto);    
        }
    }
}
