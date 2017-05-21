using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace TopLolCode.Models
{
    public class Data
    {
        private static Data _singleData;
        private int _timedShutdown;
        private bool _testMode;
        private bool _fullScreen;
        private bool _blockKeys;
        private string _selectedLang;
        private List<UserType> _regulations;
        private UserTimer _timer;

        [XmlAttribute]
        public int TimedShutdown
        {
            get { return _timedShutdown; }
            set { _timedShutdown = value; }
        }
        [XmlAttribute]
        public bool TestMode
        {
            get { return _testMode; }
            set { _testMode = value; }
        }
        [XmlAttribute]
        public bool FullScreen
        {
            get { return _fullScreen; }
            set { _fullScreen = value; }
        }
        [XmlAttribute]
        public bool BlockKeys
        {
            get { return _blockKeys; }
            set { _blockKeys = value; }
        }
        [XmlAttribute]
        public string SelectedLang
        {
            get { return _selectedLang; }
            set { _selectedLang = value; }
        }

        public List<UserType> Regulations
        {
            get { return _regulations; }
            private set { _regulations = value; }
        }


        public void AddRegulations(string ID, string Access, DateTime Start, DateTime End, int Duration, List<DayOfWeek> Days)
        {
            var newRegulations = new UserType()
            {
                ID = ID,
                Access = Access,
                StartDate = Start,
                EndDate = End,
                DurationTime = Duration,
                Days = Days
            };

            _regulations.Add(newRegulations);
        }
        
        public void RemoveRegulations(string ID)
        {
            foreach (var t in _regulations)
            {
                if (t.ID == ID && t.Access != "Parent")
                {
                    _regulations.Remove(t);
                    return;
                }
            }
        }

        public bool FindID(string ID)
        {
            foreach (var t in _regulations)
            {
                if (ID == t.ID)
                {
                    return true;
                }
            }
            return false;
        }

        public void StartTimer()
        {
            _timer.TimerStart(_timedShutdown, _testMode);
        }

        public int StartTimer(string ID)
        {
            foreach ( var t in _regulations)
            {
                if (ID == t.ID)
                {
                    if (t.Access == "Parent")
                    {
                        return 1;
                    }
                    if (t.StartDate > DateTime.Now &&
                        t.EndDate < DateTime.Now &&
                        t.Days.Contains(DateTime.Now.DayOfWeek))
                    {
                        _timer.TimerStart(t.DurationTime, _testMode);
                        return 0;
                    }
                }
            }
            return -1;
        }


        public static Data GetSingleData()
        {
            if (_singleData == null) _singleData = new Data();
            return _singleData;
        }

        private Data()
        {
            _regulations = new List<UserType>();
            _timer = new UserTimer();
        }


        public static Data DeserializeUserRegulations()
        {
            try
            {
                using (var sr = new FileStream("Data/Data.xml", FileMode.Open, FileAccess.Read))
                {
                    var ser = new XmlSerializer(typeof(Data));
                    var t = (Data)ser.Deserialize(sr);
                    _singleData = t;
                    return t;
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public void SerializeUserRegulations()
        {
            try
            {
                using (var sw = new FileStream("Data/Data.xml", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    var deser = new XmlSerializer(typeof(Data));
                    deser.Serialize(sw, this);

                }
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
