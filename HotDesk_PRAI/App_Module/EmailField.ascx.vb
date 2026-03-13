Partial Class App_Module_EmailField
    Inherits BaseUserControl

#Region "Variables"
    Private _cssClass As String
#End Region

#Region "Properties"
    Public Property Text() As String
        Get
            Return txtEmail.Text
        End Get
        Set(ByVal value As String)
            txtEmail.Text = value
        End Set
    End Property

    Public Property CssClass() As String
        Get
            Return pnlEmail.Visible
        End Get
        Set(ByVal value As String)
            pnlEmail.Visible = value
        End Set
    End Property
#End Region

#Region "Methods"
    Public Sub BindSetting()
        REM assign validation group to multiple controls
        txtEmail.ValidationGroup = MyBase.ValidationGroup
        reEmail.ValidationGroup = MyBase.ValidationGroup
        rfEmail.ValidationGroup = MyBase.ValidationGroup
    End Sub
#End Region

#Region "Events"
#Region "Overrides"
    Public Overrides Sub DataBind()
        Me.BindSetting()
        MyBase.DataBind()
    End Sub
#End Region
#End Region

End Class
