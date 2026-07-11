using Homeopathy.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Domain.Entities
{
    public sealed class Appointment : AuditableEntity
    {
        public string AppointmentNumber { get; set; } = string.Empty;

        public int ClinicId { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public Doctor? Doctor { get; set; }

        public Patient? Patient { get; set; }

        public Clinic? Clinic { get; set; }
    }
}
