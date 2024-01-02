

using Application.Dto_s.CarDto;
using Application.Queries;
using Application.Services.Interfaces;
using MediatR;

namespace Infrastructure.Handlers.CarHandlers
{
    internal class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, List<GetAllCarsDto>>
    {
        private readonly ICar _car;

        public GetAllCarsQueryHandler(ICar car)
        {
            _car = car;
        }

        public Task<List<GetAllCarsDto>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            return _car.GetAllCars(request.FirstFilterOn, request.FirstFilterQuery,
            request.SecondFilterOn, request.SecondFilterQuery,
            request.FirstOrderBy, request.FirstIsAscending,
            request.PageNumber,request.PageSize);
        }
    }
}
