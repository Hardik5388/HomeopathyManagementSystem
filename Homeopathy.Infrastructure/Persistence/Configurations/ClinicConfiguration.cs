using Homeopathy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Infrastructure.Persistence.Configurations
{
    public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.ToTable("Clinics");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ClinicCode)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.RegistrationNumber)
                .HasMaxLength(100);

            builder.Property(x => x.Email)
                .HasMaxLength(150);

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(x => x.AddressLine1)
                .HasMaxLength(250);

            builder.Property(x => x.AddressLine2)
                .HasMaxLength(250);

            builder.Property(x => x.City)
                .HasMaxLength(100);

            builder.Property(x => x.State)
                .HasMaxLength(100);

            builder.Property(x => x.Country)
                .HasMaxLength(100);

            builder.Property(x => x.PostalCode)
                .HasMaxLength(20);

            builder.Property(x => x.Website)
                .HasMaxLength(250);

            builder.Property(x => x.Logo)
                .HasMaxLength(500);

            builder.Property(x => x.RowVersion)
                .IsRowVersion();

            builder.HasIndex(x => x.ClinicCode).IsUnique();

            builder.HasIndex(x => x.Name);

            builder.HasMany(x => x.Doctors)
                .WithOne(x => x.Clinic)
                .HasForeignKey(x => x.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
