using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace TopLolCode.Models
{
    class Data
    {
        private List<UserType> regulations;

        public Data()
        {
            regulations = new List<UserType>();
        }



        public void AddRegulations()
        {

        }

        public static Data DeserializeUserRegulations()
        {
            try
            {
                using (var sr = new StreamReader("Data.xml"))
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
                using (var sw = new StreamWriter("Data.xml"))
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
