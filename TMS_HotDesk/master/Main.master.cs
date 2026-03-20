using System;
using System.Web.UI;

public partial class master_Main : System.Web.UI.MasterPage
{
    private bool _pointer = false;

    protected void Page_Init(object sender, EventArgs e)
    {
        Session["gstrUserID"] = "F22559";
        Session["gstrUserCompCode"] = "System";
        Session["gstrUserWorksNo"] = "System";
        Session["Barcodechecking"] = "F22559";
    }
}
