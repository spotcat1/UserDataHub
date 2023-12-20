using Domain.Commons;


namespace Domain.Entities
{
    public class CompanyEntity:BaseEntity
    {
        public CompanyEntity()
        {
            CompanyUserJunks = new List<UserCompanyEntityJunk>();
        }
        public required string Name { get; set; }
        public required string Field { get; set; }
        public required string NumberOfEmployees { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsDeleted { get; set; }



        public ICollection<UserCompanyEntityJunk> CompanyUserJunks { get; set; }
    }
}
