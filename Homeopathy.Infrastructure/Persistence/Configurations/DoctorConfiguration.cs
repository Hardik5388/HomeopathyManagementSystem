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
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DoctorCode)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Qualification)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.RegistrationNumber)
                .HasMaxLength(100);

            builder.Property(x => x.Email)
                .HasMaxLength(150);

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(x => x.Biography)
                .HasMaxLength(2000);

            builder.Property(x => x.ProfileImage)
                .HasMaxLength(500);

            builder.Property(x => x.RowVersion)
                .IsRowVersion();

            builder.HasIndex(x => x.DoctorCode).IsUnique();

            builder.HasIndex(x => x.RegistrationNumber).IsUnique();

            builder.HasIndex(x => x.Email);

            builder.HasOne(x => x.Clinic)
                .WithMany(x => x.Doctors)
                .HasForeignKey(x => x.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.DoctorSchedules)
                .WithOne(x => x.Doctor)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
