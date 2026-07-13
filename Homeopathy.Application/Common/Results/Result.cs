using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Application.Common.Results
{
    public class Result
    {
        public bool Succeeded { get; }

        public string? Error { get; }

        protected Result(bool succeeded, string? error)
        {
            Succeeded = succeeded;
            Error = error;
        }

        public static Result Success()
            => new(true, null);

        public static Result Failure(string error)
            => new(false, error);
    }
}
