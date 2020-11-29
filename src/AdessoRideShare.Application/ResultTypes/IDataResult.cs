using System;
using System.Collections.Generic;
using System.Text;

namespace AdessoRideShare.Application.ResultTypes
{
    public interface IDataResult<out T>:IResult
    {
        T Data { get; }
    }
}
