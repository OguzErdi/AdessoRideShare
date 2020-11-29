using System;
using System.Collections.Generic;
using System.Text;

namespace AdessoRideShare.Application.ResultTypes
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
