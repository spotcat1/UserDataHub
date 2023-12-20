using Application.Dto_s.UserDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Guid>> AddUserV1(AddUpdateUserDto dto)
        {
            throw new NotImplementedException();    
        }
    }
}
