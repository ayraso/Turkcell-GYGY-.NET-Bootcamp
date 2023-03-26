using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibility
{
    public class FlightService
    {
        public FlightService() { }

        public void AddFlight(String companyName,
                              String pointOfDeparture, DateTime departureTime, String departureGate,
                              String pointOfArrival,   DateTime arrivalTime)
        { 
            
        }
          
        public void DeleteFlight(Flight flight) { }
        public void UpdateFlight(Flight flight) { }

       
    }
}
