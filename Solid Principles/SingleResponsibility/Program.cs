using SingleResponsibility;

FlightService flightService = new FlightService();

Console.WriteLine("\nFlight1 is added.");
flightService.AddFlight("THY", "İzmir", new DateTime(2023, 3, 26, 10, 0, 0), "X", "Ankara", new DateTime(2023, 3, 26, 11, 10, 0));

Console.WriteLine("\nFlight2 is added.");
Flight flight2 = new Flight("THY", "İzmir", new DateTime(2023, 3, 26, 9, 0, 0), "S", "İstanbul", new DateTime(2023, 3, 26, 10, 0, 0));
flightService.AddFlight(flight2);

Console.WriteLine("\nFlight3 is added.");
Flight flight3 = new Flight("Pegasus", "İzmir", new DateTime(2023, 3, 26, 9, 0, 0), "M", "İstanbul", new DateTime(2023, 3, 26, 10, 0, 0));
flightService.AddFlight(flight3);

Console.WriteLine("\nFlight3 is delayed for 3 and half hour.");
flightService.DelayFlight(flight3, new TimeSpan(3, 30, 0));

Console.WriteLine("\nFlight2 is delayed for 7 hour.");
flightService.DelayFlight(flight2, new TimeSpan(7, 0, 0));

Console.WriteLine("\nFlight2 is cancelled.");
flightService.CancelFlight(flight2);
