using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VideoGame.Domain.Modules.Auth.Entities;

namespace VideoGame.Infrastructure.Modules.Auth.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder) =>
        builder
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasPrincipalKey(r => r.Id)
            .HasForeignKey(u => u.RoleId)
            .IsRequired(false);
}
