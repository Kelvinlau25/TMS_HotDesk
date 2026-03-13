
Partial Class App_Module_RangeValidator
    Inherits BaseUserControl
#Region "Variables"
    Private _dateType As String
#End Region
#Region "Properties"
    Public Property Text1() As String
        Get
            Return txtbox1.Text
        End Get
        Set(ByVal value As String)
            txtbox1.Text = value
        End Set
    End Property

    Public Property Text2() As String
        Get
            Return txtbox2.Text
        End Get
        Set(ByVal value As String)
            txtbox2.Text = value
        End Set
    End Property
    Public Property DataType() As ValidationDataType
        Get
            Return Me._dateType
        End Get
        Set(ByVal value As ValidationDataType)
            Me._dateType = value
        End Set
    End Property
#End Region
#Region "Methods"
    Public Sub BindSetting()
        REM assign validation group to multiple controls
        txtbox1.ValidationGroup = MyBase.ValidationGroup
        txtbox2.ValidationGroup = MyBase.ValidationGroup
        rfBox1.ValidationGroup = MyBase.ValidationGroup
        rfbox2.ValidationGroup = MyBase.ValidationGroup
        cvRange.ValidationGroup = MyBase.ValidationGroup
        cvRange.Type = Me.DataType
        cvCheckType1.ValidationGroup = MyBase.ValidationGroup
        cvCheckType1.Type = Me.DataType
        cvCheckType2.ValidationGroup = MyBase.ValidationGroup
        cvCheckType2.Type = Me.DataType

    End Sub
    Public Sub BindData()
        txtbox1.Text = txtbox1.Text
        txtbox2.Text = txtbox2.Text
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
