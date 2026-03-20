public partial class App_Module_ConfirmPassword : BaseUserControl
{
    #region Properties
    public string Password
    {
        get { return txtPassword.Text; }
        set { txtPassword.Text = value; }
    }

    public string ConfirmPassword
    {
        get { return txtConPassword.Text; }
        set { txtConPassword.Text = value; }
    }
    #endregion

    #region Methods
    public void BindSetting()
    {
        txtConPassword.ValidationGroup = base.ValidationGroup;
        txtPassword.ValidationGroup = base.ValidationGroup;
    }
    #endregion

    public override void DataBind()
    {
        this.BindSetting();
        base.DataBind();
    }
}
