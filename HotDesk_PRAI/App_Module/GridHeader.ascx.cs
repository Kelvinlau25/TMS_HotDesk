using System;
using System.Web.UI;

/// <summary>
/// Add User Control
/// 
/// Additional
/// ----------------------------------------
/// if the URL Doest not Containt the Sort Direction and Sort Field then will generate and redirect to default value
/// 
/// Remark : Based on previous version and modified the way of the binding
/// ----------------------------------------
/// C.C.Yeon    25 APril 2011  Modified 
/// </summary>
public partial class UserControl_GridHeader : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindHyperLink();
        }

        Control.Base _page = (Control.Base)this.Page;
        hypAdd.Visible = _page.AddControl;
        ddlAction.Visible = _page.PrintControl;
    }

    protected void BindHyperLink()
    {
        ddlAction.Visible = false;
        Control.Base setting = (Control.Base)this.Page;
        string addurl = setting.GetUrl(Control.Base.EnumAction.Add);
        if (!string.IsNullOrEmpty(addurl))
        {
            hypAdd.HRef = ResolveUrl(addurl);
        }
        else
        {
            hypAdd.Visible = false;
        }
    }

    protected void ddlAction_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAction.SelectedValue == "PRINT")
        {
            Control.Base setting = (Control.Base)this.Page;
            ddlAction.SelectedIndex = 0;

            if (setting.Item1 == string.Empty)
            {
                raiseNoRecordSelectedMsg();
                return;
            }

            string strScript = "popwindow('" + setting.GeneratePrintPage() + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Print", strScript, true);
        }
    }

    public void raiseNoRecordSelectedMsg()
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "NoRecordFound", "alert('No selected records to print');", true);
    }
}
