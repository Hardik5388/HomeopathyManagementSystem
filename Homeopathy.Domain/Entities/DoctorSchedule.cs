using Homeopathy.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Domain.Entities
{
    public sealed class DoctorSchedule : AuditableEntity
    {
        public int DoctorId { get; set; }

        public string ScheduleName { get; set; } = string.Empty;

        public DayOfWeek DayOfWeek { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public int SlotDurationInMinutes { get; set; }

        public int MaxPatientsPerSlot { get; set; }

        public bool AllowOnlineConsultation { get; set; }

        public bool IsActive { get; set; } = true;

        public Doctor? Doctor { get; set; }
    }
}
