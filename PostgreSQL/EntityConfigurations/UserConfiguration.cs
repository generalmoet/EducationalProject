using Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Persistence.PostgreSQL.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.Id).IsUnique();
        builder.Property(u => u.Email).HasMaxLength(20);
        builder.Property(u => u.Name).IsRequired();
        builder.Property(u => u.Surname).IsRequired();
        builder.Property(u => u.Birthday).IsRequired();
        builder.Property(u => u.Email).IsRequired();
    }
}
