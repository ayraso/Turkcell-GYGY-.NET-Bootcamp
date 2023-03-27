using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibility
{
    public class FlightMonitor
    {
        public FlightMonitor() { }
        public void Refresh(Dictionary<Guid, Flight> flights) 
        {
            Console.WriteLine($"");
            foreach (var flight in flights)
            {
                Console.WriteLine($"{flight.Value.DepartureTime}, {flight.Value.PointOfArrival}, {flight.Value.ArrivalTime}, {flight.Value.DepartureGate}, {flight.Value.CompanyName}");
            }
        }

    }
}
