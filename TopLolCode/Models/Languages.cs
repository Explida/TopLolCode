using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TopLolCode.Models
{
    public static class Languages
    {
        public static string[] GetNameLanguages()
        {
            try
            {
                //var t = Directory.GetFiles("/languages/");


                return new string[] { "en.lang", "ru.lang", "ua.lang" };

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
