using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Acc_PopUp_LastArm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        load_OUT_STAFF();
    }

    protected void load_OUT_STAFF()
    {
        var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString);
        var dt = new DataTable();
        SqlDataReader temp = null;
        var cmd = new SqlCommand();

        conn.Open();
        try
        {
            cmd.Connection = conn;
            cmd.CommandText = "SP_GET_ARM_SPICE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            temp = cmd.ExecuteReader();
            dt.Load(temp);

            grdResult.DataSource = dt;
            grdResult.DataBind();
        }
        catch (Exception)
        {
            // Error handling
        }
        finally
        {
            conn.Close();
        }
    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdResult.PageIndex = e.NewPageIndex;
        grdResult.DataBind();
    }
}
