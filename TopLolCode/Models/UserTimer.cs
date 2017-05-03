using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TopLolCode
{
    static class UserTimer
    {
        //private static DateTime _startTime;
        //private static DateTime _endTime;
        private static int _durationTime;
        
        public static int DurationTime
        {
            get { return (int)(_durationTime/60); }
            set { _durationTime = value*60; } 
        }

        //public static void StarTimer()
        //{

        //}

        public static void TimerEnable()
        {
            //_timerWork = true;
            _timer.IsEnabled = true;
        }

        public static void TimerDisable()
        {
            //_timerWork = false;
            _timer.IsEnabled = false;
        }

        private static void _timer_Tick(object sender, EventArgs e)
        {
            if (_timerWork)
            {
                if (_durationTime > 0) _durationTime--;
                // else disable
            }
        }

        private static DispatcherTimer _timer = new DispatcherTimer(interval: new TimeSpan(0, 0, 1), dispatcher: null, callback: _timer_Tick, priority: DispatcherPriority.Background);
        private static bool _timerWork = false;

    }
}
