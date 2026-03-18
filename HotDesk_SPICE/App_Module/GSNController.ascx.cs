using System;
using System.Web.UI;
using System.Configuration;

public partial class App_Module_Controller_GSN : System.Web.UI.UserControl
{
    public enum DisplayType
    {
        Full = 3,
        Half = 2,
        Name = 1,
        ID = 0
    }

    #region Audit
    private string _createdcompanycode = string.Empty;
    public string CreatedCompanyCode
    {
        get { return _createdcompanycode; }
        set { _createdcompanycode = value; }
    }

    private string _createdby = string.Empty;
    public string CreatedBy
    {
        get { return _createdby; }
        set { _createdby = value; }
    }

    private DateTime _createdDate = DateTime.Now;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = value; }
    }

    private string _createdLoc = string.Empty;
    public string CreatedLoc
    {
        get { return _createdLoc; }
        set { _createdLoc = value; }
    }

    private string _UpdatedCompanyCode = string.Empty;
    public string UpdatedCompanyCode
    {
        get { return _UpdatedCompanyCode; }
        set { _UpdatedCompanyCode = value; }
    }

    private string _UpdatedBy = string.Empty;
    public string UpdatedBy
    {
        get { return _UpdatedBy; }
        set { _UpdatedBy = value; }
    }

    private DateTime _UpdatedDate = DateTime.Now;
    public DateTime UpdatedDate
    {
        get { return _UpdatedDate; }
        set { _UpdatedDate = value; }
    }

    private string _UpdatedLoc = string.Empty;
    public string UpdatedLoc
    {
        get { return _UpdatedLoc; }
        set { _UpdatedLoc = value; }
    }
    #endregion

    private string _connectionstring = "ORCL_ACL";
    public string connectionstring
    {
        get { return _connectionstring; }
        set { _connectionstring = value; }
    }

    private string _datetimeformat = "dd / MMM / yyyy hh:mm:ss";
    public string DateTimeFormat
    {
        get { return _datetimeformat; }
        set { _datetimeformat = value; }
    }

    /// <summary>
    /// Full - Display Company Code + Employee Name + ID
    /// Half - Display Employee Name + ID
    /// Name - Display Employee Name
    /// ID - Display ID
    /// </summary>
    private DisplayType _AuditTrailDisplayType = DisplayType.ID;
    public DisplayType AuditTrailDisplayType
    {
        get { return _AuditTrailDisplayType; }
        set { _AuditTrailDisplayType = value; }
    }

    private bool _editMode = true;
    private bool _printMode = false;
    private bool _confirmMode = false;
    private bool _EnterPalletM2Mode = false;
    private bool _CancelMode = false;
    private bool _IssuePrintMode = false;
    private bool _MRecPrintMode = false;

    public bool EditMode
    {
        get { return _editMode; }
        set { _editMode = value; }
    }

    public bool PrintMode
    {
        get { return _printMode; }
        set { _printMode = value; }
    }

    public bool IssuePrintMode
    {
        get { return _IssuePrintMode; }
        set { _IssuePrintMode = value; }
    }

    public bool MRecPrintMode
    {
        get { return _MRecPrintMode; }
        set { _MRecPrintMode = value; }
    }

    public bool ConfirmMode
    {
        get { return _confirmMode; }
        set { _confirmMode = value; }
    }

    public bool CancelMode
    {
        get { return _CancelMode; }
        set { _CancelMode = value; }
    }

    public bool EnterPalletM2Mode
    {
        get { return _EnterPalletM2Mode; }
        set { _EnterPalletM2Mode = value; }
    }

    public bool ConfirmReturnMode
    {
        get { return _confirmMode; }
        set { _confirmMode = value; }
    }

    private string _validationGroup;
    public string ValidationGroup
    {
        get { return _validationGroup; }
        set { _validationGroup = value; }
    }

    private bool _add = true;
    public bool Add
    {
        get { return _add; }
        set { _add = value; }
    }

    private bool _edit = true;
    public bool Edit
    {
        get { return _edit; }
        set { _edit = value; }
    }

    private bool _delete = true;
    public bool Delete
    {
        get { return _delete; }
        set { _delete = value; }
    }

    private bool _History = true;
    public bool History
    {
        get { return _History; }
        set { _History = value; }
    }

    private string _Listkey = string.Empty;
    public string ListKey
    {
        get { return _Listkey; }
        set { _Listkey = value; }
    }

    public event Action AddAction;
    public event Action EditAction;
    public event Action DeleteAction;
    public event Action AddResetAction;
    public event Action EditResetAction;
    public event Action ViewEditAction;
    public event Action PrintAction;
    public event Action CloseAction;
    public event Action ConfirmAction;
    public event Action RejectAction;
    public event Action PrintNoteAction;
    public event Action ModifyMode;
    public event Action DisplayMode;
    public event Action EnterPalletM2Action;

    protected void Page_Load(object sender, EventArgs e)
    {
        Control.Base setting = (Control.Base)this.Page;

        hpLink.NavigateUrl = setting.GetUrl(Control.Base.EnumAction.History, ListKey);

        switch (setting.Action)
        {
            case Control.Base.EnumAction.Add:
                btnDelete.Visible = false;
                hpLink.Visible = false;
                pnconfirmation.Visible = false;
                pninfo.Visible = false;
                ModifyMode?.Invoke();
                if (!Add)
                    Response.Redirect(setting.GetUrl(Control.Base.EnumAction.None));
                break;

            case Control.Base.EnumAction.Delete:
                hpLink.Visible = false;
                btnReset.Visible = false;
                btnDelete.Visible = false;
                DisplayMode?.Invoke();
                if (!Delete)
                    Response.Redirect(setting.GetUrl(Control.Base.EnumAction.None));
                break;

            case Control.Base.EnumAction.Edit:
                hpLink.Visible = false;
                btnDelete.Visible = false;
                pnconfirmation.Visible = false;
                ModifyMode?.Invoke();
                if (!Edit)
                    Response.Redirect(setting.GetUrl(Control.Base.EnumAction.None));
                break;

            case Control.Base.EnumAction.View:
                btnSubmit.Text = "Edit";
                btnReset.Visible = false;
                btnSubmit.CausesValidation = false;
                btnDelete.Visible = Delete;
                pnconfirmation.Visible = false;
                DisplayMode?.Invoke();
                break;
        }

        if (!string.IsNullOrEmpty(ValidationGroup))
        {
            btnSubmit.ValidationGroup = ValidationGroup;
            cvdeleteyes.ValidationGroup = ValidationGroup;
            cvdeleteyes.ErrorMessage = Resources.Message.Deletemessage;
        }

        if (pninfo.Visible)
        {
            ACL.Object.User _createdtemp = null;
            ACL.Object.User _updatedtemp = null;

            if (!IsPostBack)
            {
                if (AuditTrailDisplayType == DisplayType.Full)
                {
                    if (CreatedCompanyCode == string.Empty)
                        throw new Exception("Please set value into properties created company code");
                    if (UpdatedCompanyCode == string.Empty)
                        throw new Exception("Please set value into properties updated company code");
                }

                if (CreatedBy == string.Empty)
                    throw new Exception("Please set value into properties created by");
                if (UpdatedBy == string.Empty)
                    throw new Exception("Please set value into properties updated by");

                switch (AuditTrailDisplayType)
                {
                    case DisplayType.Full:
                        _createdtemp = ACL.OracleClass.User.UserInfo(ConfigurationManager.ConnectionStrings[connectionstring].ConnectionString, CreatedCompanyCode, CreatedBy);
                        _updatedtemp = ACL.OracleClass.User.UserInfo(ConfigurationManager.ConnectionStrings[connectionstring].ConnectionString, CreatedCompanyCode, UpdatedBy);
                        break;
                    case DisplayType.Half:
                    case DisplayType.Name:
                        _createdtemp = CreatedCompanyCode != string.Empty
                            ? ACL.OracleClass.User.UserInfo(ConfigurationManager.ConnectionStrings[connectionstring].ConnectionString, CreatedCompanyCode, CreatedBy)
                            : ACL.OracleClass.User.UserInfo(ConfigurationManager.ConnectionStrings[connectionstring].ConnectionString, CreatedBy);
                        _updatedtemp = UpdatedCompanyCode != string.Empty
                            ? ACL.OracleClass.User.UserInfo(ConfigurationManager.ConnectionStrings[connectionstring].ConnectionString, UpdatedCompanyCode, UpdatedBy)
                            : ACL.OracleClass.User.UserInfo(ConfigurationManager.ConnectionStrings[connectionstring].ConnectionString, UpdatedBy);
                        break;
                }

                string _createdtext = string.Empty;
                string _updatedtext = string.Empty;

                if (AuditTrailDisplayType == DisplayType.Full)
                {
                    if (_createdtemp != null && _createdtemp.UserCom != string.Empty)
                    {
                        trcreatecom.Visible = true;
                        lblcreatedcom.Text = ACL.OracleClass.User.GetCompany(ConfigurationManager.ConnectionStrings[connectionstring].ConnectionString, _createdtemp.UserCom);
                    }
                    if (_updatedtemp != null && _updatedtemp.UserCom != string.Empty)
                    {
                        trupdatecom.Visible = true;
                        lblupdatedcom.Text = ACL.OracleClass.User.GetCompany(ConfigurationManager.ConnectionStrings[connectionstring].ConnectionString, _updatedtemp.UserCom);
                    }
                }

                if (AuditTrailDisplayType != DisplayType.Name)
                {
                    _createdtext = GenerateText(_createdtext, " ID : " + CreatedBy);
                    _updatedtext = GenerateText(_updatedtext, " ID : " + UpdatedBy);
                }

                if (_createdtemp != null && _createdtemp.EmployeeName != string.Empty)
                    _createdtext = GenerateText(_createdtext, " Name : " + _createdtemp.EmployeeName);

                if (_updatedtemp != null && _updatedtemp.EmployeeName != string.Empty)
                    _updatedtext = GenerateText(_updatedtext, " Name : " + _updatedtemp.EmployeeName);

                lblcreatedby.Text = _createdtext;
                lblcreateddate.Text = CreatedDate.ToString(DateTimeFormat);
                lblcreatedloc.Text = CreatedLoc;

                lblupdatedby.Text = _updatedtext;
                lblupdateddate.Text = UpdatedDate.ToString(DateTimeFormat);
                lblUpdatedloc.Text = UpdatedLoc;
            }
        }

        if (!EditMode)
        {
            btnSubmit.Visible = false;
            btnDelete.Visible = false;
        }
        if (IssuePrintMode)
        {
            btnPrint.Visible = true;
            btnSubmit.Visible = false;
            btnDelete.Visible = false;
            btnReset.Visible = false;
        }
        if (MRecPrintMode)
        {
            btnPrint.Visible = true;
        }
        if (PrintMode)
        {
            btnPrint.Visible = true;
            btnclose.Visible = true;
            btnCancel.Visible = false;
        }
        if (ConfirmMode)
        {
            btnconfirm.Visible = true;
            btnreject.Visible = true;
            btnCancel.Visible = true;
            btnSubmit.Visible = false;
            btnDelete.Visible = false;
            btnReset.Visible = false;
        }
        if (EnterPalletM2Mode)
        {
            btnPrint.Visible = true;
            btnclose.Visible = true;
            btnEnterM2.Visible = true;
            btnCancel.Visible = false;
        }
        if (CancelMode)
        {
            btnSubmit.Visible = false;
            btnDelete.Visible = false;
            btnReset.Visible = false;
        }
        if (ConfirmReturnMode)
        {
            btnconfirm.Visible = true;
            btnreject.Visible = true;
            btnCancel.Visible = true;
            btnprintnote.Visible = false;
            btnSubmit.Visible = false;
            btnDelete.Visible = false;
            btnReset.Visible = false;
        }
    }

    private string GenerateText(string Value, string AddText)
    {
        if (Value.Length > 0)
            return Value + " - " + AddText;
        else
            return AddText;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Control.Base setting = (Control.Base)this.Page;
        Response.Redirect(setting.GetUrl(Control.Base.EnumAction.None));
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Control.Base setting = (Control.Base)this.Page;
        Response.Redirect(setting.GetUrl(Control.Base.EnumAction.Delete));
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Control.Base setting = (Control.Base)this.Page;
        switch (setting.Action)
        {
            case Control.Base.EnumAction.Delete:
                DeleteAction?.Invoke();
                break;
            case Control.Base.EnumAction.Add:
                AddAction?.Invoke();
                break;
            case Control.Base.EnumAction.Edit:
                EditAction?.Invoke();
                break;
            case Control.Base.EnumAction.View:
                ViewEditAction?.Invoke();
                Response.Redirect(setting.GetUrl(Control.Base.EnumAction.Edit));
                break;
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Control.Base setting = (Control.Base)this.Page;
        switch (setting.Action)
        {
            case Control.Base.EnumAction.Add:
                AddResetAction?.Invoke();
                break;
            case Control.Base.EnumAction.Edit:
                EditResetAction?.Invoke();
                break;
        }
    }

    protected void cvdeleteyes_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        args.IsValid = rbyes.Checked;
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Control.Base setting = (Control.Base)this.Page;
        if (setting.Action == Control.Base.EnumAction.View)
            PrintAction?.Invoke();
    }

    protected void btnclose_Click(object sender, EventArgs e)
    {
        Control.Base setting = (Control.Base)this.Page;
        if (setting.Action == Control.Base.EnumAction.View)
            CloseAction?.Invoke();
    }

    protected void btnconfirm_Click(object sender, EventArgs e)
    {
        Control.Base setting = (Control.Base)this.Page;
        if (setting.Action == Control.Base.EnumAction.Edit)
            ConfirmAction?.Invoke();
    }

    protected void btnreject_Click(object sender, EventArgs e)
    {
        Control.Base setting = (Control.Base)this.Page;
        if (setting.Action == Control.Base.EnumAction.Edit)
            RejectAction?.Invoke();
    }

    protected void btnprintnote_Click(object sender, EventArgs e)
    {
        Control.Base setting = (Control.Base)this.Page;
        if (setting.Action == Control.Base.EnumAction.Edit)
            PrintNoteAction?.Invoke();
    }

    protected void btnEnterM2_Click(object sender, EventArgs e)
    {
        Control.Base setting = (Control.Base)this.Page;
        if (setting.Action == Control.Base.EnumAction.View)
            EnterPalletM2Action?.Invoke();
    }
}
