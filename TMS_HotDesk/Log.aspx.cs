using System;
using System.Web.UI;

public partial class Log : Control.LogBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        divDesc.InnerHtml = "<b>History of " + base.NormalTitle + "</b> - <br/>" + base.KeyDesc;
    }

    protected override void BindData()
    {
        // _list = Library.Database.barcode.BLL.Log.GetLogList(base.LogTable, base.Key, base.PageNo, base.SortDesc);
        // grdResult.DataSource = _list.Data;
        // grdResult.DataBind();
        // UCFooter.TotalRecords = _list.TotalRow;
    }
}
