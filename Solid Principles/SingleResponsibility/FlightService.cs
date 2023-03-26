using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibility
{
    public class FlightService
    {
        public FlightService() { }
        public Dictionary<Guid, Flight> Flights = new Dictionary<Guid, Flight>();
        public void AddFlight(String companyName,
                              String pointOfDeparture, DateTime departureTime, String departureGate,
                              String pointOfArrival,   DateTime arrivalTime)
        {
            Flight newFlight = new Flight(companyName, pointOfDeparture, departureTime, departureGate, pointOfArrival, arrivalTime) { };
            this.Flights.Add(newFlight.Id, newFlight);
        }
        public void DeleteFlight(Flight flight) { }
        public void UpdateFlight(Flight flight) { }
    }
}
