using System.Data;
using Library.Database;

namespace BLL
{
    public class MenuNav : Library.Root.Other.BusinessLogicBase
    {
        public static ListCollection List(string table, string searchField, string searchValue, string sortField, int direction, int page, int deleted)
        {
            using (var _dal = new DAL.MenuNav())
            {
                if (direction != 1)
                {
                    direction = 0;
                }

                return _dal.List(table, searchField, searchValue, sortField, direction, FromRowNo(page), ToRowNo(page), deleted);
            }
        }

        public static DataTable GetIDList()
        {
            using (var _dal = new DAL.MenuNav())
            {
                return _dal.GetIDList();
            }
        }

        public static DataTable GetPalletData()
        {
            using (var _dal = new DAL.MenuNav())
            {
                return _dal.GetPalletData();
            }
        }

        public static DataTable GetData(string id)
        {
            using (var _dal = new DAL.MenuNav())
            {
                return _dal.GetData(id);
            }
        }

        public static string Maint(string id, string mods, string recType)
        {
            using (var _dal = new DAL.MenuNav())
            {
                string str = System.Web.HttpContext.Current.Session["gstrUserID"].ToString();
                string cc = System.Web.HttpContext.Current.Session["gstrUserCompCode"].ToString();
                string result = _dal.Maint(id, mods, recType, str, System.Web.HttpContext.Current.Request.UserHostAddress.ToString(), cc);

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