using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LaneMVCSite.Models;

namespace LaneMVCSite.Controllers
{
    public class AirplaneController : Controller
    {

        public static Airport airport;

        public AirplaneController()
        {
            if (airport == null)
            {
                airport = new Airport("LANE");
                airport.Populate();
            }
        }

        public AirplaneController(Airport airport)
        {
            AirplaneController.airport = airport;
        }

        // GET: AirplaneController
        public ActionResult Index()
        {
            
            return View(airport.Vehicles);
        }

        // GET: AirplaneController/Details/5
        public ActionResult Details(int id)
        {
            var av = airport.Vehicles.Find(a => a.id == id);
            return View(av);
        }

        // GET: Takeoff the plane
        public ActionResult TakeOff(int id)
        {
            var av = airport.Vehicles.Find(a => a.id == id);
            av.TakeOffProcedure();
            return View();
        }

        public ActionResult FlyUp(int id)
        {
            var av = airport.Vehicles.Find(a => a.id == id);
            av.FlyUp();
            return View();
        }

        public ActionResult FlyDown(int id)
        {
            var av = airport.Vehicles.Find(a => a.id == id);
            av.FlyDown();
            return View();
        }

    }
}
