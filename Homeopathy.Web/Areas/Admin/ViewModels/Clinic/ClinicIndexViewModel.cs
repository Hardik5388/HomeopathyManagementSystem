using Homeopathy.Application.DTOs.Clinics;
using Homeopathy.Domain.Common.Pagination;
using Homeopathy.Web.Areas.Admin.ViewModels.Common;

namespace Homeopathy.Web.Areas.Admin.ViewModels.Clinic
{
    public sealed class ClinicIndexViewModel
    {
        public SearchFilterViewModel Filter { get; set; } = new();

        public GridViewModel<ClinicListDto> Grid { get; set; } = new();
        //public PagedResult<ClinicListDto> Clinics { get; set; } = new();
        //public PaginationViewModel Pagination { get; set; } = new();
    }
}
