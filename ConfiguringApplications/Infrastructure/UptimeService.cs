using System.Diagnostics;

namespace ConfiguringApplications.Infrastructure
{
    public class UptimeService
    {
        private readonly Stopwatch _timer;

        public UptimeService()
        {
            _timer = Stopwatch.StartNew();    
        }

        public long Uptime => _timer.ElapsedMilliseconds;
    }
}
