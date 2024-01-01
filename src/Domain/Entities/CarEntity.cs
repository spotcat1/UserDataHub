
using Domain.Commons;

namespace Domain.Entities
{
    public class CarEntity:BaseEntity
    {
        public Guid? UserId { get; set; }
        public required string Name { get; set; }
        public required string Model { get; set; }

        public required DateTime CreatedDate { get; set; }

        public double Price { get; set; }

        public string? ImagePath { get; set; }
        public bool IsDeleted { get; set; }


        public UserEntity? User { get; set; }

    }
}
