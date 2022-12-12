using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LaneMVCSite.Models
{
    public abstract class AerialVehicle
    {
        private int currentAltitude;
        public int CurrentAltitude 
        { 
            get
            {
                return currentAltitude;
            }
            set
            {
                if (value != currentAltitude)
                {
                    currentAltitude = value;
                }
            }
        }

        private Engine MyEngine { get; set; }

        public bool engineStarted
        {
            get
            {
                return MyEngine.IsStarted;
            }
        }

        public bool IsFlying { get; set; }
        public int MaxAltitude { get; set; }

        public static int TotalAerialVehicles = 0;
        public int id;
        public AerialVehicle(int _MaxAltitude)
        {
            MaxAltitude = _MaxAltitude;
            IsFlying = false;
            MyEngine = new Engine();
            TotalAerialVehicles += 1;
            this.id = AerialVehicle.TotalAerialVehicles;
        }

        public AerialVehicle() : this(1000) {}

        public string About()
        {
            if (IsFlying)
            {
                return $"This aerial vehicle is flying at {CurrentAltitude} ft.";
            }
            else
            {
                return "This aerial vehicle is not currently flying.";
            }
        }

        public string getEngineStartedString()
        {
            return MyEngine.About();
        }

        public bool TakeOff()
        {
            if (MyEngine.IsStarted)
            {
                IsFlying = true;
                return true;
            }
            return false;
        }

        public virtual void StartEngine()
        {
            MyEngine.Start();
        }

        public virtual void StopEngine()
        {
            MyEngine.Stop();
        }

        public void FlyDown()
        {
            FlyDown(1000);
        }

        public void FlyDown(int howMuch)
        {
            if (IsFlying)
            {
                CurrentAltitude -= howMuch;
                CheckAltitude();
            }
        }

        public void FlyUp()
        {
            FlyUp(1000);
        }

        public void FlyUp(int howMuch)
        {
            if (IsFlying)
            {
                CurrentAltitude += howMuch;
                CheckAltitude();
            }
        }

        private void CheckAltitude()
        {
            if (CurrentAltitude < 0)
            {
                CurrentAltitude = 0;
                IsFlying = false;
                return;
            }

            if (CurrentAltitude > MaxAltitude)
            {
                CurrentAltitude = MaxAltitude;
                return;
            }
        }

        public virtual void TakeOffProcedure()
        {
            StartEngine();
            TakeOff();
        }

        public virtual void LandingProcedure()
        {
            do
            {
                FlyDown();
            } while (IsFlying);

            StopEngine();
        }
    }
}