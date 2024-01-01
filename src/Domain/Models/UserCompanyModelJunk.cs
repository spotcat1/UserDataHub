
using Domain.Commons;

namespace Domain.Models
{
    public class UserCompanyModelJunk:BaseModel
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }

        public bool IsDeleted { get; set; }


  
    }
}
