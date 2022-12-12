using LaneMVCSite;
using LaneMVCSite.Controllers;
using LaneMVCSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVCTests
{
    [TestClass]
    public class AirplaneControllerTest
    {
        [TestMethod]
        public void AirplaneIndexTest()
        {
            //arrange
            Airplane ap;
            ap = new Airplane();
            Airport airport = new Airport("TEST");
            airport.Land(ap);
            var apController = new AirplaneController(airport);

            //act
            var result = (ViewResult)apController.Index();

            //assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
            Assert.AreEqual(airport.Vehicles[0], ap);
            Assert.AreEqual(airport.Vehicles.GetType(), result.Model.GetType());
        }

        [TestMethod]
        public void AirplaneTakeoffTest()
        {
            //arrange
            Airplane ap;
            ap = new Airplane();

            int id = ap.id;

            Airport airport = new Airport("TEST");
            airport.Land(ap);
            var apController = new AirplaneController(airport);

            //act
            var result = (ViewResult)apController.TakeOff(id);

            //assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
            Assert.IsTrue(ap.IsFlying);
        }

        [TestMethod]
        public void AirplaneFlyUpTest()
        {
            //arrange
            Airplane ap;
            ap = new Airplane();

            int id = ap.id;

            Airport airport = new Airport("TEST");
            airport.Land(ap);
            var apController = new AirplaneController(airport);

            apController.TakeOff(id);

            //act
            var result = (ViewResult)apController.FlyUp(id);

            //assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
            Assert.AreEqual(ap.CurrentAltitude, 1000);
            Assert.AreNotEqual(ap.CurrentAltitude, 0);
        }
    }
}