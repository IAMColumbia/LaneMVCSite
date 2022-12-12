namespace LaneMVCSite.Models
{
    public class Engine
    {
        public bool IsStarted;

        public Engine()
        {
            IsStarted = false;
        }

        public string About()
        {
            if (IsStarted)
            {
                return "The engine is started.";
            }
            else
            {
                return "The engine is not started.";
            }
        }

        public void Start()
        {
            IsStarted = true;
        }

        public void Stop()
        {
            IsStarted = false;
        }
    }
}