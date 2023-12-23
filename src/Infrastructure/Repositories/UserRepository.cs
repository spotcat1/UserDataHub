using Application.Contracts;
using Application.Dto_s.UserDto;
using AutoMapper;
using Domain.Entities;
using Domain.Models;
using FluentValidation;
using Infrastructure.Persistants;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(ApplicationDbContext context, IMapper mapper, IWebHostEnvironment webHostEnvironment,
             IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
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
                string NewFileName = $"user_{Guid.NewGuid().ToString().Replace("-", "")}{FileExtension}";
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


        public async Task<bool> ReservedIdentityCode(string identitycode)
        {
            return await _context.UserEntities.AnyAsync(x => x.IdentityCode == identitycode && !x.IsDeleted);
        }

        public async Task<bool> GenderExistance(Guid genderId)
        {
            return await _context.GenderEntites.AnyAsync(x => x.Id == genderId && !x.IsDeleted);
        }

        public async Task<bool> UserExistance(Guid UserId)
        {
            return await _context.UserEntities.AnyAsync(x => x.Id == UserId && !x.IsDeleted);
        }

        public async Task<string> UpdateUser(Guid Id, UserModel userModel)
        {
            var UploadRootPath = Path.Combine(_webHostEnvironment.WebRootPath, ImagePath);

            if (!Directory.Exists(UploadRootPath))
            {
                Directory.CreateDirectory(UploadRootPath);
            }

            var foundUserToUpdate = _context.UserEntities.FirstOrDefault(x => x.Id == Id && !x.IsDeleted);

            if (foundUserToUpdate == null)
            {
                return "کاربر یافت نشد";
            }

            if (_context.GenderEntites.Any(g => g.Id == userModel.GenderId)) // Check if GenderId is valid
            {
                if (userModel.ImageFile is not null && userModel.ImageFile.Length > 0)
                {
                    string FileExtension = Path.GetExtension(Path.GetFileName(userModel.ImageFile.FileName));
                    string NewFileName = $"user_{Guid.NewGuid().ToString().Replace("-", "")}{FileExtension}";
                    var FilePath = Path.Combine(UploadRootPath, NewFileName);

                    using (var FileStream = new FileStream(FilePath, FileMode.Create))
                    {
                        await userModel.ImageFile.CopyToAsync(FileStream).ConfigureAwait(false);
                    }

                    foundUserToUpdate.ImagePath = $"/{ImagePath}/{NewFileName}";

                    if (!string.IsNullOrEmpty(foundUserToUpdate.ImagePath))
                    {
                        DeleteImage(foundUserToUpdate.ImagePath);
                    }
                }
                else
                {
                    foundUserToUpdate.ImagePath = foundUserToUpdate.ImagePath;
                }

                foundUserToUpdate.GenderId = userModel.GenderId;
                foundUserToUpdate.FirstName = userModel.FirstName;
                foundUserToUpdate.LastName = userModel.LastName;
                foundUserToUpdate.BirthDate = userModel.BirthDate;
                foundUserToUpdate.IdentityCode = userModel.IdentityCode;
                foundUserToUpdate.Nationality = userModel.Nationality;

                var entity = _context.Entry(foundUserToUpdate);
                entity.State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return "ویرایش با موفقیت انجام شد";
            }
            else
            {
                return "Invalid GenderId";
            }
        }



        private void DeleteImage(string path)
        {
            var imagepath = _webHostEnvironment.WebRootPath + path;

            if (File.Exists(imagepath))
            {
                File.Delete(imagepath);
            }
        }

        public async Task<UserModel> GetUserById(Guid Id)
        {
            var UserToReturn = await _context.UserEntities
                .AsNoTracking() // so the DB does not track the entity because we want to modify the ImagePath
                .FirstOrDefaultAsync(x=>x.Id==Id && !x.IsDeleted);


            if (UserToReturn == null)
            {
                return null;
            }



            var UserToReturnMapped = new UserModel
            {

                GenderId = UserToReturn.GenderId,
                FirstName = UserToReturn.FirstName,
                LastName = UserToReturn.LastName,
                IdentityCode = UserToReturn.IdentityCode,
                BirthDate = UserToReturn.BirthDate,
                ImageId = UserToReturn.ImagePath,
                Nationality = UserToReturn.Nationality,
            };

            

            if (UserToReturnMapped.ImageId != null)
            {
                UserToReturnMapped.ImageId = BuildAbsoluteUrl(UserToReturnMapped.ImageId);
            }

            return  UserToReturnMapped;
        }


        public async Task<List<UserModel>> GetAllUsers()
        {
            var UsersToReturn = await _context.UserEntities.AsNoTracking().Where(x=>!x.IsDeleted)
                .ToListAsync();

            if (UsersToReturn == null)
            {
                return null;
            }


            var UsersMapped = _mapper.Map<List<UserModel>>(UsersToReturn);
           
            

            foreach (var property in UsersMapped)
            {
                if (property.ImageId !=null)
                {
                    property.ImageId = BuildAbsoluteUrl(property.ImageId);  
                }
            }

            return UsersMapped;
        }


        private string BuildAbsoluteUrl(string relativeImagePath)
        {
            var absoluteUrl = new Uri(_httpContextAccessor.HttpContext.Request.GetDisplayUrl());
            var baseUrl = $"{absoluteUrl.GetLeftPart(UriPartial.Authority)}";
            return $"{baseUrl}{relativeImagePath}";
        }

        public async Task<string> SoftDeleteUser(Guid id)
        {
            var UserToDelete = await _context.UserEntities.FirstOrDefaultAsync(x => x.Id == id);

            if (UserToDelete == null)
            {
                return null;
            }

            UserToDelete.IsDeleted = true;

            await _context.SaveChangesAsync();

            return "کاربر با موفقیت حذف منطقی شد";

        }
    }
}
