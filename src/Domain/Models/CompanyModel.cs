

using Domain.Commons;

namespace Domain.Models
{
    public class CompanyModel:BaseModel
    {
       
        public required string Name { get; set; }
        public required string Field { get; set; }
        public required string NumberOfEmployees { get; set; }

        public required string CreationDate { get; set; }

        public bool IsDeleted { get; set; }


        
    }
}
