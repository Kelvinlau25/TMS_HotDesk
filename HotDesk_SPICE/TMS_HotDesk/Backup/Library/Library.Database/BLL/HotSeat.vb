Namespace BLL
    ''' <summary>
    ''' Business Logic Layer
    ''' ---------------------------------
    ''' 18 Feb 2012   Yeon    Initial Version
    ''' </summary>
    ''' <remarks></remarks>
    Public Class HotSeat
        Inherits Library.Root.Other.BusinessLogicBase

        Public Shared Function List(ByVal Page As Integer) As ListCollection
            Using _dal As New DAL.HotSeat
                'Validation the parameter value
                List = _dal.List(FromRowNo(Page), ToRowNo(Page))
            End Using
        End Function

        Public Shared Function GetData(ByVal ID As String) As DataTable
            Using _dal As New DAL.HotSeat
                GetData = _dal.GetData(ID)
            End Using
        End Function

        Public Shared Function Maint(ByVal ID As String, ByVal EQ_Name As String, ByVal EQ_Code As String, ByVal RecType As String) As String
            Using _Dal As New DAL.HotSeat
                Dim str As String = System.Web.HttpContext.Current.Session("gstrUserID").ToString
                Dim cc As String = System.Web.HttpContext.Current.Session("gstrUserCompCode").ToString
                Maint = _Dal.Maint(ID, EQ_Name, EQ_Code, RecType, str, System.Web.HttpContext.Current.Request.UserHostAddress.ToString, cc)

                If Maint = "1" Then
                    _Dal.Commit()
                Else
                    _Dal.Rollback()
                End If
            End Using
        End Function
    End Class
End Namespace

