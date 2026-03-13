Namespace BLL
    ''' <summary>
    ''' Business Logic Layer
    ''' ---------------------------------
    ''' 18 Feb 2012   Yeon    Initial Version
    ''' </summary>
    ''' <remarks></remarks>
    Public Class QC_Trans
        Inherits Library.Root.Other.BusinessLogicBase

        Public Shared Function List(ByVal Mods As String, ByVal ParentID As String, ByVal Table As String, ByVal SearchField As String, ByVal SearchValue As String, ByVal SortField As String, ByVal Direction As Integer, _
                                    ByVal Page As Integer, ByVal Deleted As Integer) As ListCollection
            Using _dal As New DAL.QC_Trans
                'Validation the parameter value
                If Direction <> 1 Then
                    Direction = 0
                End If

                List = _dal.List(Mods, ParentID, Table, SearchField, SearchValue, SortField, Direction, FromRowNo(Page), ToRowNo(Page), Deleted)
            End Using
        End Function

        Public Shared Function GetData(ByVal Code As String, Optional ByVal mods As String = "0", Optional ByVal group As String = "0") As DataTable
            Using _dal As New DAL.QC_Trans
                GetData = _dal.GetData(Code, mods, group)
            End Using
        End Function

        Public Shared Function GetRptData(ByVal ID As String, ByVal Code As String, ByVal Query As String, ByVal Group As String, ByVal Machine As String, ByVal PFrom As String, ByVal PTo As String) As DataTable
            Using _dal As New DAL.QC_Trans
                GetRptData = _dal.GetRptData(ID, Code, Query, Group, Machine, PFrom, PTo)
            End Using
        End Function

        'Public Shared Function DDLGetData(ByVal ID As String, Optional ByVal sec As String = "0", Optional ByVal grp As String = "0") As DataTable
        '    Using _dal As New DAL.QC_Trans
        '        DDLGetData = _dal.DDLGetData(ID, sec, grp)
        '    End Using
        'End Function

        Public Shared Function Maint(ByVal PQC_ID As String, ByVal PMOD As String, ByVal PSEC As String, ByVal PGROUP As String, ByVal PMACHINE As String, ByVal PGROUP_NO As String, _
                              ByVal PV1 As String, ByVal PV2 As String, ByVal PV3 As String, ByVal PV4 As String, ByVal PV5 As String, ByVal PV6 As String, ByVal PV7 As String, ByVal PV8 As String, ByVal PV9 As String, _
                              ByVal PL1 As String, ByVal PL2 As String, ByVal PL3 As String, ByVal PL4 As String, ByVal PL5 As String, ByVal PL6 As String, ByVal PL7 As String, ByVal PL8 As String, ByVal PL9 As String, _
                              ByVal PRECIPE As String, ByVal PVOL As String, ByVal PPROC As String, ByVal PSPEED As String, ByVal PCHOP1 As String, ByVal PCHOP2 As String, ByVal PSHIFT As String, ByVal PRESULT As String, _
                              ByVal PDUEDATE As String, ByVal PPADDER As String, ByVal PEQUIP As String, ByVal PIDENTITY As String, ByVal PCAL_DATE As String, ByVal PREF_EQUIP As String, ByVal PFIRE As String, ByVal PCOMMENT As String, _
                              ByVal PREMARKS As String, ByVal PAPP1 As String, ByVal PAPP_REM1 As String, ByVal PAPP_STATUS1 As String, ByVal PAPP2 As String, ByVal PAPP_REM2 As String, ByVal PAPP_STATUS2 As String, ByVal PIND As String, _
                              ByVal RecType As String, ByVal PSTATUSIND As String, ByVal CreatedDate As String, ByVal Tank As String, ByVal PREMARKS2 As String, ByVal PREMARKS3 As String) As String

            Using _Dal As New DAL.QC_Trans
                Dim str As String = System.Web.HttpContext.Current.Session("gstrUserID").ToString
                Dim cc As String = System.Web.HttpContext.Current.Session("gstrUserCompCode").ToString

                Maint = _Dal.Maint(PQC_ID, PMOD, PSEC, PGROUP, PMACHINE, PGROUP_NO, _
                                   PV1, PV2, PV3, PV4, PV5, PV6, PV7, PV8, PV9, _
                                   PL1, PL2, PL3, PL4, PL5, PL6, PL7, PL8, PL9, _
                                   PRECIPE, PVOL, PPROC, PSPEED, PCHOP1, PCHOP2, PSHIFT, PRESULT, _
                                   PDUEDATE, PPADDER, PEQUIP, PIDENTITY, PCAL_DATE, PREF_EQUIP, PFIRE, PCOMMENT, _
                                   PREMARKS, PAPP1, PAPP_REM1, PAPP_STATUS1, PAPP2, PAPP_REM2, PAPP_STATUS2, PIND, _
                                   RecType, PSTATUSIND, CreatedDate, str, System.Web.HttpContext.Current.Request.UserHostAddress.ToString, cc, Tank, PREMARKS2, PREMARKS3)

                Dim int = 0

                If Integer.TryParse(Maint, int) Then
                    If Maint <> 0 Then
                        _Dal.Commit()
                    End If
                Else
                    _Dal.RollBack()
                End If

            End Using

        End Function


        Public Shared Function SendEmail(ByVal P_id_mm_machine As String, ByVal P_id_mm_group As String, ByVal P_id_mm_module As String, ByVal P_value As String, ByVal P_cond As String) As String

            Using _Dal As New DAL.QC_Trans
                Dim str As String = System.Web.HttpContext.Current.Session("gstrUserID").ToString
                Dim cc As String = System.Web.HttpContext.Current.Session("gstrUserCompCode").ToString

                SendEmail = _Dal.SendEmail(P_id_mm_machine, P_id_mm_group, P_id_mm_module, P_value, P_cond)

            End Using

        End Function

    End Class
End Namespace

