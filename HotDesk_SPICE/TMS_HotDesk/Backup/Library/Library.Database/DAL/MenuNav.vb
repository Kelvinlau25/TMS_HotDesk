Imports System.Data.SqlClient

Namespace DAL
    ''' <summary>
    ''' CapexCapital Data Access Layer
    ''' ------------------------------------------------
    ''' 15 March 2012  C.C.Yeon Initial Version
    ''' </summary>
    ''' <remarks></remarks>
    Public Class MenuNav
        Inherits Library.SQLServer.Connection

        Public Sub New()
            MyBase.New("SQLCon")
                  End Sub

                  ''20170809
                  Friend Function GetIDList() As DataTable
                           GetIDList = New Data.DataTable

                           With MyBase._cmd
                                    .CommandText = "SP_TMS_SEAT_DISPLAY"
                                    .CommandType = CommandType.StoredProcedure
                                    .CommandTimeout = 0
                           End With

                           MyBase._rdr = MyBase._cmd.ExecuteReader
                           GetIDList.Load(_rdr)
                  End Function
                  ''end 20170809

        Friend Function List(ByVal Table As String, ByVal SearchField As String, ByVal SearchValue As String, ByVal SortField As String, ByVal Direction As Integer, _
                             ByVal FromRowNo As Integer, ByVal ToRowNo As Integer, ByVal Deleted As Integer) As ListCollection
            List = New ListCollection

            Dim dt As New DataTable
            Dim ct As New DataTable
            Dim ds As New DataSet
          
            With MyBase._cmd
                .CommandText = "PSP_TESTING_LIST_CL"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()

                .Parameters.Add(New SqlParameter("@Table", Table)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New SqlParameter("@Search", SearchField)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New SqlParameter("@Value", SearchValue)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New SqlParameter("@SortField", SortField)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New SqlParameter("@Direction", Direction)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New SqlParameter("@FrmRowno", FromRowNo)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New SqlParameter("@ToRowno", ToRowNo)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New SqlParameter("@Deleted", Deleted)).Direction = Data.ParameterDirection.Input
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
                .CommandText = "PSP_MM_RACK_WAREHOUSE_SEL"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()
                .Parameters.Add(New SqlParameter("@ID", ID)).Direction = Data.ParameterDirection.Input
            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            GetData.Load(_rdr)
        End Function

        Friend Function Maint(ByVal id As String, ByVal mods As String, ByVal RecType As String, ByVal UpdatedBy As String, ByVal UpdatedLoc As String, ByVal UpdatedCC As String) As String
            Maint = String.Empty

            With MyBase._cmd
                .CommandText = "PSP_TESTING_MAINT_CL"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()
                .Parameters.Add(New SqlParameter("@ID", id)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New SqlParameter("@MOD", mods)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New SqlParameter("@RecType", RecType)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New SqlParameter("@CreatedBy", UpdatedBy)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New SqlParameter("@CreatedLoc", UpdatedLoc)).Direction = Data.ParameterDirection.Input
            End With
        
            MyBase._cmd.ExecuteNonQuery()
        End Function


                  Friend Function GetPalletData() As DataTable
                           GetPalletData = New Data.DataTable

                           With MyBase._cmd
                                    .CommandText = "SP_DDL_MPALLET"
                                    .CommandType = CommandType.StoredProcedure
                                    .CommandTimeout = 0
                           End With

                           MyBase._rdr = MyBase._cmd.ExecuteReader
                           GetPalletData.Load(_rdr)
                  End Function
    End Class

End Namespace

