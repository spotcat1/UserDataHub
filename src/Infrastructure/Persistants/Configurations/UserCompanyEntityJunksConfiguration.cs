
namespace Infrastructure.Persistants.Configurations
{
    internal class UserCompanyEntityJunksConfiguration : IEntityTypeConfiguration<UserCompanyEntityJunk>
    {
        public void Configure(EntityTypeBuilder<UserCompanyEntityJunk> builder)
        {
            builder.ToTable("UserCompanyJunks");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId)
                .IsRequired(false);

            builder.Property(x => x.CompanyId)
                .IsRequired(false);

            builder.Property(x => x.IsDeleted)
                .IsRequired();

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.UserCompanyjunks)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x=>x.Company)
                .WithMany(x=>x.CompanyUserJunks)
                .HasForeignKey(x => x.CompanyId);
        }
    }
}
