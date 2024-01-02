using Application.Contracts;
using Application.Dto_s.CarDto;
using Application.Exceptions;
using Application.Helper;
using AutoMapper;
using Domain.Models;
using Infrastructure.Persistants;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CarRepository : GenericRepository<CarEntity>, ICarRepository
    {

        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private const string ImagePath = "images/car";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CarRepository(ApplicationDbContext context, IMapper mapper, IWebHostEnvironment webHostEnvironment,
             IHttpContextAccessor httpContextAccessor) : base(context)
        {

            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<Guid> AddCar(CarModel carModel)
        {
            var UploadRootPath = Path.Combine(_webHostEnvironment.WebRootPath, ImagePath);

            if (!Directory.Exists(UploadRootPath))
            {
                Directory.CreateDirectory(UploadRootPath);
            }


            if (carModel.ImageFile != null)
            {
                var FileExtension = Path.GetExtension(carModel.ImageFile.FileName);
                var AllowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                if (!AllowedExtensions.Contains(FileExtension, StringComparer.OrdinalIgnoreCase))
                {

                    carModel.ImageFile = null;

                }

            }

            var entity = _mapper.Map<CarEntity>(carModel);

            if (carModel.ImageFile is not null && carModel.ImageFile.Length > 0)
            {
                var FileExtension = Path.GetExtension(carModel.ImageFile.FileName);
                string NewFileName = $"car_{Guid.NewGuid().ToString().Replace("-", "")}{FileExtension}";
                var FilePath = Path.Combine(UploadRootPath, NewFileName);
                using (var FileStream = new FileStream(FilePath, FileMode.Create))
                {
                    await carModel.ImageFile.CopyToAsync(FileStream).ConfigureAwait(false);
                }
                entity.ImagePath = $"/{ImagePath}/{NewFileName}";
            }


            await AddAsync(entity);
            await SaveChangesAsync();

            return entity.Id;


        }



        public async Task<string> UpdateCar(Guid Id, CarModel carModel)
        {
            var UploadRootPath = Path.Combine(_webHostEnvironment.WebRootPath, ImagePath);

            if (!Directory.Exists(UploadRootPath))
            {
                Directory.CreateDirectory(UploadRootPath);
            }

            var FoundCarToUpdate = await Table().FirstOrDefaultAsync(x => x.Id == Id);


            if (carModel.ImageFile != null)
            {
                var FileExtension = Path.GetExtension(carModel.ImageFile.FileName);
                var AllowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                if (!AllowedExtensions.Contains(FileExtension, StringComparer.OrdinalIgnoreCase))
                {

                    carModel.ImageFile = null;

                }

            }


            if (carModel.ImageFile is not null && carModel.ImageFile.Length > 0)
            {
                string FileExtension = Path.GetExtension(Path.GetFileName(carModel.ImageFile.FileName));

                var NewFileName = $"car_{Guid.NewGuid().ToString().Replace("-", "")}{FileExtension}";
                var FilePath = Path.Combine(UploadRootPath,NewFileName);


                using (var FileStream = new FileStream(FilePath, FileMode.Create))
                {
                    await carModel.ImageFile.CopyToAsync(FileStream).ConfigureAwait(false);
                }

                FoundCarToUpdate.ImagePath = $"/{ImagePath}/{NewFileName}";

                if (string.IsNullOrEmpty(FoundCarToUpdate.ImagePath))
                {
                    DeleteImage(FoundCarToUpdate.ImagePath);
                }
            }
            else
            {
                FoundCarToUpdate.ImagePath =FoundCarToUpdate.ImagePath;
            }

            FoundCarToUpdate.UserId=carModel.UserId;
            FoundCarToUpdate.Name = carModel.Name;
            FoundCarToUpdate.Model = carModel.Model;
            FoundCarToUpdate.CreatedDate = carModel.CreatedDate.ConvertToMiladi();
            FoundCarToUpdate.Price = carModel.Price;    


            Update(FoundCarToUpdate);
            await SaveChangesAsync();
            return "ویرایش با موفقیت انجام شد";


        }

        public Task<string> DeleteCar(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetAllCarsDto>> GetAllCars(string? FirstFilterOn = null, string? FirstFilterQuery = null, string? SecondFilterOn = null, string? SecondFilterQuery = null, string? FirstOrderBy = null, bool FirstIsAscending = true, int pageNumber = 1, int PageSize = 100)
        {
            throw new NotImplementedException();
        }

        public Task<GetCarByIdDto> GetCarById(Guid Id, bool ShowIfIsDeleted = false)
        {
            throw new NotImplementedException();
        }

        public Task<string> SoftDeleteCar(Guid Id)
        {
            throw new NotImplementedException();
        }



        public async Task<bool> UserExsistance(Guid? UserId)
        {
            if (UserId != null)
            {
                var FoundUser = await _context.UserEntities.AnyAsync(x => x.Id == UserId && !x.IsDeleted);
                if (!FoundUser)
                {
                    throw new NotFoundException("کاربر یافت نشد");
                }
            }



            return true;

        }

        public async Task<bool> CarExsistance(Guid CarId)
        {
            var FoundCar = await Table().AnyAsync(x => x.Id == CarId && !x.IsDeleted);

            if (!FoundCar)
            {
                throw new NotFoundException("کاربر یافت نشد");
            }

            return true;
        }


        private void DeleteImage(string path)
        {
            var imagepath = _webHostEnvironment.WebRootPath + path;

            if (File.Exists(imagepath))
            {
                File.Delete(imagepath);
            }
        }
    }
}
