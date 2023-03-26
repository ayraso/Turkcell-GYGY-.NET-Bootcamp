using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibility
{
    public class Flight
    {
        public Flight(String companyName,
                      String pointOfDeparture, DateTime departureTime, String departureGate,
                      String pointOfArrival, DateTime arrivalTime) 
        {
            this.Id = Guid.NewGuid();
            this.CompanyName = companyName;
            this.PointOfDeparture = pointOfDeparture;
            this.DepartureTime = departureTime;
            this.DepartureGate = departureGate;
            this.PointOfArrival = pointOfArrival;
            this.ArrivalTime = arrivalTime; 
        }
        public Guid Id { get; private set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public String PointOfArrival { get; set; }
        public String PointOfDeparture { get; set; }
        public String CompanyName { get; set; }
        public String DepartureGate { get; set; }

    }
}
