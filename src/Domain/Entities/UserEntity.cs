
using Domain.Commons;

namespace Domain.Entities
{
    public class UserEntity:BaseEntity
    {

        public UserEntity()
        {
            Cars = new List<CarEntity>();
            UserCompanyjunks = new List<UserCompanyEntityJunk>();
        }
        public required Guid GenderId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string IdentityCode { get; set; }

        public required DateTime BirthDate { get; set; }

        public string? ImagePath { get; set; }

        public string? Nationality { get; set; }

        public bool IsDeleted { get; set; }


        
        public required GenderEntity Gender { get; set; }

        public ICollection<CarEntity> Cars { get; set; }

        public ICollection<UserCompanyEntityJunk> UserCompanyjunks { get; set;}
    }
}
