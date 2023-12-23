using Application.Contracts;
using Application.Dto_s.UserDto;
using Application.Services.Interfaces;
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Guid>> AddUserV1([FromForm]AddUpdateUserDto dto)
        {
            var ExistGender = await _userRepository.GenderExistance(dto.GenderId);

            if (!ExistGender)
            {
                return NotFound(" جنسیت یافت نشد");
            }


            var ReservedIdentityCode = await _userRepository.ReservedIdentityCode(dto.IdentityCode);

            if (ReservedIdentityCode)
            {
                return BadRequest("کد ملی وارد شده متعلق به شخص دیگری است");
            }

            return Ok(await _user.AddUser(dto));    
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<string>> UpdateuserV1([FromRoute] Guid id , [FromForm] AddUpdateUserDto dto)
        {
            var ExistUser =await  _userRepository.UserExistance(id);

            if (!ExistUser)
            {
                return NotFound("کاربر یافت نشد");
            }

            var ExistGender = await _userRepository.GenderExistance(dto.GenderId);

            if (!ExistGender)
            {
                return NotFound("جنسیت یافت نشد");

            }

            var ReservedIdentityCode =await _userRepository.ReservedIdentityCode(dto.IdentityCode);

            if (ReservedIdentityCode)
            {
                return BadRequest("کد ملی متعلق به شخص دیگری است");
            }

            return Ok(await _user.UpdateUser(id, dto));
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        
        public async Task<ActionResult<AddUpdateUserDto>> GetUserByIdV1([FromRoute] Guid id)
        {
            var Result = await _user.GetUserById(id);
            
            if (Result == null)
            {
                return BadRequest("کاربر یافت نشد");
            }

            return Ok(Result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<List<GetAllUsersDto>>> GetAllUsersV1()
        {
            var Result = await _user.GetAllUsers();

            if (Result == null)
            {
                return BadRequest("کاربری برای نمایش وجود ندارد");
            }

            return Ok(Result);
        }
    }
}
