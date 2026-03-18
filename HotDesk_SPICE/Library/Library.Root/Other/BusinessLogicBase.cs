using System.Threading;

namespace Other
{
    /// <summary>
    /// Handler the Common Business Logic Function
    /// -------------------------------------------
    /// C.C.Yeon    25 April 2011   Initial Version
    /// </summary>
    public abstract class BusinessLogicBase
    {
        public enum LanguagePack
        {
            English = 0,
            Malay = 1
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
                return (int)(System.Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MaxRowPerPage"].ToString()));
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
