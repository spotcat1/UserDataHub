

using Application.Dto_s.CarDto;
using Application.Queries;
using Application.Services.Interfaces;
using MediatR;

namespace Infrastructure.Handlers.CarHandlers
{
    internal class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, GetCarByIdDto>
    {
        private readonly ICar _car;

        public GetCarByIdQueryHandler(ICar car)
        {
            _car = car;
        }

        public async Task<GetCarByIdDto> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            return await _car.GetCarById(request.Id,request.ShowIfIsDeleted);
        }
    }
}
