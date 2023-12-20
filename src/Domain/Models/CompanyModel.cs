

using Domain.Commons;

namespace Domain.Models
{
    public class CompanyModel:BaseModel
    {
        public CompanyModel()
        {
            CompanyUserModelJunks = new List<UserCompanyModelJunk>();
        }
        public required string Name { get; set; }
        public required string Field { get; set; }
        public required string NumberOfEmployees { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsDeleted { get; set; }


        public ICollection<UserCompanyModelJunk> CompanyUserModelJunks { get; set; }
    }
}
