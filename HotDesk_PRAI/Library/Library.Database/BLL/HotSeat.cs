using System.Data;

namespace BLL
{
    /// <summary>
    /// Business Logic Layer
    /// ---------------------------------
    /// 18 Feb 2012   Yeon    Initial Version
    /// </summary>
    public class HotSeat : Library.Root.Other.BusinessLogicBase
    {
        public static ListCollection List(int page)
        {
            using (var _dal = new DAL.HotSeat())
            {
                // Validation the parameter value
                return _dal.List(FromRowNo(page), ToRowNo(page));
            }
        }

        public static DataTable GetData(string id)
        {
            using (var _dal = new DAL.HotSeat())
            {
                return _dal.GetData(id);
            }
        }

        public static string Maint(string id, string EQ_Name, string EQ_Code, string recType)
        {
            using (var _Dal = new DAL.HotSeat())
            {
                string str = System.Web.HttpContext.Current.Session["gstrUserID"].ToString();
                string cc = System.Web.HttpContext.Current.Session["gstrUserCompCode"].ToString();
                string result = _Dal.Maint(id, EQ_Name, EQ_Code, recType, str, System.Web.HttpContext.Current.Request.UserHostAddress.ToString(), cc);

                if (result == "1")
                {
                    _Dal.Commit();
                }
                else
                {
                    _Dal.Rollback();
                }

                return result;
            }
        }
    }
}
