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
    public sealed class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PatientCode)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.AlternatePhoneNumber)
                .HasMaxLength(20);

            builder.Property(x => x.Email)
                .HasMaxLength(150);

            builder.Property(x => x.Occupation)
                .HasMaxLength(100);

            builder.Property(x => x.BloodGroup)
                .HasMaxLength(10);

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

            builder.Property(x => x.EmergencyContactName)
                .HasMaxLength(150);

            builder.Property(x => x.EmergencyContactNumber)
                .HasMaxLength(20);

            builder.Property(x => x.ProfileImage)
                .HasMaxLength(500);

            builder.Property(x => x.RowVersion)
                .IsRowVersion();

            builder.HasIndex(x => x.PatientCode).IsUnique();

            builder.HasIndex(x => x.PhoneNumber);

            builder.HasIndex(x => x.Email);

            builder.HasOne(x => x.Clinic)
                .WithMany()
                .HasForeignKey(x => x.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
