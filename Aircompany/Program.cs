
using System;
using System.IO;

namespace Aircompany
{
    internal static class Program
    {
       
        public static void Main(string[] args)
        {
            var airport = new Airport(FlightPlan.planes);
            var militaryAirport = new Airport(airport.GetMilitaryPlanes());
            var passengerAirport = new Airport(airport.GetPassengersPlanes());

            using (var writer = new StreamWriter("ConsoleLogFile.txt"))
            {
                Console.WriteLine(militaryAirport.SortPlanesByMaxFlightDistance().ToString());
                Console.WriteLine(passengerAirport.SortPlanesByMaxSpeed().ToString());
                Console.WriteLine(passengerAirport.GetPassengerPlaneWithMaxPassengersCapacity());
            }
        }
    }
}
