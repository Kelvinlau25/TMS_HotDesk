using System;
using System.Web.UI;

public partial class Style2_MenuSpice : System.Web.UI.Page
{
    private int _userid;
    private int _systemid;
    protected string _words;
    private bool _pointer = false;

    private string _SignOutURL = string.Empty;
    protected string SignOutURL
    {
        get { return _SignOutURL; }
    }

    private string _HomeURL = string.Empty;
    protected string HomeURL
    {
        get { return _HomeURL; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        _SignOutURL = ResolveUrl("~/Default.aspx");
        _HomeURL = ResolveUrl("~/Default.aspx");

        _pointer = true;
        ahrefhome.Visible = _pointer;

        Session["gstrUserID"] = "62804";
        Session["system"] = "1";
        Session["gettemp"] = "Admin";
        Session["gstrUsername"] = "Admin";
        Session["gstrPassword"] = "crosystem";
        Session["LoginHis"] = DateTime.Now.ToString("dd MMMM yyyy");
        Session["gstrUserCom"] = "04";
        Session["com"] = "04";

        _userid = Convert.ToInt32(Session["gstrUserID"]);
        _systemid = Convert.ToInt32(Session["system"]);

        liItems.Text = @"
<div class='bar_itms' id='left_menu_0'>
    <ul>
        <li class='nor'><a target='page' href='" + ResolveUrl("~/Acc/PopUp/ListSpice.aspx") + @"'>HotSeat Spice</a></li>
        <li class='alt'><a target='page' href='" + ResolveUrl("~/Acc/PopUp/ListPrai.aspx") + @"'>HotSeat Prai</a></li>
    </ul>
</div>";

        if (DateTime.Now.Hour < 12)
        {
            _words = "Good Morning";
        }
        else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour <= 17)
        {
            _words = "Good Afternoon";
        }
        else
        {
            _words = "Good Evening";
        }
    }

    public string GenerateKeywords(string URL, string ID, string Company, string Name, string System)
    {
        URL = URL.Replace("http://10.200.1.12:205/", "http://127.0.0.1:3313/LSS/");
        return Server.HtmlEncode(ResolveUrl(URL));
    }

    private void systemCheck(string Systemname)
    {
        Session["system"] = 1;
    }
}