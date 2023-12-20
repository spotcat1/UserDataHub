
using Domain;
using System.Reflection;

namespace Infrastructure.Persistants
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<GenderEntity> GenderEntites { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<CarEntity> CarEntities { get; set; }
        public DbSet<CompanyEntity> CompanyEntites { get; set; }
        public DbSet<UserCompanyEntityJunk> UserCompanyJunkEntites { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasDefaultSchema(DomainSchema.schema);
            base.OnModelCreating(modelBuilder);
        }


    }
    
}
