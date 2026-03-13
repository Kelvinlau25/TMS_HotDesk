Imports Oracle.DataAccess.Client
Imports Library.Database.IntranetPortal.BLL


Namespace DAL

    Public Class DynamicAction
        Inherits Library.Oraclecls.Connection

        'To Initialized Inherited Class by Passing Connection String Name
        Public Sub New()
            MyBase.New("ORCL_IP")
        End Sub


        Friend Function List(ByVal Table As String, ByVal Columns As String, ByVal Where As String, ByVal Sort As String) As DataTable
            List = New DataTable

            Dim pSQL As String = ""
            pSQL = pSQL & vbNewLine & "SELECT " & Columns
            pSQL = pSQL & vbNewLine & "FROM " & Table
            If Where IsNot Nothing And Where.Length > 0 Then
                pSQL = pSQL & vbNewLine & "WHERE " & Where
            End If
            If Sort IsNot Nothing And Sort.Length > 0 Then
                pSQL = pSQL & vbNewLine & "ORDER BY " & Sort
            End If

            With MyBase._cmd
                .CommandText = "SP_DYNAMIC_ACTION_LST"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()
                .Parameters.Add(New OracleParameter("pSQL", pSQL)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("SREFData", Oracle.DataAccess.Client.OracleDbType.RefCursor)).Direction = ParameterDirection.Output
            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            List.Load(_rdr)
        End Function


        Friend Function Update(ByVal Table As String, ByVal UPDField As String, ByVal UPDValue As String, ByVal PKField As String, ByVal PKValue As String) As Integer

            Dim pSQL As String = ""
            pSQL = pSQL & vbNewLine & "UPDATE " & Table
            pSQL = pSQL & vbNewLine & "SET " & UPDField & "='" & UPDValue.Replace("'", "''") & "' "
            pSQL = pSQL & vbNewLine & "WHERE " & PKField & "='" & PKValue.Replace("'", "''") & "' "

            With MyBase._cmd
                .CommandText = "SP_DYNAMIC_ACTION_UPD"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()
                .Parameters.Add(New OracleParameter("pSQL", pSQL)).Direction = Data.ParameterDirection.Input
            End With

            Return MyBase._cmd.ExecuteNonQuery()
        End Function

        Friend Function UpdateNewsBody(ByVal ID_NEWS As String, ByVal HTML_BODY As String) As Integer

            With MyBase._cmd
                .CommandText = "SP_DYNAMIC_ACTION_NEWS"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()
                .Parameters.Add(New OracleParameter("pID_NEWS", ID_NEWS)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("pHTML_BODY", HTML_BODY)).Direction = Data.ParameterDirection.Input
            End With

            Return MyBase._cmd.ExecuteNonQuery()
        End Function

    End Class

End Namespace