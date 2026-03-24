using System.Threading;

namespace Library.Root.Other
{
    public class BusinessLogicBase
    {
        public enum LanguagePack
        {
            English = 0,
            Malay = 1
        }

        private static string _maxRowPerPage = null;

        /// <summary>
        /// Register the MaxRowPerPage setting from ASP.NET Core IConfiguration at startup.
        /// </summary>
        public static void RegisterMaxRowPerPage(string value)
        {
            _maxRowPerPage = value;
        }

        public static LanguagePack Language
        {
            get
            {
                LanguagePack lp = LanguagePack.English;

                if (Thread.CurrentThread.CurrentCulture.ToString().Equals("ms-MY"))
                {
                    lp = LanguagePack.Malay;
                }

                return lp;
            }
        }

        /// <summary>
        /// Max Quantity per Page
        /// </summary>
        public static int MaxQuantityPerPage
        {
            get
            {
                // Try registered value first (ASP.NET Core IConfiguration),
                // then fall back to ConfigurationManager (legacy .NET Framework config).
                string val = _maxRowPerPage;
                if (string.IsNullOrEmpty(val))
                {
                    val = System.Configuration.ConfigurationManager.AppSettings["MaxRowPerPage"];
                }
                return (int)(System.Convert.ToInt32(val ?? "10"));
            }
        }

        /// <summary>
        /// Generate and Caculate the Number 
        /// </summary>
        public static int FromRowNo(int PageNo)
        {
            if (PageNo == 1)
            {
                return 1;
            }
            else
            {
                return ((PageNo - 1) * MaxQuantityPerPage) + 1;
            }
        }

        /// <summary>
        /// Generate and Caculate the Number 
        /// </summary>
        public static int ToRowNo(int PageNo)
        {
            if (PageNo == 1)
            {
                return MaxQuantityPerPage;
            }
            else
            {
                return ((PageNo - 1) * MaxQuantityPerPage) + MaxQuantityPerPage;
            }
        }
    }
}
