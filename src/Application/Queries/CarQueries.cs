

using Application.Dto_s.CarDto;
using MediatR;

namespace Application.Queries
{
    public record GetAllCarsQuery(string? FirstFilterOn = null, string? FirstFilterQuery = null,
            string? SecondFilterOn = null, string? SecondFilterQuery = null,
             string? FirstOrderBy = null, bool FirstIsAscending = true,
              int PageNumber = 1, int PageSize = 100) : IRequest<List<GetAllCarsDto>>;

    public record GetCarByIdQuery(Guid Id, bool ShowIfIsDeleted = false) : IRequest<GetCarByIdDto>;
}
