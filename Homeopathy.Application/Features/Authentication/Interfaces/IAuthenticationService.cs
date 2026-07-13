using Homeopathy.Application.Features.Authentication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Application.Features.Authentication.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> LoginAsync(LoginDto dto);

        Task LogoutAsync();
    }
}
