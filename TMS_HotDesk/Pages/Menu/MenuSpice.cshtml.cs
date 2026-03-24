using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace TMS_HotDesk.Pages.Menu
{
    public class MenuSpiceModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public MenuSpiceModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Words { get; set; }
        public string SignOutURL { get; set; }
        public string HomeURL { get; set; }
        public string AppTitle { get; set; }
        public string ListItems { get; set; } = "";

        public void OnGet()
        {
            SignOutURL = "/";
            HomeURL = "/";
            AppTitle = _configuration["title"] ?? "";

            HttpContext.Session.SetString("gstrUserID", "62804");
            HttpContext.Session.SetString("system", "1");
            HttpContext.Session.SetString("gettemp", "Admin");
            HttpContext.Session.SetString("gstrUsername", "Admin");
            HttpContext.Session.SetString("gstrPassword", "crosystem");
            HttpContext.Session.SetString("LoginHis", DateTime.Now.ToString("dd MMMM yyyy"));
            HttpContext.Session.SetString("gstrUserCom", "04");
            HttpContext.Session.SetString("com", "04");

            ListItems = @"
<div class='bar_itms' id='left_menu_0'>
    <ul>
        <li class='nor'><a target='page' href='/Acc/PopUp/ListSpice'>HotSeat Spice</a></li>
        <li class='alt'><a target='page' href='/Acc/PopUp/ListPrai'>HotSeat Prai</a></li>
    </ul>
</div>";

            int hour = DateTime.Now.Hour;
            if (hour < 12)
            {
                Words = "Good Morning";
            }
            else if (hour >= 12 && hour <= 17)
            {
                Words = "Good Afternoon";
            }
            else
            {
                Words = "Good Evening";
            }
        }

        private void SystemCheck(string systemName)
        {
            HttpContext.Session.SetString("system", "1");
        }
    }
}
