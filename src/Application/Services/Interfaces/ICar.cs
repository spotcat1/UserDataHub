

using Application.Dto_s.CarDto;

namespace Application.Services.Interfaces
{
    public interface ICar
    {
        Task<Guid> AddCar(AddUpdateCarDto dto);
        Task<string> UpdateCar(Guid Id,AddUpdateCarDto dto);

        Task<GetCarByIdDto> GetCarById(Guid Id, bool ShowIfIsDeleted = false);

        Task<List<GetAllCarsDto>> GetAllCars(string? FirstFilterOn = null, string? FirstFilterQuery = null,
            string? SecondFilterOn = null, string? SecondFilterQuery = null,
             string? FirstOrderBy = null, bool FirstIsAscending = true,
              int PageNumber = 1, int PageSize = 100);
    }
}
