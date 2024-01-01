

using Microsoft.AspNetCore.Http;

namespace Application.Dto_s.UserDto
{
    public class GetAllUsersDto
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Identitycode { get; set; }
        public required string BirthDate { get; set; }
        public string? ImageFile { get; set; }
        public string? Nationality { get; set; }

        public required string GenderTitle { get; set; }
    }
}
