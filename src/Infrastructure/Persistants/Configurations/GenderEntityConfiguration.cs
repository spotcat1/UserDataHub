

namespace Infrastructure.Persistants.Configurations
{
    internal class GenderEntityConfiguration : IEntityTypeConfiguration<GenderEntity>
    {
        public void Configure(EntityTypeBuilder<GenderEntity> builder)
        {
            builder.ToTable("Genders");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired();

            builder.Property(x=>x.IsDeleted)
                .IsRequired();

            builder.HasData(new GenderEntity
            {
                Id = Guid.NewGuid(),
                Title = "مرد"
            }, new GenderEntity
            {
                Id= Guid.NewGuid(),
                Title= "زن"
            });
        }
    }
}
