using Aircompany;
using Aircompany.Planes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AircompanyTests.Tests
{
    [TestFixture]
    public class AirportTest
    {
        private readonly List<Plane> _planes = new List<Plane>(FlightPlan.planes);
        private PassengerPlane _planeWithMaxPassengerCapacity = new PassengerPlane("Boeing-747", 980, 16100, 70500, 242);
        private readonly List<Plane> _planesOrderedByMaxLoadCapacity = FlightPlan.planes.OrderBy(x => x.GetMaxLoadCapacity()).ToList();

        [Test]
        public void CheckingAvailabilityOfTransportMilitaryPlanes()
        {
            var airport = new Airport(_planes);
            var transportMilitaryPlanes = airport.GetTransportMilitaryPlanes().ToList();    
            Assert.IsTrue(transportMilitaryPlanes.Count != 0);
        }

        [Test]
        public void CheckPassengerPlaneWithMaxPassengersCapacity()
        {
            var airport = new Airport(_planes);
            var expectedPlaneWithMaxPassengersCapacity = airport.GetPassengerPlaneWithMaxPassengersCapacity();
            Assert.IsTrue(expectedPlaneWithMaxPassengersCapacity.Equals(_planeWithMaxPassengerCapacity));
        }

        [Test]
        public void SortedPlanesByMaxLoadCapacity()
        {
            var airport = new Airport(_planes);
            var planesSortedByMaxLoadCapacity = airport.SortPlanesByMaxLoadCapacity().GetPlanes().ToList();
            Assert.That(planesSortedByMaxLoadCapacity.SequenceEqual(_planesOrderedByMaxLoadCapacity));
        }
    }
}
