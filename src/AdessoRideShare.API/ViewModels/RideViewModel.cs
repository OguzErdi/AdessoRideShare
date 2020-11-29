using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdessoRideShare.API.ViewModels
{
    public class RideViewModel
    {
        public Guid? Id { get; set; }
        public string Username { get; set; }
        public string Beginning { get; set; }
        public string Destination { get; set; }
        public DateTime Time { get; set; }
        public List<string> Passangers { get; set; }
        public string Description { get; set; }
        public int SeatingCapacity { get; set; }

        public bool? IsActive { get; set; }
    }
}
