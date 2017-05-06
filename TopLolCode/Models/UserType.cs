using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TopLolCode
{
    [XmlRoot]
    public class UserType
    {
        public UserType() { }
        
        public string   ID { get; set; }
        public string   Access { get; set; }    // parent or child
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DurationTime { get; set; }
        public List<string> Days { get; set; }  // дни недели


    }
}
