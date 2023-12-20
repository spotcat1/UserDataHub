

using Domain.Commons;

namespace Domain.Models
{
    public class GenderModel:BaseModel
    {
        public GenderModel()
        {
            UserModels = new List<UserModel>();  
        }
        public required string Title { get; set; }

        public bool IsDeleted { get; set; }



        public ICollection<UserModel> UserModels { get; set; }
    }
}
