using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TMS_HotDesk.Pages
{
    public class SessionExpiredSpiceModel : PageModel
    {
        public void OnGet()
        {
            HttpContext.Session.Clear();
        }
    }
}
