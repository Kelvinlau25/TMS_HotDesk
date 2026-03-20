using System;
using Library.Database;

public partial class Acc_PopUp_ListSpice : Control.Base
{
    private ListCollection _list;
    protected string _staffID = string.Empty;
    protected string _staffName = string.Empty;

    public Acc_PopUp_ListSpice()
    {
        base.SetupKey = "HOTSEAT";
        base.DefaultSort = "STAFF_ID";
        base.GridViewCheckColumn = false;
        base.PrintControl = false;
        base.ViewHistoryControl = false;
        base.DeleteControl = false;
        base.GridViewRadioColumn = false;
        base.AddControl = false;
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        base.GridView = grdResult;
    }

    public override void BindData()
    {
        _list = global::BLL.HotSeatSpice.List(base.PageNo);
        grdResult.DataSource = _list.Data;
        grdResult.DataBind();

        UCFooter.TotalRecords = _list.TotalRow;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        _staffID = base.Item1;
        _staffName = base.Item2;
    }
}