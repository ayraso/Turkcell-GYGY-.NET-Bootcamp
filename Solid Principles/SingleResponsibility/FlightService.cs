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
        FlightMonitor monitor;
        Dictionary<Guid, Flight> flights;
        public FlightService() 
        {
            flights = new Dictionary<Guid, Flight>();
            monitor = new FlightMonitor();
        }
        public void AddFlight(Flight newFlight)
        {
            if (newFlight == null) return;
            this.flights.Add(newFlight.Id, newFlight);
            monitor.Refresh(flights);
        }
        public void AddFlight(String companyName,
                              String pointOfDeparture, DateTime departureTime, String departureGate,
                              String pointOfArrival,   DateTime arrivalTime)
        {
            Flight newFlight = new Flight(companyName, pointOfDeparture, departureTime, departureGate, pointOfArrival, arrivalTime) { };
            this.flights.Add(newFlight.Id, newFlight);

            monitor.Refresh(flights);
        }
        private void DeleteFlight(Flight flight) 
        {
            flights.Remove(flight.Id);
            monitor.Refresh(flights);
        }
        private void UpdateFlight() 
        {
            monitor.Refresh(flights);
        }
        public void DelayFlight(Flight flight, TimeSpan delay) 
        {
            if (flights.ContainsKey(flight.Id))
            {
                flights[flight.Id].DepartureTime += delay;
                flights[flight.Id].ArrivalTime += delay;
            }
            UpdateFlight();
        }
        public void CancelFlight(Flight flight) 
        { 
            DeleteFlight(flight);
        }

    }
}
