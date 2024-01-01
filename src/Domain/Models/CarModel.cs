

using Domain.Commons;
using Microsoft.AspNetCore.Http;

namespace Domain.Models
{
    public class CarModel : BaseModel
    {
        public Guid UserId { get; set; }

        public string? UserLastName {get;set;}
        public string? UserIdentityCode {get;set;}
        public required string Name { get; set; }
        public required string Model { get; set; }

        public required string  CreatedDate { get; set; }

        public double Price { get; set; }

        public IFormFile? ImageFile { get; set; }
        public string? ImagePath { get; set; }
        public bool IsDeleted { get; set; }


        
    }
}
