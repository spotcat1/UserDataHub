using Application.Contracts;
using Application.Dto_s.UserDto;
using AutoMapper;
using Domain.Models;
using FluentValidation;
using Infrastructure.Persistants;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private const string ImagePath = "images/user";

        public UserRepository(ApplicationDbContext context, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;

        }


        public async Task<Guid> AddUser(UserModel userModel)
        {

            var UploadRootPath = Path.Combine(_webHostEnvironment.WebRootPath, ImagePath);

            if (!Directory.Exists(UploadRootPath))
            {
                Directory.CreateDirectory(UploadRootPath);
            }

            
            if (userModel.ImageFile != null)
            {
                var fileExtension = Path.GetExtension(userModel.ImageFile.FileName);
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                if (!allowedExtensions.Contains(fileExtension, StringComparer.OrdinalIgnoreCase))
                {

                    userModel.ImageFile = null;

                }
            }
       

            var entity = _mapper.Map<UserEntity>(userModel);

            if (userModel.ImageFile is not null && userModel.ImageFile.Length > 0)
            {

                string FileExtension = Path.GetExtension(Path.GetFileName(userModel.ImageFile.FileName));
                string NewFileName = $"user/{Guid.NewGuid().ToString().Replace("-", "")}{FileExtension}";
                var FilePath = Path.Combine(UploadRootPath, NewFileName);
                using (var FileStream = new FileStream(FilePath, FileMode.Create))
                {
                    await userModel.ImageFile.CopyToAsync(FileStream).ConfigureAwait(false);
                }
                entity.ImagePath = $"/{ImagePath}/{NewFileName}";
            }

            await _context.UserEntities.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }
    }
}
