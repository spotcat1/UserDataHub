

using Microsoft.AspNetCore.Http;

namespace Application.Dto_s.UserDto
{
    public class GetUserbyId
    {
        public Guid GenderId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Identitycode { get; set; }
        public DateTime BirthDate { get; set; }
        public string? ImageFile { get; set; }
        public string? Nationality { get; set; }
    }
}
