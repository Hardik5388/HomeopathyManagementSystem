using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeopathy.Application.Common.Results
{
    public class Result<T> : Result
    {
        public T? Data { get; }

        private Result(bool succeeded, T? data, string? error)
            : base(succeeded, error)
        {
            Data = data;
        }

        public static Result<T> Success(T data)
            => new(true, data, null);

        public static new Result<T> Failure(string error)
            => new(false, default, error);
    }
}
