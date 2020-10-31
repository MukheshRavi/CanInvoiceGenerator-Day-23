using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoice
{
    /// <summary>
    /// Ride details contains distance and time
    /// </summary>
  public  class RideDetails
    {
        public double distance;
        public int time;
        public RideDetails(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
