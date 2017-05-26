using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLolCode.Models.Enums;

namespace TopLolCode.Models
{
    public class ManagerDateTime
    {
        private DateTimeServers _selectServer;

        public DateTimeServers SelectServer { get => _selectServer; set => _selectServer = value; }

        public ManagerDateTime()
        {
            _selectServer = DateTimeServers.local;
        }

        public DateTime GetDateTimeServer()
        {
            switch (_selectServer)
            {
                case DateTimeServers.local:
                    return DateTime.Now;
                case DateTimeServers.net:
                    throw new Exception();
                case DateTimeServers.other:
                    throw new Exception();
            }
            return new DateTime();
        }
        
    }
}
