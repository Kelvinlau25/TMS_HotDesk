Imports System.Data
Imports System.Data.SqlClient

Partial Class Acc_MenuNavigation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        pnlhd.Controls.Clear()
        Dim i1 = 0
        Dim i2 = 0
        Dim ii = 0
        Dim iii = 0
        Dim iv = 0
        Dim v = 0



        Dim lst As New DataTable
        lst = Library.Database.BLL.MenuNav.GetIDList

        For i1 = 1 To lst.Rows.Count
            Dim hd As New HtmlInputHidden
            hd.ID = "hi" & i1
            hd.Attributes.Add("class", "hi" & i1)
            pnlhd.Controls.Add(hd)

        Next

        For ii = 1 To 28
            Dim label As New Button
            If ii = 26 Then ' id 26 has assign to east wing 
                label.ID = "label" & ii
                label.Attributes.Add("class", "label" & ii)
                label.Enabled = False
                label.Visible = False
                pnlhd2.Controls.Add(label)
                Continue For
            End If

            label.ID = "label" & ii
            label.Attributes.Add("class", "label" & ii)
            label.Enabled = False
            label.Visible = False
            pnlhd1.Controls.Add(label)

        Next

        'For iii = 29 To 41
        '    Dim label As New Button
        '    label.ID = "label" & iii
        '    label.Attributes.Add("class", "label" & iii)
        '    label.Enabled = False
        '    label.Visible = False
        '    pnlhd2.Controls.Add(label)

        'Next

        For iii = 29 To lst.Rows.Count
            Dim label As New Button

            '42 - 61
            If iii > 41 And iii < 62 Then ' for id after east wing 
                label.ID = "label" & iii
                label.Attributes.Add("class", "label" & iii)
                label.Enabled = False
                label.Visible = False
                pnlhd3.Controls.Add(label)
                Continue For
            End If

            '66 - 69
            If iii > 65 And iii < 72 Then ' for new id at west wing 
                label.ID = "label" & iii
                label.Attributes.Add("class", "label" & iii)
                label.Enabled = False
                label.Visible = False
                pnlhd1.Controls.Add(label)
                Continue For
            End If

            label.ID = "label" & iii
            label.Attributes.Add("class", "label" & iii)
            label.Enabled = False
            label.Visible = False
            pnlhd2.Controls.Add(label)



        Next

        'For iv = 42 To lst.Rows.Count
        '    Dim label As New Button

        '    '62-65
        '    If iv >= 62 & iv <= 65 Then ' for new id at east wing 
        '        label.ID = "label" & iv
        '        label.Attributes.Add("class", "label" & iv)
        '        label.Enabled = False
        '        label.Visible = False
        '        pnlhd2.Controls.Add(label)
        '        Continue For
        '    End If

        '    '66 - 69
        '    If iv >= 66 & iv <= 69 Then ' for new id at west wing 
        '        label.ID = "label" & iv
        '        label.Attributes.Add("class", "label" & iv)
        '        label.Enabled = False
        '        label.Visible = False
        '        pnlhd1.Controls.Add(label)
        '        Continue For
        '    End If

        '    label.ID = "label" & iv
        '    label.Attributes.Add("class", "label" & iv)
        '    label.Enabled = False
        '    label.Visible = False
        '    pnlhd3.Controls.Add(label)

        'Next

        For i2 = 0 To lst.Rows.Count - 1

                           Dim colcount As Integer = 0
                           Dim chkcol As Boolean = False
                           Dim chkcol2 As Boolean = False
                           Dim GID = ""
            'modified by ChristopherLeong_29 April 2020 - remove map8 (helpdesk) so it behave normally
            ' lst.Rows(i2)("SEAT_NAME").ToString.ToUpper.Equals("MAP8")
            'If lst.Rows(i2)("SEAT_NAME").ToString.ToUpper.Equals("MAP46") Or lst.Rows(i2)("SEAT_NAME").ToString.ToUpper.Equals("MAP53") Then
            '         chkcol2 = True
            'End If
            If lst.Rows(i2)("SEAT_STATUS").ToString.ToUpper.Equals("Y") Then
                                    chkcol = True
                           End If
                           Dim hf As HtmlInputHidden = DirectCast(pnlhd.FindControl("hi" & (i2 + 1)), HtmlInputHidden)
                           Dim labelvalue As Button = DirectCast(pnlhd1.FindControl("label" & (i2 + 1)), Button)
                           Dim labelvalue2 As Button = DirectCast(pnlhd2.FindControl("label" & (i2 + 1)), Button)
                           Dim labelvalue3 As Button = DirectCast(pnlhd3.FindControl("label" & (i2 + 1)), Button)
                           hf.Value = 0
                           labelvalue.Text = Nothing
                           labelvalue2.Text = Nothing
                           If chkcol Then
                                    chkcol = False
                                    'Dim hf As HtmlInputHidden = DirectCast(pnlhd.FindControl("hi" & (i2 + 1)), HtmlInputHidden)
                                    If Not hf Is Nothing Then
                                             colcount = colcount + 1
                                             hf.Value = colcount.ToString + " " + lst.Rows(i2)("SEAT_STATUS").ToString
                                             labelvalue.Text = lst.Rows(i2)("SEAT_OWNER").ToString
                                             labelvalue2.Text = lst.Rows(i2)("SEAT_OWNER").ToString
                                             labelvalue.Enabled = True
                                             labelvalue.Visible = True
                                             labelvalue2.Enabled = True
                                             labelvalue2.Visible = True

                                    End If
                           End If
            'If chkcol2 Then
            '    chkcol2 = False
            '    If Not hf Is Nothing Then
            '        colcount = colcount + 1
            '        hf.Value = "2" + " " + "2"
            '        If lst.Rows(i2)("SEAT_NAME").ToString.ToUpper.Equals("MAP8") Then
            '            labelvalue.Text = lst.Rows(i2)("SEAT_OWNER").ToString
            '        Else
            '            labelvalue.Text = "Think Space"
            '        End If


            '        labelvalue.Enabled = True
            '        labelvalue.Visible = True



            '    End If
            'End If

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
        Dim tran As SqlTransaction = conn.BeginTransaction

        Try
            cmd.Transaction = tran
            cmd.Connection = conn
            cmd.CommandText = "SP_TMS_UPDATE_SEAT_PRAI"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0

            cmd.Parameters.Clear()
            cmd.Parameters.Add(New SqlParameter("@checkType", checktype)).Direction = Data.ParameterDirection.Input
            cmd.Parameters.Add(New SqlParameter("@PstaffName", staffName)).Direction = Data.ParameterDirection.Input
            cmd.Parameters.Add(New SqlParameter("@seat", seatName)).Direction = Data.ParameterDirection.Input
            cmd.Parameters.Add(New SqlParameter("@return_value", SqlDbType.NVarChar, 4000)).Direction = ParameterDirection.Output

            temp = cmd.ExecuteReader
            tran.Commit()
        Catch ex As Exception
            MsgBox(ex.ToString)
            'MessageBox.Show("ERROR")
        Finally
            conn.Close()
            conn.Dispose()
        End Try

        Return cmd.Parameters("@return_value").Value.ToString


        'Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)

    End Function

    'Protected Sub load_OUT_STAFF()
    '    Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("SQLCon").ConnectionString)
    '    Dim dt As New DataTable
    '    Dim temp As SqlDataReader
    '    Dim cmd As New SqlCommand

    '    conn.Open()
    '    Try
    '        cmd.Connection = conn
    '        cmd.CommandText = "SP_GET_NO_OUT_STAFF"
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandTimeout = 0

    '        cmd.Parameters.Clear()
    '        temp = cmd.ExecuteReader
    '        dt.Load(temp)

    '        grdResult.DataSource = dt
    '        grdResult.DataBind()

    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '        'MessageBox.Show("ERROR")
    '    Finally
    '        conn.Close()
    '    End Try

    'End Sub

    'Protected Sub OnPageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
    '    grdResult.PageIndex = e.NewPageIndex
    '    grdResult.DataBind()
    'End Sub


End Class
