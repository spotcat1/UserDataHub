using Application.Dto_s.CarDto;
using Domain.Entities;
using Domain.Models;

namespace Application.Contracts
{
    public interface ICarRepository : IGenericRepository<CarEntity>
    {
        Task<Guid> AddCar(CarModel carModel);
        Task<string> UpdateCar(Guid Id, CarModel carModel);
        Task<GetCarByIdDto> GetCarById(Guid Id, bool ShowIfIsDeleted = false);

        Task<List<GetAllCarsDto>> GetAllCars(string? FirstFilterOn = null, string? FirstFilterQuery = null,
            string? SecondFilterOn = null, string? SecondFilterQuery = null,
            string? FirstOrderBy = null, bool FirstIsAscending = true,
            int pageNumber = 1, int PageSize = 100);

        Task<string> DeleteCar(Guid Id);

        Task<string> SoftDeleteCar(Guid Id);

        Task<bool> UserExsistance(Guid? UserId);
        Task<bool> CarExsistance(Guid CarId);
    }
}
