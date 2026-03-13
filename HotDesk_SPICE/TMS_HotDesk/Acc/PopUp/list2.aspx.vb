Imports System.Data
Imports System.Data.SqlClient

Partial Class Acc_PopUp_list2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        load_OUT_STAFF()
    End Sub



    Protected Sub load_OUT_STAFF()
        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("SQLCon").ConnectionString)
        Dim dt As New DataTable
        Dim temp As SqlDataReader
        Dim cmd As New SqlCommand

        conn.Open()
        Try
            cmd.Connection = conn
            cmd.CommandText = "SP_GET_NO_OUT_STAFF_PRAI"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0

            cmd.Parameters.Clear()
            temp = cmd.ExecuteReader
            dt.Load(temp)

            grdResult.DataSource = dt
            grdResult.DataBind()

        Catch ex As Exception
            'MsgBox(ex.ToString)
            'MessageBox.Show("ERROR")
        Finally
            conn.Close()
        End Try

    End Sub


    'Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResult.RowDataBound
    '    If (e.Row.RowType = DataControlRowType.DataRow) Then
    '        'assuming that the required value column is the second column in gridview
    '        DirectCast(e.Row.FindControl("btnSelect"), Button).Attributes.Add("onclick", "javascript:GetRowValue('" & e.Row.Cells(1).Text & "')")
    '    End If
    'End Sub

    Protected Sub OnPageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        grdResult.PageIndex = e.NewPageIndex
        grdResult.DataBind()
    End Sub

End Class
