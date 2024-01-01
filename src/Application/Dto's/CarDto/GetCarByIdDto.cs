

namespace Application.Dto_s.CarDto
{
    public class GetCarByIdDto
    {
        public string? UserLastName { get; set; }
        public string? UserIdentityCode { get; set; }
        public required string Name { get; set; }
        public required string Model { get; set; }

        public required string CreatedDate { get; set; }

        public double Price { get; set; }

        
        public string? ImagePath { get; set; }
        public bool IsDeleted { get; set; }
    }
}
