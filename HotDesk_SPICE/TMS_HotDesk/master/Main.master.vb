
Partial Class master_Main
    Inherits System.Web.UI.MasterPage

    Private _pointer As Boolean = False

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Session("gstrUserID") = "F22559"
        Session("gstrUserCompCode") = "System"
        Session("gstrUserWorksNo") = "System"
        Session("Barcodechecking") = "F22559"

        'If Request.QueryString(ACL.Control.URL.URLEMPLOYEEID) IsNot Nothing Then
        '    Session("gstrUserID") = ACL.Security.Encryption.Decrypt(Request.QueryString(ACL.Control.URL.URLEMPLOYEEID))
        '    _pointer = True
        'End If

        'If Request.QueryString(ACL.Control.URL.URLCOMPANYID) IsNot Nothing Then
        '    Session("gstrUserCom") = Request.QueryString(ACL.Control.URL.URLCOMPANYID)
        '    _pointer = True
        'End If

        'If Session("gstrUserID") Is Nothing Then
        '    Response.Redirect("~/SessionExpired.aspx")
        'End If

        'Session("gstrUserCompCode") = Session("gstrUserCom")
        'Session("gstrUserWorksNo") = Session("gstrUserID")

        'Session("gstrUserID") = "F22559"
        'Session("gstrUserCompCode") = "System"
        'Session("gstrUserWorksNo") = "System"
        'Session("Barcodechecking") = "F22559"

        'response.write("filename = " & Session("filename") & " subfilename = " & Session("filenamesub"))

        'Response.Write("Works No : " & Session("gstrUserWorksNo") & " " & "Comp Code : " & Session("gstrUserCompCode"))
    End Sub


End Class

