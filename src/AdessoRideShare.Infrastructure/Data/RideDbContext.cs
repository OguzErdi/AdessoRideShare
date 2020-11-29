using AdessoRideShare.Core.Data;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace AdessoRideShare.Infrastructure.Data
{
    public class RideDbContext : IRideDbContext
    {
        //to craete connection with redis db
        private readonly ConnectionMultiplexer _redisConnection;

        //get ConnectionMultiplexer via Dependency Injection
        public RideDbContext(ConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection;
            Redis = _redisConnection.GetDatabase();

            EndPoint endPoint = _redisConnection.GetEndPoints().First();
            Server = _redisConnection.GetServer(endPoint);
        }

        public IDatabase Redis { get; }
        public IServer Server { get; }
    }
}
