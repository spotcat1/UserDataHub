
using Domain.Commons;

namespace Domain.Models
{
    public class UserModel:BaseModel
    {
        public UserModel()
        {
            CarModels = new List<CarModel>();
            UserCompanyModelJunks = new List<UserCompanyModelJunk>();
        }
        public Guid GenderId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string IdentityCode { get; set; }

        public DateTime BirthDate { get; set; }

        public string? ImagePath { get; set; }

        public string? Nationality { get; set; }

        public bool IsDeleted { get; set; }





        public required GenderModel Gender { get; set; }
        public ICollection<CarModel> CarModels { get; set; }

        public ICollection<UserCompanyModelJunk> UserCompanyModelJunks { get; set; }
    }
}
