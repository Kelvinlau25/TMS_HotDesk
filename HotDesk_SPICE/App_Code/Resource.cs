using System.Reflection;
using System.Resources;
using System.Globalization;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Drawing.Imaging;

namespace Control
{
    /// <summary>
    /// Retrieve the value from the resource page
    /// -----------------------------------------
    /// C.C.Yeon    25 April 2011   initial Version
    /// </summary>
    public class Resource
    {
        public static string RetrieveValue(string Resource, string Field)
        {
            var mng = new ResourceManager(Resource, Assembly.GetExecutingAssembly());
            return mng.GetString(Field);
        }
    }
}
