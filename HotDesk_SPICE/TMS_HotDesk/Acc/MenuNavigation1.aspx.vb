

Imports System.Data
Imports System.Data.SqlClient

Partial Class Acc_MenuNavigation1
    Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            For i = 1 To 51
                Dim hd As New HtmlInputHidden
                hd.ID = "hi" & i
                hd.Attributes.Add("class", "hi" & i)
                pnlhd.Controls.Add(hd)

            Next

            Dim lst As DataTable = Library.Database.BLL.MenuNav.GetIDList

            For i = 0 To lst.Rows.Count - 1
                Dim colcount As Integer = 0
                Dim chkcol As Boolean = False
                Dim GID = ""
                If lst.Rows(i)("SEAT_STATUS").ToString.ToUpper.Equals("Y") Then
                    chkcol = True
                End If

                If chkcol Then
                    chkcol = False
                    Dim hf As HtmlInputHidden = DirectCast(pnlhd.FindControl("hi" & (i + 1)), HtmlInputHidden)
                    If Not hf Is Nothing Then
                        colcount = colcount + 1
                        hf.Value = colcount.ToString + " " + lst.Rows(i)("SEAT_STATUS").ToString
                    End If
                End If

            Next

            'load_OUT_STAFF()


        End Sub

        Protected Sub btnCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCheck.Click
            If btnCheck.Text = "Check" Then
                Session("Check") = "True"
            End If

            Response.Redirect("PopUp/List.aspx")
        End Sub

        <System.Web.Services.WebMethod()> _
        Public Shared Function testing(ByVal checktype As String, ByVal staffName As String, ByVal seatName As String) As String
            Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("SQLCon").ConnectionString)
            Dim dt As New DataTable
            Dim temp As SqlDataReader
            Dim cmd As New SqlCommand

            conn.Open()
            Try
                cmd.Connection = conn
                cmd.CommandText = "SP_TMS_UPDATE_SEAT"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandTimeout = 0

                cmd.Parameters.Clear()
                cmd.Parameters.Add(New SqlParameter("@checkType", checktype)).Direction = Data.ParameterDirection.Input
                cmd.Parameters.Add(New SqlParameter("@PstaffName", staffName)).Direction = Data.ParameterDirection.Input
                cmd.Parameters.Add(New SqlParameter("@seat", seatName)).Direction = Data.ParameterDirection.Input
                cmd.Parameters.Add(New SqlParameter("@return_value", SqlDbType.NVarChar, 4000)).Direction = ParameterDirection.Output

                temp = cmd.ExecuteReader

            Catch ex As Exception
                MsgBox(ex.ToString)
                'MessageBox.Show("ERROR")
            Finally
                conn.Close()
                conn.Dispose()
            End Try

            Return cmd.Parameters("@return_value").Value.ToString

        End Function



    End Class
