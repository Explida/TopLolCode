using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TopLolCode
{
    class UserTimer
    {
        private int _durationTime = 0;
        
        public int DurationTime
        {
            get { return (int)(_durationTime/60); }     //convert to min
            set { _durationTime = value*60; }           //convert to sec
        }
        
        public UserTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += _timer_Tick;
            
        }

        public void TimerStart(int min)
        {
            _timer.Start();
        }

        public void TimerStop()
        {
            _timer.Stop();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (_timerWork)
            {
                if (_durationTime >= 0) _durationTime--;
                else
                {
                    Process.Start("notepad.exe");
                    _timer.Stop();
                }
            }
        }

        private DispatcherTimer _timer;
        private bool _timerWork = true;

    }
}
