

using Application.Contracts;
using Application.Dto_s.CarDto;
using Application.Services.Interfaces;
using Domain.Models;

namespace Application.Services.Implementations
{
    public class Car : ICar
    {
        private readonly ICarRepository _carRepository;

        public Car(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Guid> AddCar(AddUpdateCarDto dto)
        {
            var CarModel = new CarModel
            {
                Name = dto.Name,
                Model=dto.Model,
                CreatedDate=dto.CreatedDate,
                Price=dto.Price,
                ImageFile=dto.ImageFile,
            };

            //business logic

            return await _carRepository.AddCar(CarModel);
        }



        public async Task<string> UpdateCar(Guid Id, AddUpdateCarDto dto)
        {
            var CarInstanceModel = new CarModel
            {
                Name = dto.Name,
                Model = dto.Model,
                CreatedDate = dto.CreatedDate,
                Price = dto.Price,
                ImageFile = dto.ImageFile,
                UserId = dto.UserId
            };

            //business logic

            return await _carRepository.UpdateCar(Id, CarInstanceModel);
        }

        public Task<List<GetAllCarsDto>> GetAllCars(string? FirstFilterOn = null, string? FirstFilterQuery = null, string? SecondFilterOn = null, string? SecondFilterQuery = null, string? FirstOrderBy = null, bool FirstIsAscending = true, int PageNumber = 1, int PageSize = 100)
        {
            throw new NotImplementedException();
        }

        public Task<GetCarByIdDto> GetCarById(Guid Id, bool ShowIfIsDeleted = false)
        {
            throw new NotImplementedException();
        }

      
    }
}
