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
        private int _timedShutdown;
        private bool _testMode;
        private bool _fullScreen;
        private bool _blockKeys;
        private string _selectedLang;
        private List<UserType> _regulations;

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

        public Data()
        {
            _regulations = new List<UserType>();
        }


        public void AddRegulations(string ID, string Access, DateTime Start, DateTime End, int Duration, List<string> Days)
        {
            var t = new UserType()
            {
                ID = ID,
                Access = Access,
                StartDate = Start,
                EndDate = End,
                DurationTime = Duration,
                Days = Days
            };

            _regulations.Add(t);
        }

        public void StartTimer()
        {
            var t = new UserTimer();
            t.TimerStart(1, _testMode);
        }

        public void StartTimer(string ID)
        {

            foreach ( var t in _regulations)
            {
                if (ID == t.ID)
                {

                }
            }


        }


        public static Data DeserializeUserRegulations()
        {
            try
            {
                using (var sr = new FileStream("Data/Data.xml", FileMode.Open, FileAccess.Read))
                {
                    var ser = new XmlSerializer(typeof(Data));
                    var t = (Data)ser.Deserialize(sr);
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
