using Application.Commands;
using Application.Contracts;
using Application.Dto_s.CarDto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filter;

namespace WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    [CustomActionResultFilter]
    [ExceptionFilter]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICarRepository _carRepository;

        public CarController(IMediator mediator, ICarRepository carRepository)
        {
            _mediator = mediator;
            _carRepository = carRepository;
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Guid>> AddCarV1([FromForm] AddUpdateCarDto dto)
        {


            var ExistUser = await _carRepository.UserExsistance(dto.UserId);

            if (ExistUser)
            {
                var Result = await _mediator.Send(new CreateCarCommand(dto));
                return Ok(Result);
            }

            return Guid.Empty;
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> UpdateCarV1([FromRoute] Guid Id, [FromForm] AddUpdateCarDto dto)
        {
            var CarExistance = await _carRepository.CarExsistance(Id);

            var ExistUser = await _carRepository.UserExsistance(dto.UserId);

            if (CarExistance)
            {
                var Result = await _mediator.Send(new UpdateCarCommand(Id, dto));
                return Ok(Result);
            }

            return "خطا";
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetCarByIdDto>> GetCarByIdV1([FromRoute] Guid Id, [FromQuery] bool? ShowIfIsDeleted)
        {
            throw new NotImplementedException();



        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<List<GetAllCarsDto>>> GetAllCarsV1([FromQuery] string? FirstFilterOn, [FromQuery] string? FirstFilterQuery,
            [FromQuery] string? SecondFilterOn, [FromQuery] string? SecondFilterQuery,
            [FromQuery] string? FirstOrderBy, [FromQuery] bool? FirstIsAscending,
            [FromQuery] bool? ShowDeletedOnes,
            [FromQuery] int PageNumber = 1, [FromQuery] int PageSize = 100)
        {
            throw new NotImplementedException();
        }


        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<string>> DeleteCarV1([FromRoute] Guid Id)
        {
            throw new NotImplementedException();
        }



        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<string>> SoftDeleteCarV1([FromRoute] Guid Id)
        {
            throw new NotImplementedException();
        }



    }
}
