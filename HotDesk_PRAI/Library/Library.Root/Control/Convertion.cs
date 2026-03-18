using System.Web.Script.Serialization;
using System.Collections.Generic;

namespace Control
{
    public class Convertion<T>
    {
        private static JavaScriptSerializer _ser;

        /// <summary>
        /// Convert List of T into String Format
        /// </summary>
        /// <param name="list"></param>
        public static string Serializer(List<T> list)
        {
            _ser = new JavaScriptSerializer();
            string result = _ser.Serialize(list);
            _ser = null;
            return result;
        }

        /// <summary>
        /// Convert string into List of T
        /// </summary>
        /// <param name="stringFormat"></param>
        /// <returns></returns>
        public static List<T> Deserializer(string stringFormat)
        {
            _ser = new JavaScriptSerializer();
            List<T> result = _ser.Deserialize<List<T>>(stringFormat);
            _ser = null;
            return result;
        }
    }
}
