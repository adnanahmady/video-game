using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VideoGame.Domain.Modules.Auth.Entities;

namespace VideoGame.Infrastructure.Modules.Auth.EntityConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder) =>
        builder.HasData(
            new Role()
            {
                Id = 1,
                Name = "Admin"
            },
            new Role()
            {
                Id = 2,
                Name = "User"
            }
        );
}
