
namespace Infrastructure.Persistants.Configurations
{
    internal class UserCompanyEntityJunksConfiguration : IEntityTypeConfiguration<UserCompanyEntityJunk>
    {
        public void Configure(EntityTypeBuilder<UserCompanyEntityJunk> builder)
        {
            builder.ToTable("UserCompanyJunks");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IsDeleted)
                .IsRequired();

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.UserCompanyjunks)
                .HasForeignKey(x => x.UserId);

            builder
                .HasOne(x=>x.Company)
                .WithMany(x=>x.CompanyUserJunks)
                .HasForeignKey(x => x.CompanyId);
        }
    }
}
