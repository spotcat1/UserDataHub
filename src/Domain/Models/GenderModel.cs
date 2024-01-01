

using Domain.Commons;

namespace Domain.Models
{
    public class GenderModel:BaseModel
    {
       
        public required string Title { get; set; }

        public bool IsDeleted { get; set; }



       
    }
}
