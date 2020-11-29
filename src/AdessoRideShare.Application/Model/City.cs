using System;
using System.Collections.Generic;
using System.Text;

namespace AdessoRideShare.Application.Model
{
    public class City
    {
        public int x { get; set; }
        public int y { get; set; }

        public City(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
