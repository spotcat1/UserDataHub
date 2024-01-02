
using Domain.Commons;
using Microsoft.AspNetCore.Http;

namespace Domain.Models
{
    public class UserModel:BaseModel
    {
        public UserModel()
        {
            Companies = new List<UserCompanyModelJunk>();

        }
        public Guid GenderId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string IdentityCode { get; set; }

        public string BirthDate { get; set; }

        public IFormFile? ImageFile { get; set; }
        public string? ImageId { get; set; }    

        public string? Nationality { get; set; }

        public bool IsDeleted { get; set; }

        public string GenderEntityTitle { get; set; }

        

      

        public GenderModel Gender { get; set; }

        public ICollection<CarModel> Cars { get; set; }
        
        public ICollection<UserCompanyModelJunk> Companies { get; set; }


      
    }
}
