using Domain.Commons;


namespace Domain.Entities
{
    public class UserCompanyEntityJunk:BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }

        public bool IsDeleted { get; set; }




        public UserEntity? User { get; set; }
        public CompanyEntity? Company { get; set; }  
    }
}
