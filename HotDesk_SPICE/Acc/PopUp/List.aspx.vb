Partial Class Acc_PopUp_List
    Inherits Control.Base
    Dim _list As Library.Database.ListCollection
    Protected _staffID As String = String.Empty
    Protected _staffName As String = String.Empty

    Public Sub New()
        MyBase.SetupKey = "HOTSEAT"
        MyBase.DefaultSort = "STAFF_ID"
        MyBase.GridViewCheckColumn = False
        MyBase.PrintControl = False
        MyBase.ViewHistoryControl = False
        MyBase.DeleteControl = False
        MyBase.GridViewRadioColumn = False
        MyBase.AddControl = False
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        MyBase.GridView = grdResult

    End Sub

    Public Overrides Sub BindData()

        _list = Library.Database.BLL.HotSeat.List(MyBase.PageNo)
        grdResult.DataSource = _list.Data
        grdResult.DataBind()

        UCFooter.TotalRecords = _list.TotalRow
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _staffID = MyBase.Item1
        _staffName = MyBase.Item2

    End Sub


End Class
