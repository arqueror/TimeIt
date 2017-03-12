using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace TimeIt
{
    public class TimeIt : IDisposable
    {
        public delegate void TimeItMethodDelegate(params object[] args);
        private Stopwatch _stopWatchStatic;
        private Stopwatch _stopwatch = new Stopwatch();
        private Action<TimeSpan> _callback;

        public TimeIt()
        {
            _stopwatch.Start();
        }

        public TimeIt(Action<TimeSpan> callback) : this()
        {
            _callback = callback;
        }

        public static TimeIt Invoke(Action<TimeSpan> callback)
        {
            return new TimeIt(callback);
        }


        public TimeSpan ElapsedTime
        {
            get { return _stopwatch.Elapsed; }
        }
        public TimeSpan Start(Action blockOfCode)
        {
            _stopWatchStatic = Stopwatch.StartNew();
            blockOfCode.Invoke();
            _stopWatchStatic.Stop();

            return _stopWatchStatic.Elapsed;
        }


        public TimeSpan Start(TimeItMethodDelegate method, params object[] args)
        {
            _stopWatchStatic = Stopwatch.StartNew();
            method.Invoke(args);
            _stopWatchStatic.Stop();
            return _stopWatchStatic.Elapsed;
        }

        public void Dispose()
        {
            _stopwatch.Stop();
            _callback?.Invoke(ElapsedTime);
        }
    }
}
