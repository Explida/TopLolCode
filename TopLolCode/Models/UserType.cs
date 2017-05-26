using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace TopLolCode
{
    [XmlRoot]
    public class UserType
    {
        public string   ID { get; set; }
        public string   Access { get; set; }    // parent or child
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DurationTime { get; set; }
        public ObservableCollection<DayOfWeek> Days { get; set; }  // дни недели
    }
}
