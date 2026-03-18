public partial class App_Module_Title : System.Web.UI.UserControl
{
    private bool _audit = false;
    public bool Audit
    {
        set { _audit = value; }
    }

    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (_audit == false)
        {
            var setting = (Control.Base)this.Page;
            this.lblFormTitle.Text = setting.DisplayTitle + (setting.Action != Control.Base.EnumAction.None ? " - " : string.Empty) + setting.ActionDesc;
        }
        else
        {
            var setting = (Control.LogBase)this.Page;
            this.lblFormTitle.Text = setting.DisplayTitle;
        }
    }
}
