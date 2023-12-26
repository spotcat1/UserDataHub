using Application.Contracts;
using Application.Dto_s.UserDto;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filter;

namespace WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    [CustomActionResultFilter]
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

            var Result = await _user.AddUser(dto);

            return Ok(Result);    
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

            var Result = await _user.UpdateUser(id, dto);

            return Ok(Result);
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

        public async Task<ActionResult<List<GetAllUsersDto>>> GetAllUsersV1([FromQuery] string? FirstFilterOn, [FromQuery] string? FirstFilterQuery,
            [FromQuery] string? SecondFilterOn, [FromQuery] string? SecondFilterQuery,
            [FromQuery] string? FirstOrderBy, [FromQuery] bool? FirstIsAscending,
            [FromQuery] string? SecondOrderBy, [FromQuery] bool? SecondIsAscending,
            [FromQuery] int PageNumber = 1, [FromQuery] int PageSize = 100)
        {
            var Result = await _user.GetAllUsers(FirstFilterOn, FirstFilterQuery, SecondFilterOn,SecondFilterQuery,
                FirstOrderBy,FirstIsAscending?? true,SecondOrderBy,SecondIsAscending?? true,PageNumber,PageSize);

            if (Result == null)
            {
                return BadRequest("کاربری برای نمایش وجود ندارد");
            }

            return Ok(Result);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<string>> SoftDeleteUserV1([FromRoute] Guid id)
        {
            var Result = await _userRepository.SoftDeleteUser(id);    

            if (Result == null)
            {
                return NotFound("کاربر برای حدف منطقی یافت نشد");
            }

            return Ok(Result);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async  Task<ActionResult<string>> DeleteUserV1([FromRoute] Guid id)
        {
            var Result = await _userRepository.DeleteUser(id);

            if (Result == null)
            {
                return "کاربر یافت نشد";
            }


            return Ok(Result);  
        }
    }
}
