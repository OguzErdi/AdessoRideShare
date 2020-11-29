using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdessoRideShare.Core.Data
{
    public interface IRideDbContext
    {
        IDatabase Redis { get; }
        IServer Server { get; }
    }
}
