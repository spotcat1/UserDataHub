
namespace Infrastructure.Persistants.Configurations
{
    internal class CarEntityConfiguration : IEntityTypeConfiguration<CarEntity>
    {
        public void Configure(EntityTypeBuilder<CarEntity> builder)
        {
            builder.ToTable("Cars");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Model)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .IsRequired();

            builder.Property(x => x.ImagePath)
                .HasMaxLength(5000)
                .IsRequired(false);

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsRequired();

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.UserId);



        }
    }
}
