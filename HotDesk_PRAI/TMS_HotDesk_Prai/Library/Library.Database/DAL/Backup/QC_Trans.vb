
Imports Oracle.DataAccess.Client

Namespace DAL
    ''' <summary>
    ''' CapexCapital Data Access Layer
    ''' ------------------------------------------------
    ''' 15 March 2012  C.C.Yeon Initial Version
    ''' </summary>
    ''' <remarks></remarks>
    Public Class QC_Trans
        Inherits Library.Oraclecls.Connection

        Public Sub New()
            MyBase.New("ORCL_DMS")
        End Sub

        Friend Function List(ByVal Mods As String, ByVal ParentID As String, ByVal Table As String, ByVal SearchField As String, ByVal SearchValue As String, ByVal SortField As String, ByVal Direction As Integer, _
                             ByVal FromRowNo As Integer, ByVal ToRowNo As Integer, ByVal Deleted As Integer) As ListCollection
            List = New ListCollection

            With MyBase._cmd
                .CommandText = "SP_QC_TRANS_LST"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()
                .Parameters.Add(New OracleParameter("pMods", Mods)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PParentID", ParentID)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("pTable", Table)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("pSearch", SearchField)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("pValue", SearchValue)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("pSortField", SortField)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("pDirection", Direction)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("pAdditionalSort", "")).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("pFromRowno", FromRowNo)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("pToRowNo", ToRowNo)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("pDeleted", Deleted)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("SREFData", Oracle.DataAccess.Client.OracleDbType.RefCursor)).Direction = ParameterDirection.Output
                .Parameters.Add(New OracleParameter("SREFTotalCounter", Oracle.DataAccess.Client.OracleDbType.RefCursor)).Direction = ParameterDirection.Output
            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            List.Data.Load(_rdr)

            While MyBase._rdr.Read
                List.TotalRow = _rdr("COUNTER")
            End While
        End Function

        Friend Function GetData(ByVal Code As String, ByVal mods As String, ByVal group As String) As DataTable
            GetData = New Data.DataTable

            With MyBase._cmd

                If Code.Equals("1") Then
                    .CommandText = "SP_QC_GROUP_NO_GET"
                ElseIf Code.Equals("2") Then
                    .CommandText = "SP_QC_TRANS_GROUP_DESC_SEL"
                ElseIf Code.Equals("3") Then
                    .CommandText = "SP_QC_TRANS_LIMIT_NAME_SEL"
                ElseIf Code.Equals("4") Then
                    .CommandText = "SP_QC_TRANS_SEL"
                ElseIf Code.Equals("5") Then
                    .CommandText = "SP_QC_APP_CHK_SEL"
                ElseIf Code.Equals("6") Then
                    .CommandText = "SP_QC_FIRE_PREV_LST"
                ElseIf Code.Equals("7") Then
                    .CommandText = "SP_QC_TRANS_FIN_FIRE_SEL"
                ElseIf Code.Equals("8") Then
                    .CommandText = "SP_QC_RESULTS_MACHINE"
                ElseIf Code.Equals("9") Then
                    .CommandText = "SP_QC_RESULTS_SEC"
                End If

                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()
                If Code.Equals("4") Or Code.Equals("6") Then
                    .Parameters.Add(New OracleParameter("Pid", mods)).Direction = Data.ParameterDirection.Input
                ElseIf Code.Equals("7") Then
                    .Parameters.Add(New OracleParameter("PID", mods)).Direction = Data.ParameterDirection.Input
                    .Parameters.Add(New OracleParameter("ptank", group)).Direction = Data.ParameterDirection.Input
                ElseIf Code.Equals("8") Then
                    .Parameters.Add(New OracleParameter("pgroup", mods)).Direction = Data.ParameterDirection.Input
                ElseIf Code.Equals("9") Then

                ElseIf Not Code.Equals("1") Then
                    .Parameters.Add(New OracleParameter("PMOD", mods)).Direction = Data.ParameterDirection.Input
                    .Parameters.Add(New OracleParameter("pgroup", group)).Direction = Data.ParameterDirection.Input
                End If

                .Parameters.Add(New OracleParameter("SREF", Oracle.DataAccess.Client.OracleDbType.RefCursor)).Direction = ParameterDirection.Output
            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            GetData.Load(_rdr)
        End Function

        Friend Function GetRptData(ByVal ID As String, ByVal Code As String, ByVal Query As String, ByVal Group As String, ByVal Machine As String, ByVal PFrom As String, ByVal PTo As String) As DataTable
            GetRptData = New Data.DataTable

            With MyBase._cmd

                .CommandText = "SP_QC_RESULTS_RPT"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()

                .Parameters.Add(New OracleParameter("PID", ID)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PCODE", Code)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PQUERY", Query)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PGROUP", Group)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PMACHINE", Machine)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PFRM", PFrom)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PTO", PTo)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("SREF", Oracle.DataAccess.Client.OracleDbType.RefCursor)).Direction = ParameterDirection.Output
            End With

            MyBase._rdr = MyBase._cmd.ExecuteReader
            GetRptData.Load(_rdr)
        End Function

        'Friend Function DDLGetData(ByVal code As String, ByVal sec As String, ByVal grp As String) As DataTable
        '    DDLGetData = New Data.DataTable

        '    With MyBase._cmd
        '        If code.Equals("MAC") Then
        '            .CommandText = "SP_DMS_KPI_MACHINE"

        '        ElseIf code.Equals("EG") Then
        '            .CommandText = "SP_DMS_KPI_EMAIL_DESC_SEL"

        '        ElseIf code.Equals("MOD") Then
        '            .CommandText = "SP_MM_EMAIL_QC_MOD"

        '        ElseIf code.Equals("G") Then
        '            .CommandText = "SP_DMS_KPI_GROUP_DDL_SEL"


        '        ElseIf code.Equals("G2") Then
        '            .CommandText = "SP_DMS_KPI_GROUP_DDL_SEL2"


        '        End If

        '        .CommandType = CommandType.StoredProcedure
        '        .CommandTimeout = 0

        '        .Parameters.Clear()

        '        If code.Equals("MAC") Or code.Equals("EG") Then
        '            .Parameters.Add(New OracleParameter("pid", sec)).Direction = Data.ParameterDirection.Input
        '        ElseIf code.Equals("G") Then
        '            .Parameters.Add(New OracleParameter("pmod", sec)).Direction = Data.ParameterDirection.Input
        '        ElseIf code.Equals("G2") Then
        '            .Parameters.Add(New OracleParameter("pmod", sec)).Direction = Data.ParameterDirection.Input
        '            .Parameters.Add(New OracleParameter("pgrp", grp)).Direction = Data.ParameterDirection.Input
        '        End If

        '        .Parameters.Add(New OracleParameter("SREFData", OracleDbType.RefCursor)).Direction = ParameterDirection.Output
        '    End With

        '    MyBase._rdr = MyBase._cmd.ExecuteReader
        '    DDLGetData.Load(_rdr)
        'End Function

        Friend Function Maint(ByVal PQC_ID As String, ByVal PMOD As String, ByVal PSEC As String, ByVal PGROUP As String, ByVal PMACHINE As String, ByVal PGROUP_NO As String, _
                              ByVal PV1 As String, ByVal PV2 As String, ByVal PV3 As String, ByVal PV4 As String, ByVal PV5 As String, ByVal PV6 As String, ByVal PV7 As String, ByVal PV8 As String, ByVal PV9 As String, _
                              ByVal PL1 As String, ByVal PL2 As String, ByVal PL3 As String, ByVal PL4 As String, ByVal PL5 As String, ByVal PL6 As String, ByVal PL7 As String, ByVal PL8 As String, ByVal PL9 As String, _
                              ByVal PRECIPE As String, ByVal PVOL As String, ByVal PPROC As String, ByVal PSPEED As String, ByVal PCHOP1 As String, ByVal PCHOP2 As String, ByVal PSHIFT As String, ByVal PRESULT As String, _
                              ByVal PDUEDATE As String, ByVal PPADDER As String, ByVal PEQUIP As String, ByVal PIDENTITY As String, ByVal PCAL_DATE As String, ByVal PREF_EQUIP As String, ByVal PFIRE As String, ByVal PCOMMENT As String, _
                              ByVal PREMARKS As String, ByVal PAPP1 As String, ByVal PAPP_REM1 As String, ByVal PAPP_STATUS1 As String, ByVal PAPP2 As String, ByVal PAPP_REM2 As String, ByVal PAPP_STATUS2 As String, ByVal PIND As String, _
                              ByVal RecType As String, ByVal PSTATUSIND As String, ByVal CreatedDate As String, ByVal UpdatedBy As String, ByVal UpdatedLoc As String, ByVal UpdatedCC As String, ByVal Tank As String, ByVal PREMARKS2 As String, ByVal PREMARKS3 As String) As String
            Maint = String.Empty

            With MyBase._cmd
                .CommandText = "SP_QC_TRANS_MAINT"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()
                .Parameters.Add(New OracleParameter("PQC_ID", PQC_ID)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PMOD", PMOD)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PSEC", PSEC)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PGROUP", PGROUP)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PMACHINE", PMACHINE)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PGROUP_NO", PGROUP_NO)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PV1", PV1)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PV2", PV2)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PV3", PV3)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PV4", PV4)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PV5", PV5)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PV6", PV6)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PV7", PV7)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PV8", PV8)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PV9", PV9)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PL1", PL1)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PL2", PL2)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PL3", PL3)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PL4", PL4)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PL5", PL5)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PL6", PL6)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PL7", PL7)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PL8", PL8)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PL9", PL9)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PRECIPE", PRECIPE)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PVOL", PVOL)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PPROC", PPROC)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PSPEED", PSPEED)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PCHOP1", PCHOP1)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PCHOP2", PCHOP2)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PSHIFT", PSHIFT)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PRESULT", PRESULT)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PDUEDATE", PDUEDATE)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PPADDER", PPADDER)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PEQUIP", PEQUIP)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PIDENTITY", PIDENTITY)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PCAL_DATE", PCAL_DATE)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PREF_EQUIP", PREF_EQUIP)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PFIRE", PFIRE)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PCOMMENT", PCOMMENT)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PREMARKS", PREMARKS)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PREMARKS2", PREMARKS2)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PREMARKS3", PREMARKS3)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PTANK", Tank)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PAPP1", PAPP1)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PAPP_REM1", PAPP_REM1)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PAPP_STATUS1", PAPP_STATUS1)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PAPP2", PAPP2)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PAPP_REM2", PAPP_REM2)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("PAPP_STATUS2", PAPP_STATUS2)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PIND", PIND)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("pRecType", RecType)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("PSTATUSIND", PSTATUSIND)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("pCreatedBy", UpdatedBy)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("pCreatedDate", CreatedDate)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("pCreatedLoc", UpdatedLoc)).Direction = Data.ParameterDirection.Input

                .Parameters.Add(New OracleParameter("RETURN_VALUE", Oracle.DataAccess.Client.OracleDbType.Int64, 20)).Direction = ParameterDirection.Output
                .Parameters.Add(New OracleParameter("MSG", Oracle.DataAccess.Client.OracleDbType.Varchar2, 1000)).Direction = ParameterDirection.Output
            End With

            MyBase._cmd.ExecuteReader()
            'MsgBox(MyBase._cmd.Parameters("MSG").Value.ToString)
            If MyBase._cmd.Parameters("RETURN_VALUE").Value.ToString > 0 Then
                Maint = MyBase._cmd.Parameters("RETURN_VALUE").Value.ToString
            Else

                Maint = 0
                Dim _temp As String = MyBase._cmd.Parameters("MSG").Value.ToString
                If _temp <> String.Empty Then
                    Maint = _temp
                End If
                'MsgBox(Maint)
            End If
        End Function


        Friend Function SendEmail(ByVal P_id_mm_machine As String, ByVal P_id_mm_group As String, ByVal P_id_mm_module As String, ByVal P_value As String, ByVal P_cond As String) As String
            SendEmail = String.Empty

            With MyBase._cmd
                .CommandText = "SP_QC_VALIDITYCHECK_SEND_MAIL"
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0

                .Parameters.Clear()
                .Parameters.Add(New OracleParameter("P_id_mm_machine", P_id_mm_machine)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("P_id_mm_group", P_id_mm_group)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("P_id_mm_module", P_id_mm_module)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("P_value", P_value)).Direction = Data.ParameterDirection.Input
                .Parameters.Add(New OracleParameter("P_cond", P_cond)).Direction = Data.ParameterDirection.Input

            End With

            MyBase._cmd.ExecuteReader()
            
        End Function

    End Class
End Namespace



