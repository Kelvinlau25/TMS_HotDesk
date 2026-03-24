using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Acc_MenuNavigationSpice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlhd.Controls.Clear();
        int i1 = 0, i2 = 0, ii = 0, iii = 0;

        for (ii = 1; ii <= 35; ii++)
        {
            var label = new Button();
            label.ID = "label" + ii;
            label.Attributes.Add("class", "label" + ii);
            label.Enabled = false;
            label.Visible = false;
            pnlhd1.Controls.Add(label);
        }

        for (iii = 36; iii <= 55; iii++)
        {
            var label = new Button();
            label.ID = "label" + iii;
            label.Attributes.Add("class", "label" + iii);
            label.Enabled = false;
            label.Visible = false;
            pnlhd2.Controls.Add(label);
        }

        DataTable lst = BLL.MenuNavSpice.GetIDList();

        for (i1 = 1; i1 <= lst.Rows.Count; i1++)
        {
            var hd = new HtmlInputHidden();
            hd.ID = "hi" + i1;
            hd.Attributes.Add("class", "hi" + i1);
            pnlhd.Controls.Add(hd);
        }

        for (i2 = 0; i2 <= lst.Rows.Count - 1; i2++)
        {
            int colcount = 0;
            bool chkcol = false;
            if (lst.Rows[i2]["SEAT_STATUS"].ToString().ToUpper() == "Y")
                chkcol = true;

            var hf = (HtmlInputHidden)pnlhd.FindControl("hi" + (i2 + 1));
            var labelvalue = (Button)pnlhd1.FindControl("label" + (i2 + 1));
            var labelvalue2 = (Button)pnlhd2.FindControl("label" + (i2 + 1));

            hf.Value = "0";
            if (labelvalue != null) labelvalue.Text = null;
            if (labelvalue2 != null) labelvalue2.Text = null;

            if (chkcol)
            {
                chkcol = false;
                if (hf != null)
                {
                    colcount++;
                    hf.Value = colcount.ToString() + " " + lst.Rows[i2]["SEAT_STATUS"].ToString();
                    if (labelvalue != null)
                    {
                        labelvalue.Text = lst.Rows[i2]["SEAT_OWNER"].ToString();
                        labelvalue.Enabled = true;
                        labelvalue.Visible = true;
                    }
                    if (labelvalue2 != null)
                    {
                        labelvalue2.Text = lst.Rows[i2]["SEAT_OWNER"].ToString();
                        labelvalue2.Enabled = true;
                        labelvalue2.Visible = true;
                    }
                }
            }
        }
    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {
        if (btnCheck.Text == "Check")
            Session["Check"] = "True";
        Response.Redirect("PopUp/ListSpice.aspx");
    }

    [System.Web.Services.WebMethod]
    public static string testing(string checktype, string staffName, string seatName)
    {
        var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString);
        SqlDataReader temp = null;
        var cmd = new SqlCommand();

        conn.Open();
        SqlTransaction tran = conn.BeginTransaction();

        try
        {
            cmd.Transaction = tran;
            cmd.Connection = conn;
            cmd.CommandText = "SP_TMS_UPDATE_SEAT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;

            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@checkType", checktype)).Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(new SqlParameter("@PstaffName", staffName)).Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(new SqlParameter("@seat", seatName)).Direction = System.Data.ParameterDirection.Input;
            cmd.Parameters.Add(new SqlParameter("@return_value", SqlDbType.NVarChar, 4000)).Direction = System.Data.ParameterDirection.Output;

            temp = cmd.ExecuteReader();
            tran.Commit();
        }
        catch (Exception)
        {
            // Error handling
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }

        return cmd.Parameters["@return_value"].Value.ToString();
    }
}
