using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using ACL.MenuBar.Object;

public partial class Style2_MenuSpice : System.Web.UI.Page
{
    protected LeftMenuItemList _list;
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

        if (_list == null)
        {
            _list = new LeftMenuItemList();
        }

        int counter = 0;
        var _acl = new ACL.OracleClass.Resource(System.Configuration.ConfigurationManager.ConnectionStrings["ORCL_ACL"].ConnectionString);
        List<ACL.Object.Resource> _sourcelist = _acl.RetrieveResource(_userid, _systemid);
        StringBuilder _str;
        int _altcounter = 0;

        foreach (ACL.Object.Resource itm in ACL.Search.GetParent(_sourcelist, _systemid))
        {
            _list.AddItem(new LeftMenuItem("left_menu_" + counter, itm.ResouceDesc, false));
            _str = new StringBuilder();
            _altcounter = 0;

            foreach (ACL.Object.Resource node in ACL.Search.GetParent(_sourcelist, itm.ResourceID))
            {
                _altcounter++;
                _str.AppendFormat("<li class='{2}'><a {3} href='{0}'>{1}</a></li>",
                    GenerateKeywords(node.ResourceURL, _userid.ToString(), Session["gstrUserCom"].ToString(), Session["gettemp"].ToString(), node.ResourceName),
                    node.ResouceDesc,
                    (_altcounter % 2 == 0) ? "alt" : "nor",
                    "target='page'");
            }

            liItems.Text += string.Format("<div class='bar_itms' id='{0}'><ul>{1}</ul></div>", "left_menu_" + counter, _str.ToString());
            counter++;
        }

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
        Session["system"] = 0;
        Session["system"] = ACL.OracleClass.Resource.RetrieveApplicationIDByName(
            System.Configuration.ConfigurationManager.ConnectionStrings["ORCL_ACL"].ConnectionString,
            Systemname);

        if (Session["system"].ToString() == "0")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invalid System');", true);
            return;
        }
    }
}
