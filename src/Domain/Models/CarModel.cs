

using Domain.Commons;

namespace Domain.Models
{
    public class CarModel:BaseModel
    {
        public Guid UserId { get; set; }
        public required string Name { get; set; }
        public required string Model { get; set; }

        public required string  CreatedDate { get; set; }

        public double Price { get; set; }

        public string? ImagePath { get; set; }
        public bool IsDeleted { get; set; }


        
    }
}
