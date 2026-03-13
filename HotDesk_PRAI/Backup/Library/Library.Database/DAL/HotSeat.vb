Imports System.Data.SqlClient

Namespace DAL
    ''' <summary>
    ''' CapexCapital Data Access Layer
    ''' ------------------------------------------------
    ''' 15 March 2012  C.C.Yeon Initial Version
    ''' </summary>
    ''' <remarks></remarks>
    Public Class HotSeat
        Inherits Library.SQLServer.Connection

        Public Sub New()
            MyBase.New("SQLCon")
        End Sub

        Friend Function List(ByVal FromRowNo As Integer, ByVal ToRowNo As Integer) As ListCollection
            List = New ListCollection

            Dim dt As New DataTable
            Dim ct As New DataTable
            Dim ds As New DataSet

            With MyBase._cmd
                .CommandText = "SP_GET_CHECK_IN_STAFF_PRAI"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0
                .Parameters.Clear()
                .Parameters.Add(New SqlParameter("@FrmRowno", FromRowNo)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New SqlParameter("@ToRowno", ToRowNo)).Direction = Data.ParameterDirection.Input
            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            List.Data.Load(_rdr)

            While MyBase._rdr.Read
                List.TotalRow = _rdr("COUNTER")
            End While
        End Function

        Friend Function GetData(ByVal ID As String) As DataTable
            GetData = New Data.DataTable

            With MyBase._cmd
                .CommandText = "SP_MM_EQUIPMENT_SEL"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()
                .Parameters.Add(New SqlParameter("@pID", ID)).Direction = Data.ParameterDirection.Input
            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            GetData.Load(_rdr)
        End Function

        Friend Function Maint(ByVal id As String, ByVal EQ_Name As String, ByVal EQ_Code As String, ByVal RecType As String, ByVal UpdatedBy As String, ByVal UpdatedLoc As String, ByVal UpdatedCC As String) As String
            Maint = "1"
            Try
                With MyBase._cmd
                    .CommandText = "SP_MM_EQUIPMENT_MAINT"
                    .CommandType = CommandType.StoredProcedure
                    .CommandTimeout = 0

                    .Parameters.Clear()
                    .Parameters.Add(New SqlParameter("@pID", id)).Direction = Data.ParameterDirection.Input
                    .Parameters.Add(New SqlParameter("@pEQ_Name", EQ_Name)).Direction = Data.ParameterDirection.Input
                    .Parameters.Add(New SqlParameter("@pEQ_Code", EQ_Code)).Direction = Data.ParameterDirection.Input

                    .Parameters.Add(New SqlParameter("@pRecType", RecType)).Direction = Data.ParameterDirection.Input
                    .Parameters.Add(New SqlParameter("@pCreatedBy", UpdatedBy)).Direction = Data.ParameterDirection.Input
                    .Parameters.Add(New SqlParameter("@pCreatedLoc", UpdatedLoc)).Direction = Data.ParameterDirection.Input
                    .Parameters.Add(New SqlParameter("@pCreatedCC", UpdatedCC)).Direction = Data.ParameterDirection.Input
                End With
                MyBase._cmd.ExecuteNonQuery()

            Catch ex As Exception
                Maint = ex.Message
            End Try

        End Function

    End Class
End Namespace