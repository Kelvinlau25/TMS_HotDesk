Namespace BLL
    Public Class MenuNav
        Inherits Library.Root.Other.BusinessLogicBase

        Public Shared Function List(ByVal Table As String, ByVal SearchField As String, ByVal SearchValue As String, ByVal SortField As String, ByVal Direction As Integer, _
                                   ByVal Page As Integer, ByVal Deleted As Integer) As ListCollection
            Using _dal As New DAL.MenuNav
                'Validation the parameter value
                If Direction <> 1 Then
                    Direction = 0
                End If

                List = _dal.List(Table, SearchField, SearchValue, SortField, Direction, FromRowNo(Page), ToRowNo(Page), Deleted)
            End Using
        End Function

                  Public Shared Function GetIDList() As DataTable
                           Using _dal As New DAL.MenuNav
                                    GetIDList = _dal.GetIDList()
                           End Using
                  End Function

                  Public Shared Function GetPalletData() As DataTable
                           Using _dal As New DAL.MenuNav
                                    GetPalletData = _dal.GetPalletData()
                           End Using
                  End Function

        Public Shared Function GetData(ByVal ID As String) As DataTable
            Using _dal As New DAL.MenuNav
                GetData = _dal.GetData(ID)
            End Using
        End Function


        Public Shared Function Maint(ByVal ID As String, ByVal mods As String, ByVal RecType As String) As String
            Using _Dal As New DAL.MenuNav
                Dim str As String = System.Web.HttpContext.Current.Session("gstrUserID").ToString
                Dim cc As String = System.Web.HttpContext.Current.Session("gstrUserCompCode").ToString
                Maint = _Dal.Maint(ID, mods, RecType, str, System.Web.HttpContext.Current.Request.UserHostAddress.ToString, cc)

                If Maint = "1" Then
                    _Dal.Commit()
                Else
                    _Dal.RollBack()
                End If
            End Using
        End Function

                  
         End Class

         
End Namespace


