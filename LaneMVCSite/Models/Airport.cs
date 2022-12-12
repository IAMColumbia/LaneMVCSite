using System;
using System.Collections.Generic;
using System.Text;

namespace LaneMVCSite.Models
{
    public class Airport
    {
        public int MaxVehicles;
        public List<AerialVehicle> Vehicles;

        public string AirportCode { get; set; }

        public Airport(string code) : this(code, 5)
        {
            //default MaxVehicles is 5
        }

        public Airport(string code, int maxVehicles)
        {
            AirportCode = code;
            MaxVehicles = maxVehicles;

            Vehicles = new List<AerialVehicle>();
        }

        public void Populate()
        {
            Vehicles.Add(new Airplane());
            Vehicles.Add(new Airplane());
            Vehicles.Add(new Airplane());
        }

        public string AllTakeOff()
        {
            string r = "";

            foreach (AerialVehicle a in Vehicles)
            {
                //can't remove from vehicles during a foreach or we will get errors.
                r += TakeOff(a,false) + "\n";
            }
            //after all have taken off 
            Vehicles.Clear();

            return r;
        }

        public string TakeOff(AerialVehicle a, bool removeFromVehicles)
        {
            if (removeFromVehicles)
            {
                if (Vehicles.Contains(a))
                {
                    Vehicles.Remove(a);
                }
            }
            a.TakeOffProcedure();
            return $"{a.ToString()} has taken off! ";
        }

        public string TakeOff(AerialVehicle a)
        {
            // default to removing from the list of vehicles.
            return TakeOff(a, true);
        }

        public string Land(AerialVehicle a)
        {
            a.LandingProcedure();
            Vehicles.Add(a);
            return $"{a} has landed at airport {AirportCode}. ";
        }

        public string Land(List<AerialVehicle> landing)
        {
            string r = "";
            foreach (AerialVehicle a in landing)
            {
                r += Land(a) + "\n";
            }
            return r;
        }

    }
}
