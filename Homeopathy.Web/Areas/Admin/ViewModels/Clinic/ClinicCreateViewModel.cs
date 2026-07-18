using System.ComponentModel.DataAnnotations;

namespace Homeopathy.Web.Areas.Admin.ViewModels.Clinic
{
    public sealed class ClinicCreateViewModel
    {
        [Display(Name = "Clinic Code")]
        public string ClinicCode { get; set; } = string.Empty;

        [Display(Name = "Clinic Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; } = string.Empty;

        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; } = string.Empty;

        [Display(Name = "Address Line 2")]
        public string? AddressLine2 { get; set; }

        [Display(Name = "City")]
        public string City { get; set; } = string.Empty;

        [Display(Name = "State")]
        public string State { get; set; } = string.Empty;

        [Display(Name = "Country")]
        public string Country { get; set; } = string.Empty;

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; } = string.Empty;

        [Display(Name = "Website")]
        public string? Website { get; set; }

        [Display(Name = "Clinic Logo")]
        public IFormFile? Logo { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; } = true;
    }
}
