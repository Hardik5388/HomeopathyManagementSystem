using AutoMapper;
using Homeopathy.Application.DTOs.Clinics;
using Homeopathy.Application.Features.Clinics.Commands.CreateClinic;
using Homeopathy.Application.Features.Clinics.Commands.UpdateClinic;
using Homeopathy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Application.Mappings
{
    public class ClinicProfile : Profile
    {
        public ClinicProfile()
        {
            CreateMap<Clinic, ClinicDto>();

            CreateMap<Clinic, ClinicListDto>();

            CreateMap<CreateClinicDto, Clinic>();

            CreateMap<UpdateClinicDto, Clinic>();
        }
    }
}
