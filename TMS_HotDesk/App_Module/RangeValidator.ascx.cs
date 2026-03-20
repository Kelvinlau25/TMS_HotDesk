using System.Web.UI.WebControls;

public partial class App_Module_RangeValidator : BaseUserControl
{
    #region Variables
    private ValidationDataType _dateType;
    #endregion

    #region Properties
    public string Text1
    {
        get { return txtbox1.Text; }
        set { txtbox1.Text = value; }
    }

    public string Text2
    {
        get { return txtbox2.Text; }
        set { txtbox2.Text = value; }
    }

    public ValidationDataType DataType
    {
        get { return this._dateType; }
        set { this._dateType = value; }
    }
    #endregion

    public void BindSetting()
    {
        txtbox1.ValidationGroup = base.ValidationGroup;
        txtbox2.ValidationGroup = base.ValidationGroup;
        rfBox1.ValidationGroup = base.ValidationGroup;
        rfbox2.ValidationGroup = base.ValidationGroup;
        cvRange.ValidationGroup = base.ValidationGroup;
        cvRange.Type = this.DataType;
        cvCheckType1.ValidationGroup = base.ValidationGroup;
        cvCheckType1.Type = this.DataType;
        cvCheckType2.ValidationGroup = base.ValidationGroup;
        cvCheckType2.Type = this.DataType;
    }

    public void BindData()
    {
        txtbox1.Text = txtbox1.Text;
        txtbox2.Text = txtbox2.Text;
    }

    public override void DataBind()
    {
        this.BindSetting();
        base.DataBind();
    }
}
