using System;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class _Default : System.Web.UI.Page
{
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Response.Redirect("~/Menu/Menu.aspx");
        }
    }

    protected void cusCustom_ServerValidate(object sender, ServerValidateEventArgs e)
    {
        try
        {
            systemCheck();

            var temp = new ACL.OracleClass.User(System.Configuration.ConfigurationManager.ConnectionStrings["ORCL_ACL"].ConnectionString);
            var userobj = new ACL.Object.User();

            if (System.Configuration.ConfigurationManager.AppSettings["CrossCompany"] == "1")
            {
                userobj = temp.validateWithRetrieveUsernCompany(
                    ddlcompany.SelectedValue,
                    txtusername.Text.Trim(),
                    txtpassword.Text.Trim(),
                    Convert.ToInt32(Session["system"]));
            }
            else
            {
                userobj = temp.validateWithRetrieveUser(
                    txtusername.Text.Trim(),
                    txtpassword.Text.Trim(),
                    Convert.ToInt32(Session["system"]));
            }

            if (Convert.ToInt32(userobj.UserID) > -1)
            {
                Session["gstrUserID"] = "admin";
                Session["gettemp"] = userobj.EmployeeName;
                Session["gstrUsername"] = txtusername.Text.Trim();
                Session["gstrPassword"] = txtpassword.Text.Trim();
                Session["LoginHis"] = DateTime.Now.ToString("dd MMMM yyyy");
                Session["gstrUserCom"] = userobj.UserCom;
                Session["gstrUserCompCode"] = userobj.UserCom;
                Session["com"] = userobj.UserCom;
                Session["Barcodechecking"] = txtusername.Text.Trim().ToUpper();
                e.IsValid = true;
            }
            else
            {
                e.IsValid = false;
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('- Invalid username and password ');", true);
            }
        }
        catch (Exception)
        {
            e.IsValid = false;
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('- Invalid username and password ');", true);
        }
    }

    private void systemCheck()
    {
        Session["system"] = 0;
        Session["system"] = ACL.OracleClass.Resource.RetrieveApplicationIDByName(
            System.Configuration.ConfigurationManager.ConnectionStrings["ORCL_ACL"].ConnectionString,
            System.Configuration.ConfigurationManager.AppSettings["SystemName"]);

        if (Session["system"].ToString() == "0")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invalid System');", true);
            return;
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ACL.Control.Binding.BindCompany(
                System.Configuration.ConfigurationManager.ConnectionStrings["ORCL_ACL"].ConnectionString,
                ddlcompany);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Abandon();
            Session.Clear();
            trcompanyselection.Visible = System.Configuration.ConfigurationManager.AppSettings["CrossCompany"] == "1";
        }

        txtusername.Focus();
    }
}
