using Application.Contracts;
using Application.Dto_s.UserDto;
using Application.Exceptions;
using Application.Helper;
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
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {

        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private const string ImagePath = "images/user";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(ApplicationDbContext context, IMapper mapper, IWebHostEnvironment webHostEnvironment,
             IHttpContextAccessor httpContextAccessor) : base(context)
        {

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

            //if (userModel.BirthDate.Year < 1800 || userModel.BirthDate.Year > 2023)
            //{
            //    throw new CustomException("خطا در ثبت تاریخ تولد");
            //}


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

            await AddAsync(entity);
            await SaveChangesAsync();

            return entity.Id;
        }


        public async Task<bool> ReservedIdentityCode(string identitycode, Guid id)
        {
            var FoundRegisteredIdentityCode = await Table().AnyAsync(x => x.IdentityCode == identitycode && !x.IsDeleted && x.Id != id);

            if (FoundRegisteredIdentityCode)
            {
                throw new CustomException("کد ملی متعلق به شخص دیگری است");
            }

            return false;
        }

        public async Task<bool> GenderExistance(Guid genderId)
        {
            var FoundGender = await _context.GenderEntites.AnyAsync(x => x.Id == genderId && !x.IsDeleted);

            if (!FoundGender)
            {
                throw new NotFoundException("شناسه جنسیت یافت نشد");
            }

            return true;
        }

        public async Task<bool> UserExistance(Guid UserId)
        {
            var FoundUser = await Table().AnyAsync(x => x.Id == UserId);

            if (!FoundUser)
            {
                throw new NotFoundException("User", UserId);
            }

            return true;
        }

        public async Task<string> UpdateUser(Guid Id, UserModel userModel)
        {
            var UploadRootPath = Path.Combine(_webHostEnvironment.WebRootPath, ImagePath);

            if (!Directory.Exists(UploadRootPath))
            {
                Directory.CreateDirectory(UploadRootPath);
            }

            var foundUserToUpdate = _context.UserEntities.FirstOrDefault(x => x.Id == Id);

            if (foundUserToUpdate == null)
            {
                throw new NotFoundException("User", Id);
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
            foundUserToUpdate.BirthDate = userModel.BirthDate.ConvertToMiladi();
            foundUserToUpdate.IdentityCode = userModel.IdentityCode;
            foundUserToUpdate.Nationality = userModel.Nationality;
            foundUserToUpdate.IsDeleted = userModel.IsDeleted;

            Update(foundUserToUpdate);
            await SaveChangesAsync();
            return "ویرایش با موفقیت انجام شد";

        }



        private void DeleteImage(string path)
        {
            var imagepath = _webHostEnvironment.WebRootPath + path;

            if (File.Exists(imagepath))
            {
                File.Delete(imagepath);
            }
        }

        public async Task<UserModel> GetUserById(Guid Id, bool ShowIfIsDeleted = false)
        {
            var userEntity = await _context.UserEntities.Include(x => x.Gender).FirstOrDefaultAsync(x=>x.Id==Id);

            if (!ShowIfIsDeleted && userEntity != null)
            {
                userEntity= await _context.UserEntities.Include(x => x.Gender).FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted);
            }

            if (userEntity == null)
            {
                throw new NotFoundException("کاربر یافت نشد");
            }

            try
            {
                var userMapped = _mapper.Map<UserModel>(userEntity);
                // Rest of the code after mapping
                if (userMapped.ImageId != null)
                {
                    userMapped.ImageId = BuildAbsoluteUrl(userMapped.ImageId);
                }

                return userMapped;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"An error occurred during mapping: {ex.Message}");
                throw; // Rethrow the exception to propagate it further if needed
            }

       
        }


        public async Task<List<UserModel>> GetAllUsers(string? FirstFilterOn = null, string? FirstFilterQuery = null,
    string? SecondFilterOn = null, string? SecondFilterQuery = null,
    string? FirstOrderBy = null, bool FirstIsAscending = true,
    string? SecondOrderBy = null, bool SecondIsAscending = true, bool ShowDeletedOnes = false,
    int PageNumber = 1, int PageSize = 100)
        {

            var UsersToReturn =  _context.UserEntities.Include(x => x.Gender).AsQueryable(); // Remove AsNoTracking()

            // Filtering
            if (!string.IsNullOrWhiteSpace(FirstFilterOn) && !string.IsNullOrWhiteSpace(FirstFilterQuery))
            {
                if (FirstFilterOn.Equals("نامخانوادگی"))
                {
                    UsersToReturn = UsersToReturn.Where(x => x.LastName.Contains(FirstFilterQuery));
                }
            }

            if (!string.IsNullOrWhiteSpace(SecondFilterOn) && !string.IsNullOrWhiteSpace(SecondFilterQuery))
            {
                if (SecondFilterOn.Equals("نام"))
                {
                    UsersToReturn = UsersToReturn.Where(x => x.FirstName.Contains(SecondFilterQuery));
                }
            }

            // Sorting
            if (!string.IsNullOrWhiteSpace(FirstOrderBy))
            {
                if (FirstOrderBy.Equals("نامخانوادگی"))
                {
                    UsersToReturn = FirstIsAscending ? UsersToReturn.OrderBy(x => x.LastName) : UsersToReturn.OrderByDescending(x => x.LastName);
                }

                if (!string.IsNullOrWhiteSpace(SecondOrderBy))
                {
                    if (SecondOrderBy.Equals("نام") && FirstIsAscending == true)
                    {
                        UsersToReturn = SecondIsAscending
                            ? UsersToReturn.OrderBy(x => x.FirstName)
                            : UsersToReturn.OrderBy(x => x.FirstName);
                    }

                    if (SecondOrderBy.Equals("نام") && !FirstIsAscending)
                    {
                        UsersToReturn = SecondIsAscending
                            ? UsersToReturn.OrderBy(x => x.FirstName)
                            : UsersToReturn.OrderByDescending(x => x.FirstName);
                    }
                }
            }

            // ShowDeletedOnes
            if (!ShowDeletedOnes)
            {
                UsersToReturn = UsersToReturn.Where(x => !x.IsDeleted);
            }

            // Paging
            var SkipResult = (PageNumber - 1) * PageSize;


            try
            {
                var usersList = await UsersToReturn.Include(x => x.Gender).Skip(SkipResult).Take(PageSize).ToListAsync();


                var UsersMapped = _mapper.Map<List<UserModel>>(usersList);

                foreach (var property in UsersMapped)
                {
                    if (property.ImageId != null)
                    {
                        property.ImageId = BuildAbsoluteUrl(property.ImageId);
                    }
                }

                return UsersMapped;
            }
            catch (AutoMapperMappingException ex)
            {
                // Log or handle the AutoMapperMappingException
                // You can access more details about the exception, such as ex.Errors, ex.Context, etc.
                // Log.Error(ex, "An error occurred during AutoMapper mapping");
                throw; // Rethrow the exception to let the caller handle it or log it further
            }
            catch (Exception ex)
            {
                // Handle other exceptions if necessary
                // Log.Error(ex, "An unexpected error occurred");
                throw; // Rethrow the exception to let the caller handle it or log it further
            }


        }



        private string BuildAbsoluteUrl(string relativeImagePath)
        {
            var absoluteUrl = new Uri(_httpContextAccessor.HttpContext.Request.GetDisplayUrl());
            var baseUrl = $"{absoluteUrl.GetLeftPart(UriPartial.Authority)}";
            return $"{baseUrl}{relativeImagePath}";
        }

        public async Task<string> SoftDeleteUser(Guid id)
        {
            var UserToDelete = await GetUserByIdAsync(id);        

            UserToDelete.IsDeleted = true;

            await _context.SaveChangesAsync();

            return "کاربر با موفقیت حذف منطقی شد";

        }



        public async Task<string> DeleteUser(Guid id)
        {
            var userToDelete = await GetUserByIdAsync(id);
         
             Remove(userToDelete);
             await SaveChangesAsync();

             return "کاربر با موفقیت حذف شد";
            
        }
    }
}
