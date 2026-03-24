using System.Text.Json;
using System.Collections.Generic;

namespace Library.Root.Control
{
    public class Convertion<T>
    {
        /// <summary>
        /// Convert List of T into String Format
        /// </summary>
        /// <param name="list"></param>
        public static string Serializer(List<T> list)
        {
            return JsonSerializer.Serialize(list);
        }

        /// <summary>
        /// Convert string into List of T
        /// </summary>
        /// <param name="stringFormat"></param>
        /// <returns></returns>
        public static List<T> Deserializer(string stringFormat)
        {
            return JsonSerializer.Deserialize<List<T>>(stringFormat);
        }
    }
}
