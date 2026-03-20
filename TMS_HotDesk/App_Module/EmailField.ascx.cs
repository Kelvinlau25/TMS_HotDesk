public partial class App_Module_EmailField : BaseUserControl
{
    #region Variables
    private string _cssClass;
    #endregion

    #region Properties
    public string Text
    {
        get { return txtEmail.Text; }
        set { txtEmail.Text = value; }
    }

    public bool CssClass
    {
        get { return pnlEmail.Visible; }
        set { pnlEmail.Visible = value; }
    }
    #endregion


    public void BindSetting()
    {
        txtEmail.ValidationGroup = base.ValidationGroup;
        reEmail.ValidationGroup = base.ValidationGroup;
        rfEmail.ValidationGroup = base.ValidationGroup;
    }

    public override void DataBind()
    {
        this.BindSetting();
        base.DataBind();
    }
}
