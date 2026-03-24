using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TMS_HotDesk.Pages
{
    public class SessionExpiredPraiModel : PageModel
    {
        public void OnGet()
        {
            HttpContext.Session.Clear();
        }
    }
}
