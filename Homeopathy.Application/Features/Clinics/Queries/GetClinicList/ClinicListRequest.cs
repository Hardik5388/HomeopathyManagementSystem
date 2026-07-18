using Homeopathy.Domain.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Application.Features.Clinics.Queries.GetClinicList
{
    public sealed class ClinicListRequest : PagedRequest
    {
        public bool? IsActive { get; set; }
    }
}
