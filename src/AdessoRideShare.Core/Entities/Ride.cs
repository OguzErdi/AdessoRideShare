using System;
using System.Collections.Generic;
using System.Text;

namespace AdessoRideShare.Core.Entities
{
    public class Ride
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Beginning { get; set; }
        public string Destination { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public int SeatingCapacity { get; set; }
        public List<string> Passangers { get; set; }
        public bool IsActive { get; set; }
    }
}
