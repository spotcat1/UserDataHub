

using Microsoft.AspNetCore.Http;

namespace Application.Dto_s.CarDto
{
    public class AddUpdateCarDto
    {
        public Guid UserId { get; set; }
        public required string Name { get; set; }
        public required string Model { get; set; }

        public required string CreatedDate { get; set; }

        public double Price { get; set; }

        public IFormFile? ImageFile { get; set; }
        
        public bool IsDeleted { get; set; }
    }
}
