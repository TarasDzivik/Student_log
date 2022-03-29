using Back.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Data.Models.ContextConfigurationParts
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                .HasMaxLength(80)
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(c => c.Title)
                .HasMaxLength(300)
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(c => c.TitleImagePath);

            builder.Property(c => c.DateOdStart)
                .HasColumnName("Starts since")
                .HasColumnType("date")
                .IsRequired();
        }
    }
}
