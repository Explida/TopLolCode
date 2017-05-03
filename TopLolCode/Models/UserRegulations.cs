using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace TopLolCode.Models
{
    class UserRegulations
    {
        private List<UserType> regulations;

        public static UserRegulations DeserializeUserRegulations()
        {
            try
            {
                using (var sr = new StreamReader("Regulations.xml"))
                {
                    var ser = new XmlSerializer(typeof(UserRegulations));
                    var t = (UserRegulations)ser.Deserialize(sr);
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
                using (var sw = new StreamWriter("Regulations.xml"))
                {
                    var deser = new XmlSerializer(typeof(UserRegulations));
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
