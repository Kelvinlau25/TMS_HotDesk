using System.Data;

namespace BLL
{
    /// <summary>
    /// Business Logic Layer
    /// ---------------------------------
    /// 18 Feb 2012   Yeon    Initial Version
    /// </summary>
    public class HotSeatSpice : Library.Root.Other.BusinessLogicBase
    {
        public static Library.Database.ListCollection List(int page)
        {
            using (var _dal = new global::DAL.HotSeatSpice())
            {
                return _dal.List(FromRowNo(page), ToRowNo(page));
            }
        }

        public static DataTable GetData(string id)
        {
            using (var _dal = new global::DAL.HotSeatSpice())
            {
                return _dal.GetData(id);
            }
        }

        public static string Maint(string id, string EQ_Name, string EQ_Code, string recType)
        {
            using (var _dal = new global::DAL.HotSeatSpice())
            {
                string str = System.Web.HttpContext.Current.Session["gstrUserID"].ToString();
                string cc = System.Web.HttpContext.Current.Session["gstrUserCompCode"].ToString();
                string result = _dal.Maint(
                    id,
                    EQ_Name,
                    EQ_Code,
                    recType,
                    str,
                    System.Web.HttpContext.Current.Request.UserHostAddress.ToString(),
                    cc
                );

                if (result == "1")
                {
                    _dal.Commit();
                }
                else
                {
                    _dal.Rollback();
                }

                return result;
            }
        }
    }
}