''' <summary>
''' Add User Control
''' 
''' Additional
''' ----------------------------------------
''' if the URL Doest not Containt the Sort Direction and Sort Field then will generate and redirect to default value
''' 
''' Remark : Based on previous version and modified the way of the binding
''' ----------------------------------------
''' C.C.Yeon    25 APril 2011  Modified 
''' </summary>
''' <remarks></remarks>
Partial Class UserControl_GridHeader
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'code to check which button in the web user control is clicked
        'then base on the get property to get the value
        'will get the filter criteria
        'need to store the type in global variable so that the user control page can bind the dropdown list
        'with the correct value

        If Not IsPostBack Then
            Me.BindHyperLink()
        End If

        Dim _page As Control.Base = CType(Me.Page, Control.Base)
        hypAdd.Visible = _page.AddControl
        ddlAction.Visible = _page.PrintControl
    End Sub

    Protected Sub BindHyperLink()
        'Retrieve the value of the properties from the page
        'Retrieve the value from the resource base on the key and set the url into hpyadd Component
        ddlAction.Visible = False
        Dim setting As Control.Base = CType(Me.Page, Control.Base)
        Dim addurl As String = setting.GetUrl(Control.Base.EnumAction.Add)
        If Not String.IsNullOrEmpty(addurl) Then
            hypAdd.HRef = ResolveUrl(addurl)
        Else
            hypAdd.Visible = False
        End If
    End Sub

    Protected Sub ddlAction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAction.SelectedIndexChanged
        If (Me.ddlAction.SelectedValue = "PRINT") Then
            Dim setting As Control.Base = CType(Me.Page, Control.Base)
            ddlAction.SelectedIndex = 0

            If setting.Item1 = String.Empty Then
                raiseNoRecordSelectedMsg()
                Exit Sub
            End If

            Dim strScript As String = "popwindow('" + setting.GeneratePrintPage + "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Print", strScript, True)
        End If
    End Sub

    Public Sub raiseNoRecordSelectedMsg()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "NoRecordFound", "alert('No selected records to print');", True)
    End Sub
End Class
