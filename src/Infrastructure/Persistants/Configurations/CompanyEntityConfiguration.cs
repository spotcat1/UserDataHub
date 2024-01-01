

namespace Infrastructure.Persistants.Configurations
{
    internal class CompanyEntityConfiguration : IEntityTypeConfiguration<CompanyEntity>
    {
        public void Configure(EntityTypeBuilder<CompanyEntity> builder)
        {
            builder.ToTable("Companies");

            builder.HasKey(x => x.Id);


            builder.Property(x => x.Name)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x=>x.Field)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x=>x.NumberOfEmployees)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x=>x.CreationDate)
                .IsRequired();

            builder.Property(x=>x.IsDeleted)
                .IsRequired();
        }
    }
}
