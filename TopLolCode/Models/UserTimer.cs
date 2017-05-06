using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TopLolCode
{
    public class UserTimer
    {
        private int _durationTime = 300;    //default time 5min
        private DispatcherTimer _timer;
        private bool _testMode = true;

        public bool TestMode
        {
            get { return _testMode; }
            private set { _testMode = value; }
        }
        public int DurationTime
        {
            get { return (int)(_durationTime/60); }     //convert to min
            private set { _durationTime = value*60; }           //convert to sec
        }
        
        public UserTimer()
        {
            _timer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 1)
            };
            _timer.Tick += _timer_Tick;
        }

        public void TimerStart(int Minutes, bool TestMode)
        {
            _durationTime = Minutes*60;
            _testMode = TestMode;
            _timer.Start();
        }

        public void TimerStop()
        {
            _timer.Stop();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (_durationTime > 0) _durationTime--;
            else
            {
                if (_testMode) Process.Start("notepad.exe");
                //else Process.Start("shutdown.exe");
                _timer.Stop();
            }
        }


    }
}
