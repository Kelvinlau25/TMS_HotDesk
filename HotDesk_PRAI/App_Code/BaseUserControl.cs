public class BaseUserControl : System.Web.UI.UserControl
{
    #region Variables
    private string _validationGroup;
    #endregion

    #region Properties
    public string ValidationGroup
    {
        get { return this._validationGroup; }
        set { this._validationGroup = value; }
    }
    #endregion
}
