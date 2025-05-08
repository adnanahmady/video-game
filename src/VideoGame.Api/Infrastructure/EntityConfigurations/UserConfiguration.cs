using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VideoGame.Api.Core.Entities;

namespace VideoGame.Api.Infrastructure.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasPrincipalKey(r => r.Id)
            .HasForeignKey(u => u.RoleId)
            .IsRequired(false);
    }
}
