using Homeopathy.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Domain.Entities
{
    public sealed class Doctor : AuditableEntity
    {
        public string DoctorCode { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";

        public string Qualification { get; set; } = string.Empty;

        public string RegistrationNumber { get; set; } = string.Empty;

        public int Experience { get; set; }

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Biography { get; set; } = string.Empty;

        public string? ProfileImage { get; set; }

        public bool IsOnlineConsultationAvailable { get; set; }

        public bool IsActive { get; set; } = true;

        public int ClinicId { get; set; }

        public Clinic? Clinic { get; set; }

        public ICollection<DoctorSchedule> DoctorSchedules { get; set; }
            = new List<DoctorSchedule>();
    }
}
