

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistants.Configurations
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}
