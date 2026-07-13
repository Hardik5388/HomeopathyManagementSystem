using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Application.Common.Exceptions
{
    public sealed class BadRequestException : Exception
    {
        public BadRequestException(string message)
        : base(message)
        {
        }
        public BadRequestException(string message, Exception innerException)
       : base(message, innerException)
        {
        }
    }
}
