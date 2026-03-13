Public Class BaseUserControl
    Inherits System.Web.UI.UserControl
#Region "Variables"
    Private _validationGroup As String

#End Region
#Region "Properties"
    Public Property ValidationGroup() As String
        Get
            Return Me._validationGroup
        End Get
        Set(ByVal value As String)
            Me._validationGroup = value
        End Set
    End Property
#End Region

End Class
