Partial Class App_Module_ConfirmPassword
    Inherits BaseUserControl
#Region "Properties"
    Public Property Password() As String
        Get
            Return txtPassword.Text
        End Get
        Set(ByVal value As String)
            txtPassword.Text = value
        End Set
    End Property

    Public Property ConfirmPassword() As String
        Get
            Return txtConPassword.Text
        End Get
        Set(ByVal value As String)
            txtConPassword.Text = value
        End Set
    End Property
#End Region
#Region "Methods"
    Public Sub BindSetting()
        REM assign validation group to multiple controls
        txtConPassword.ValidationGroup = MyBase.ValidationGroup
        txtPassword.ValidationGroup = MyBase.ValidationGroup
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
