using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Application.DTOs.Clinics
{
    public class ClinicListDto
    {
        public int Id { get; set; }

        public string ClinicCode { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
