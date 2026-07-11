using Homeopathy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Infrastructure.Persistence
{
    public class HomeopathyDbContext : DbContext
    {
        public HomeopathyDbContext(DbContextOptions<HomeopathyDbContext> options) : base(options)
        {

        }
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<DoctorSchedule> DoctorSchedules => Set<DoctorSchedule>();

        public DbSet<Clinic> Clinics => Set<Clinic>();
        public DbSet<Appointment> Appointments => Set<Appointment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HomeopathyDbContext).Assembly);
        }
    }
}
