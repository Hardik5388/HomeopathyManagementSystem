using Homeopathy.Application.DTOs.Clinics;

namespace Homeopathy.Web.Areas.Admin.ViewModels.Clinic
{
    public sealed class ClinicIndexViewModel
    {
        public List<ClinicListDto> Clinics { get; set; } = [];
    }
}
