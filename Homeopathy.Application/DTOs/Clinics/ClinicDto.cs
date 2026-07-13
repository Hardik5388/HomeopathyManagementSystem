using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Application.DTOs.Clinics
{
    public class ClinicDto
    {
        public int Id { get; set; }

        public string ClinicCode { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string RegistrationNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string AddressLine1 { get; set; } = string.Empty;

        public string? AddressLine2 { get; set; }

        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
