using System;
using System.Collections.Generic;

namespace TopLolCode
{
    class UserType
    {
        public string   ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DurationTime { get; set; }
        public List<string> Days { get; set; }
    }
}
