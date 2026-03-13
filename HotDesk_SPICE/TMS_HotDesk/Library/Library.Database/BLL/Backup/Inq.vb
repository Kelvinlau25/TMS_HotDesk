Namespace BLL
    ''' <summary>
    ''' Business Logic Layer
    ''' ---------------------------------
    ''' 18 Feb 2012   Yeon    Initial Version
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Inq
        Inherits Library.Root.Other.BusinessLogicBase

        Public Shared Function List(ByVal section As String, ByVal machine As String, ByVal type As String, ByVal datefrom As String, ByVal dateto As String, ByVal status As String, _
                           ByVal lvl As String) As ListCollection
            Using _dal As New DAL.Inq

                List = _dal.List(section, machine, type, datefrom, dateto, status, lvl)
            End Using
        End Function

        Public Shared Function List2(ByVal machine As String, ByVal datefrom As String, ByVal dateto As String) As ListCollection
            Using _dal As New DAL.Inq

                List2 = _dal.List2(machine, datefrom, dateto)
            End Using
        End Function

        Public Shared Function List3(ByVal machine As String, ByVal datefrom As String, ByVal dateto As String) As ListCollection
            Using _dal As New DAL.Inq

                List3 = _dal.List3(machine, datefrom, dateto)
            End Using
        End Function

        Public Shared Function List4(ByVal machine As String, ByVal datefrom As String, ByVal dateto As String) As ListCollection
            Using _dal As New DAL.Inq

                List4 = _dal.List4(machine, datefrom, dateto)
            End Using
        End Function

        Public Shared Function List5(ByVal sec As String, ByVal machine As String, ByVal datefrom As String, ByVal dateto As String, ByVal seriouslvl As String, ByVal status As String) As ListCollection
            Using _dal As New DAL.Inq

                List5 = _dal.List5(sec, machine, datefrom, dateto, seriouslvl, status)
            End Using
        End Function

        Public Shared Function List6(ByVal datefrom As String, ByVal dateto As String) As ListCollection
            Using _dal As New DAL.Inq

                List6 = _dal.List6(datefrom, dateto)
            End Using
        End Function

        Public Shared Function getdata6(ByVal Query As String) As DataTable
            Using _dal As New DAL.Inq

                getdata6 = _dal.getdata6(Query)
            End Using
        End Function

        Public Shared Function GETDATA5(ByVal sec As String, ByVal machine As String, ByVal datefrom As String, ByVal dateto As String, ByVal seriouslvl As String) As DataTable
            Using _dal As New DAL.Inq

                GETDATA5 = _dal.GETDATA5(sec, machine, datefrom, dateto, seriouslvl)
            End Using
        End Function

        Public Shared Function GETDATA7(ByVal datefrom As String, ByVal dateto As String) As DataTable
            Using _dal As New DAL.Inq

                GETDATA7 = _dal.GETDATA7(datefrom, dateto)
            End Using
        End Function

        Public Shared Function GETDATA8() As DataTable
            Using _dal As New DAL.Inq

                GETDATA8 = _dal.GETDATA8()
            End Using
        End Function

        Public Shared Function GETDATA9(ByVal datefrom As String, ByVal dateto As String) As DataTable
            Using _dal As New DAL.Inq

                GETDATA9 = _dal.GETDATA9(datefrom, dateto)
            End Using
        End Function

        Public Shared Function GETDATA10(ByVal datefrom As String, ByVal dateto As String, ByVal sec As String) As DataTable
            Using _dal As New DAL.Inq

                GETDATA10 = _dal.GETDATA10(datefrom, dateto, sec)
            End Using
        End Function

        Public Shared Function GETDATA11(ByVal datefrom As String, ByVal dateto As String, ByVal sec As String) As DataTable
            Using _dal As New DAL.Inq

                GETDATA11 = _dal.GETDATA11(datefrom, dateto, sec)
            End Using
        End Function

        Public Shared Function DDLGetData(ByVal code As String, Optional ByVal section As String = "0") As DataTable
            Using _dal As New DAL.Inq
                DDLGetData = _dal.DDLGetData(code, section)
            End Using
        End Function

        Public Shared Function GETDATASUM(ByVal code As String, ByVal mods As String, ByVal datefrom As String, ByVal dateto As String) As DataTable
            Using _dal As New DAL.Inq

                GETDATASUM = _dal.GETDATASUM(code, mods, datefrom, dateto)
            End Using
        End Function

        Public Shared Function GETDATADTL(ByVal sec As String, ByVal code As String, ByVal mods As String, ByVal datefrom As String, ByVal dateto As String) As DataTable
            Using _dal As New DAL.Inq

                GETDATADTL = _dal.GETDATADTL(sec, code, mods, datefrom, dateto)
            End Using
        End Function
    End Class
End Namespace
