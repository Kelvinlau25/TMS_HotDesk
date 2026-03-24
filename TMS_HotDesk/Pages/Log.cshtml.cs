using System.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TMS_HotDesk.Pages
{
    public class LogModel : PageModel
    {
        public DataTable LogData { get; set; }
        public string Description { get; set; }

        public void OnGet(string table, string key, string title, string keyDesc)
        {
            Description = "<b>History of " + (title ?? "") + "</b> - <br/>" + (keyDesc ?? "");

            LogData = new DataTable();
            LogData.Columns.Add("FieldName", typeof(string));
            LogData.Columns.Add("B4Update", typeof(string));
            LogData.Columns.Add("AFUpdate", typeof(string));
            LogData.Columns.Add("UpdateBy", typeof(string));
            LogData.Columns.Add("UpdatedDate", typeof(string));
        }
    }
}
