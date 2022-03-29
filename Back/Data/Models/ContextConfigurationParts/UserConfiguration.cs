using Back.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Data.ContextConfigurationParts
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(s => s.Name)
                .HasMaxLength(20)
                .HasColumnType("nvarchar")
                .IsConcurrencyToken();

            builder.Property(s => s.LastName)
                .HasMaxLength(20)
                .HasColumnType("nvarchar")
                .HasColumnName("Last Name")
                .IsConcurrencyToken();

            builder.Property(s => s.Age)
                .IsConcurrencyToken();

            builder.Property(s => s.Email)
                .HasMaxLength(50)
                .IsConcurrencyToken();

            builder.Property(s => s.RegisteredDate)
                .ValueGeneratedOnAdd()
                .HasColumnName("Registered Date")
                .IsConcurrencyToken();
        }
    }
}