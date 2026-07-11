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
    public sealed class DoctorScheduleConfiguration : IEntityTypeConfiguration<DoctorSchedule>
    {
        public void Configure(EntityTypeBuilder<DoctorSchedule> builder)
        {
            builder.ToTable("DoctorSchedules");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ScheduleName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.DayOfWeek)
                .IsRequired();

            builder.Property(x => x.StartTime)
                .IsRequired();

            builder.Property(x => x.EndTime)
                .IsRequired();

            builder.Property(x => x.SlotDurationInMinutes)
                .IsRequired();

            builder.Property(x => x.MaxPatientsPerSlot)
                .IsRequired();

            builder.Property(x => x.RowVersion)
                .IsRowVersion();

            builder.HasOne(x => x.Doctor)
                .WithMany(x => x.DoctorSchedules)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new
            {
                x.DoctorId,
                x.DayOfWeek,
                x.StartTime
            }).IsUnique();
        }
    }
}
