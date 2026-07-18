using AutoMapper;
using Homeopathy.Application.Features.Clinics.Commands.CreateClinic;
using Homeopathy.Web.Areas.Admin.ViewModels.Clinic;

namespace Homeopathy.Web.Mappings
{
    public sealed class ClinicViewModelProfile : Profile
    {
        public ClinicViewModelProfile()
        {
            CreateMap<ClinicCreateViewModel, CreateClinicDto>();
        }
    }
}
