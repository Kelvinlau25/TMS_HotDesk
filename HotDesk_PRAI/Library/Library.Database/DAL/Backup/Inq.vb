Imports Oracle.DataAccess.Client

Namespace DAL
    ''' <summary>
    ''' CapexCapital Data Access Layer
    ''' ------------------------------------------------
    ''' 15 March 2012  C.C.Yeon Initial Version
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Inq
        Inherits Library.Oraclecls.Connection

        Public Sub New()
            MyBase.New("ORCL_DMS")
        End Sub

        Friend Function List(ByVal section As String, ByVal machine As String, ByVal type As String, ByVal datefrom As String, ByVal dateto As String, ByVal status As String, _
                            ByVal lvl As String) As ListCollection
            List = New ListCollection

            With MyBase._cmd
                .CommandText = "SP_DMS_KPI_MACHINE_EXPORT"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()

                .Parameters.Add(New OracleParameter("PMACHINE", machine)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PTYPE", type)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PFROM", datefrom)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PTO", dateto)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PSTATUS", status)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PLEVEL", lvl)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PSEC", section)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("SREFData", OracleDbType.RefCursor)).Direction = ParameterDirection.Output

            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            List.Data.Load(_rdr)

        End Function

        Friend Function List2(ByVal machine As String, ByVal datefrom As String, ByVal dateto As String) As ListCollection
            List2 = New ListCollection

            With MyBase._cmd
                .CommandText = "SP_DMS_CHEMICAL_CON_CHK_RPT"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()

                .Parameters.Add(New OracleParameter("PMACHINE", machine)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PFROM", datefrom)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PTO", dateto)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("SREFData", OracleDbType.RefCursor)).Direction = ParameterDirection.Output

            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            List2.Data.Load(_rdr)

        End Function

        Friend Function List3(ByVal machine As String, ByVal datefrom As String, ByVal dateto As String) As ListCollection
            List3 = New ListCollection

            With MyBase._cmd
                .CommandText = "SP_DMS_CHEMICAL_CCC_CHK_RPT"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()

                .Parameters.Add(New OracleParameter("PMACHINE", machine)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PFROM", datefrom)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PTO", dateto)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("SREFData", OracleDbType.RefCursor)).Direction = ParameterDirection.Output

            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            List3.Data.Load(_rdr)

        End Function

        Friend Function List4(ByVal machine As String, ByVal datefrom As String, ByVal dateto As String) As ListCollection
            List4 = New ListCollection

            With MyBase._cmd
                .CommandText = "SP_DMS_CHEMICAL_CCD_CHK_RPT"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()

                .Parameters.Add(New OracleParameter("PMACHINE", machine)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PFROM", datefrom)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PTO", dateto)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("SREFData", OracleDbType.RefCursor)).Direction = ParameterDirection.Output

            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            List4.Data.Load(_rdr)

        End Function

        Friend Function List5(ByVal sec As String, ByVal machine As String, ByVal datefrom As String, ByVal dateto As String, ByVal seriouslvl As String, ByVal status As String) As ListCollection
            List5 = New ListCollection

            With MyBase._cmd
                .CommandText = "SP_DMS_MAC_TRO_DUR_SUM_RPT"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()

                .Parameters.Add(New OracleParameter("Psec", sec)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PMACHINE", machine)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PFROM", datefrom)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PTO", dateto)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PSERIOUSLVL", seriouslvl)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PSTATUS", status)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("SREFData", OracleDbType.RefCursor)).Direction = ParameterDirection.Output

            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            List5.Data.Load(_rdr)

        End Function

        Friend Function List6(ByVal datefrom As String, ByVal dateto As String) As ListCollection
            List6 = New ListCollection

            With MyBase._cmd
                .CommandText = "SP_DMS_MAC_TRO_DUR_SUM_RPT"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()

                .Parameters.Add(New OracleParameter("PFROM", datefrom)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PTO", dateto)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("SREFData", OracleDbType.RefCursor)).Direction = ParameterDirection.Output

            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            List6.Data.Load(_rdr)

        End Function

        Friend Function getdata6(ByVal Query As String) As DataTable
            getdata6 = New Data.DataTable

            With MyBase._cmd
                _cmd.CommandText = Query
                _cmd.CommandType = CommandType.Text
                _cmd.CommandTimeout = 0

            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            getdata6.Load(_rdr)

        End Function

        Friend Function GETDATA5(ByVal sec As String, ByVal machine As String, ByVal datefrom As String, ByVal dateto As String, ByVal seriouslvl As String) As DataTable
            GETDATA5 = New Data.DataTable

            With MyBase._cmd
                .CommandText = "SP_DMS_MAC_TRO_SUM_RPT"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()

                .Parameters.Add(New OracleParameter("Psec", sec)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PMACHINE", machine)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PFROM", datefrom)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PTO", dateto)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PSERIOUSLVL", seriouslvl)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("SREFData", OracleDbType.RefCursor)).Direction = ParameterDirection.Output

            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            GETDATA5.Load(_rdr)

        End Function

        Friend Function GETDATA7(ByVal datefrom As String, ByVal dateto As String) As DataTable
            GETDATA7 = New Data.DataTable

            With MyBase._cmd
                .CommandText = "SP_DMS_MAC_GET_NUMOFWEEK"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()

                .Parameters.Add(New OracleParameter("PFROM", datefrom)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PTO", dateto)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("SREFData", OracleDbType.RefCursor)).Direction = ParameterDirection.Output

            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            GETDATA7.Load(_rdr)

        End Function

        Friend Function GETDATA8() As DataTable
            GETDATA8 = New Data.DataTable

            With MyBase._cmd
                .CommandText = "SP_DMS_MAC_GET_FUNCTION"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()
                .Parameters.Add(New OracleParameter("SREFData", OracleDbType.RefCursor)).Direction = ParameterDirection.Output

            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            GETDATA8.Load(_rdr)

        End Function

        Friend Function GETDATA9(ByVal datefrom As String, ByVal dateto As String) As DataTable
            GETDATA9 = New Data.DataTable

            With MyBase._cmd
                .CommandText = "SP_DMS_MAC_GET_COUNT"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()
                .Parameters.Add(New OracleParameter("PFROM", datefrom)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PTO", dateto)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("SREFData", OracleDbType.RefCursor)).Direction = ParameterDirection.Output

            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            GETDATA9.Load(_rdr)

        End Function

        Friend Function GETDATA10(ByVal datefrom As String, ByVal dateto As String, ByVal sec As String) As DataTable
            GETDATA10 = New Data.DataTable

            With MyBase._cmd
                .CommandText = "SP_DMS_MAC_GET_TITLE"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()
                .Parameters.Add(New OracleParameter("Psec", sec)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PFROM", datefrom)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PTO", dateto)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("SREFData", OracleDbType.RefCursor)).Direction = ParameterDirection.Output

            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            GETDATA10.Load(_rdr)

        End Function

        Friend Function GETDATA11(ByVal datefrom As String, ByVal dateto As String, ByVal sec As String) As DataTable
            GETDATA11 = New Data.DataTable

            With MyBase._cmd
                .CommandText = "SP_DMS_MAC_GET_RPT10_DATA"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()
                .Parameters.Add(New OracleParameter("Psec", sec)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PFROM", datefrom)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PTO", dateto)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("SREFData", OracleDbType.RefCursor)).Direction = ParameterDirection.Output

            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            GETDATA11.Load(_rdr)

        End Function

        Friend Function DDLGetData(ByVal code As String, ByVal str As String) As DataTable
            DDLGetData = New Data.DataTable

            With MyBase._cmd
                If code.Equals("M") Then
                    .CommandText = "SP_DMS_KPI_MACHINE"
                ElseIf code.Equals("T") Then
                    .CommandText = "SP_DMS_KPI_TYPE"
                ElseIf code.Equals("S") Then
                    .CommandText = "SP_DMS_KPI_STATUS"
                ElseIf code.Equals("L") Then
                    .CommandText = "SP_DMS_KPI_LEVEL"
                ElseIf code.Equals("CG") Then
                    .CommandText = "SP_DMS_KPI_MACHINE_CC"
                ElseIf code.Equals("CC") Then
                    .CommandText = "SP_DMS_KPI_MACHINE_CCC"
                ElseIf code.Equals("CD") Then
                    .CommandText = "SP_DMS_KPI_MACHINE_CCD"
                ElseIf code.Equals("M2") Then
                    .CommandText = "SP_DMS_KPI_MACHINE2"
                ElseIf code.Equals("M3") Then
                    .CommandText = "SP_DMS_QC_MACHINE"
                ElseIf code.Equals("SH") Then
                    .CommandText = "SP_DMS_QC_SHIFT"
                End If


                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()

                If code.Equals("M2") Or code.Equals("M") Or code.Equals("M3") Then
                    .Parameters.Add(New OracleParameter("pID", str)).Direction = Data.ParameterDirection.Input
                ElseIf code.Equals("T") Then
                    .Parameters.Add(New OracleParameter("pmachine", str)).Direction = Data.ParameterDirection.Input
                End If

                .Parameters.Add(New OracleParameter("SREFData", OracleDbType.RefCursor)).Direction = ParameterDirection.Output
            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            DDLGetData.Load(_rdr)
        End Function

        Friend Function GETDATASUM(ByVal code As String, ByVal mods As String, ByVal datefrom As String, ByVal dateto As String) As DataTable
            GETDATASUM = New Data.DataTable

            With MyBase._cmd
                .CommandText = "SP_DMS_QC_DYE_USAGE_SUM"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()
                .Parameters.Add(New OracleParameter("pcode", code)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("pMODS", mods)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PFROM", datefrom)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PTO", dateto)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("SREFData", OracleDbType.RefCursor)).Direction = ParameterDirection.Output

            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            GETDATASUM.Load(_rdr)

        End Function

        Friend Function GETDATADTL(ByVal sec As String, ByVal code As String, ByVal mods As String, ByVal datefrom As String, ByVal dateto As String) As DataTable
            GETDATADTL = New Data.DataTable

            With MyBase._cmd
                If sec = "F" Then
                    .CommandText = "SP_DMS_QC_FIN_USAGE_DTL"
                Else
                    .CommandText = "SP_DMS_QC_DYE_USAGE_DTL"
                End If

                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()
                .Parameters.Add(New OracleParameter("pcode", code)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("pMODS", mods)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PFROM", datefrom)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PTO", dateto)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("SREFData", OracleDbType.RefCursor)).Direction = ParameterDirection.Output

            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            GETDATADTL.Load(_rdr)

        End Function

    End Class
End Namespace

