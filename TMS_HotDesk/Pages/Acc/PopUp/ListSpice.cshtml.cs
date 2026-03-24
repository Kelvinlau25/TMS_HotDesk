using System.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TMS_HotDesk.Pages.Acc.PopUp
{
    public class ListSpiceModel : PageModel
    {
        public DataTable Data { get; set; }
        public string StaffID { get; set; } = string.Empty;
        public string StaffName { get; set; } = string.Empty;

        public void OnGet()
        {
            StaffID = Request.Query["itm1"].ToString();
            StaffName = Request.Query["itm2"].ToString();

            int pageNo = 1;
            if (int.TryParse(Request.Query["page"], out int p) && p > 0)
            {
                pageNo = p;
            }

            var list = BLL.HotSeatSpice.List(pageNo);
            Data = list.Data;
        }
    }
}
