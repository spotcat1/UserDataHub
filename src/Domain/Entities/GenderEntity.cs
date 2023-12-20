

using Domain.Commons;

namespace Domain.Entities
{
    public class GenderEntity:BaseEntity
    {
        public GenderEntity()
        {
            Users = new List<UserEntity>();
        }
        public required string Title { get; set; }

        public bool IsDeleted { get; set; } 
        public ICollection<UserEntity> Users { get; set; }
    }
}
