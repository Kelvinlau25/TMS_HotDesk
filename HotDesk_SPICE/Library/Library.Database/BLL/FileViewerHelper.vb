Imports System.Web
Imports System.Configuration
Imports Library.Database.IntranetPortal.BLL


Namespace BLL

    Public Class FileViewerHelper


        Public Shared ReadOnly FileTextSeperator As String = "<{HT^^L*F1L35*S3P4R4T0R}>"



        Public Class FileItem
            Private _FileType As String
            Private _FileName As String
            Private _HtmlLoc As String

            Public Sub New()
                _FileType = ""
                _FileName = ""
                _HtmlLoc = ""
            End Sub

            Public Sub New(ByVal Raw As String)
                _FileType = ""
                _FileName = ""
                _HtmlLoc = ""

                ReBuild(Raw)
            End Sub

            Public ReadOnly Property Type()
                Get
                    Return _FileType
                End Get
            End Property

            Public ReadOnly Property Name()
                Get
                    Return _FileName
                End Get
            End Property

            Public Property Url()
                Set(ByVal value)
                    _HtmlLoc = value
                End Set
                Get
                    Return _HtmlLoc
                End Get
            End Property

            Public Sub ReBuild(ByVal Raw As String)
                Dim begin As Integer = 0, finish As Integer = 0

                If Raw.IndexOf("type=""") > -1 Then
                    begin = Raw.IndexOf("type=""") + 6
                    finish = IIf((Raw.IndexOf("""", begin) > -1), Raw.IndexOf("""", begin), Raw.Length)
                    _FileType = Raw.Substring(begin, finish - begin).Trim
                    finish = finish + 1
                End If

                If Raw.IndexOf("name=""") > -1 Then
                    begin = Raw.IndexOf("name=""") + 6
                    finish = IIf((Raw.IndexOf("""", begin) > -1), Raw.IndexOf("""", begin), Raw.Length)
                    _FileName = Raw.Substring(begin, finish - begin).Trim
                    finish = finish + 1

                    If _FileType.Trim.Length < 3 Then
                        Dim Ext As String = ""
                        If _FileName.Trim.ToLower.LastIndexOf(".") > 0 And _FileName.Trim.ToLower.LastIndexOf(".") < _FileName.Trim.Length - 1 Then
                            Ext = _FileName.Substring(_FileName.Trim.ToLower.LastIndexOf(".") + 1).ToUpper().Trim
                        Else
                            Ext = ""
                        End If

                        Select Case Ext
                            Case "PDF"
                                _FileType = "PDF"
                            Case "DOC", "DOCX"
                                _FileType = "WORD"
                            Case "XLS", "XLSX", "XLTX"
                                _FileType = "EXCEL"
                            Case "PPT", "PPTX"
                                _FileType = "POWERPOINT"
                            Case Else
                                _FileType = "UNKNOWN"
                        End Select
                    End If
                End If

                If Raw.IndexOf("]", finish) = finish Then
                    begin = finish + 1
                    finish = IIf((Raw.IndexOf("[/FILE]", begin) > -1), Raw.IndexOf("[/FILE]", begin), Raw.Length)
                    _HtmlLoc = Raw.Substring(begin, finish - begin).Trim
                End If
            End Sub

            Public Sub Rebuild(ByVal FileName As String, ByVal FileLoc As String, ByVal HtmlLoc As String)
                Dim Ext As String = ""

                If FileName.Trim.ToLower.LastIndexOf(".") > 0 And FileName.Trim.ToLower.LastIndexOf(".") < FileName.Trim.Length - 1 Then
                    Ext = FileName.Substring(FileName.Trim.ToLower.LastIndexOf(".") + 1).ToUpper().Trim
                Else
                    Ext = ""
                End If

                Select Case Ext
                    Case "PDF"
                        _FileType = "PDF"
                    Case "DOC", "DOCX"
                        _FileType = "WORD"
                    Case "XLS", "XLSX", "XLTX"
                        _FileType = "EXCEL"
                    Case "PPT", "PPTX"
                        _FileType = "POWERPOINT"
                    Case Else
                        _FileType = "UNKNOWN"
                End Select

                _FileName = FileName
                _HtmlLoc = HttpUtility.UrlEncode(HtmlLoc.Replace(ConfigurationManager.AppSettings.Get("FILESERVER_URL").ToString, ConfigurationManager.AppSettings.Get("FILESERVER_KEY").ToString))
            End Sub

        End Class









        ''' <summary>
        ''' Compile Files Lists
        ''' </summary>
        ''' <param name="RawContent"></param>
        ''' <param name="fi"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CompileList_FileItem(ByVal RawContent As String, ByRef fi As List(Of FileItem)) As Boolean
            fi = Nothing
            CompileList_FileItem = False

            If RawContent IsNot Nothing Then
                ''@ File
                ''If RawContent.IndexOf("[/FILE]") > -1 Or RawContent.IndexOf(vbCrLf) > -1 Then
                ''    CompileList_FileItem = True
                ''
                ''    Dim items As String() = RawContent.Split(New String() {vbCrLf, "[/FILE]"}, StringSplitOptions.RemoveEmptyEntries)
                ''    ReDim fi(items.Count)
                ''
                ''    For i As Integer = 0 To items.Count - 1
                ''        If fi(i) Is Nothing Then
                ''            fi(i) = New FileItem
                ''        End If
                ''
                ''        fi(i).ReBuild(items(i))
                ''    Next i
                ''End If

                If RawContent.IndexOf("[/FILE]") > -1 Or RawContent.IndexOf(vbCrLf) > -1 Then
                    CompileList_FileItem = True
                    fi = New List(Of FileItem)

                    Dim items As String() = RawContent.Split(New String() {vbCrLf, "[/FILE]"}, StringSplitOptions.RemoveEmptyEntries)

                    For i As Integer = 0 To items.Count - 1
                        If items(i) IsNot Nothing Then
                            fi.Add(New FileItem(items(i)))
                        End If
                    Next i

                End If
            End If
        End Function


        ''' <summary>
        ''' Build Files Lists into Database Varchar format
        ''' </summary>
        ''' <param name="fi"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function BuildFileList_Database(ByVal fi As List(Of FileItem)) As String
            Dim VARCHAR As String = ""

            For i As Integer = 0 To fi.Count - 1
                VARCHAR &= BuildFile_Database(fi(i))
            Next i

            BuildFileList_Database = VARCHAR
        End Function


        ''Public Shared Function BuildFile_Database(ByVal fi As FileItem) As String
        ''    Dim VARCHAR As String = ""
        ''
        ''    If fi IsNot Nothing Then
        ''        VARCHAR &= "[FILE"
        ''        VARCHAR &= " "
        ''        VARCHAR &= "type=""" & fi.Type & """"
        ''        VARCHAR &= " "
        ''        VARCHAR &= "name=""" & fi.Name & """"
        ''        VARCHAR &= " "
        ''        VARCHAR &= "file=""" & fi.Loc & """]"
        ''        VARCHAR &= fi.Url
        ''        VARCHAR &= "[/FILE]"
        ''        VARCHAR &= vbCrLf
        ''    End If
        ''
        ''    BuildFile_Database = VARCHAR
        ''End Function


        Public Shared Function BuildFile_Database(ByVal fi As FileItem) As String
            Dim VARCHAR As String = ""

            If fi IsNot Nothing Then
                VARCHAR &= vbCrLf
                VARCHAR &= "[FILE"
                VARCHAR &= " "
                VARCHAR &= "type=""" & fi.Type & """"
                VARCHAR &= " "
                VARCHAR &= "name=""" & fi.Name & """]"
                VARCHAR &= fi.Url
                VARCHAR &= "[/FILE]"
            End If

            BuildFile_Database = VARCHAR
        End Function


        ''' <summary>
        ''' Build Files Lists into HTML format
        ''' </summary>
        ''' <param name="fi"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function BuildFileList_HTML(ByVal fi As List(Of FileItem), ByVal IsShowBack As Boolean, ByVal IsSelfTarget As Boolean) As String
            BuildFileList_HTML = BuildFileList_HTML(fi, True, IsShowBack, IsSelfTarget)
        End Function



        ''' <summary>
        ''' Build Files Lists into HTML format
        ''' </summary>
        ''' <param name="fi"></param>
        ''' <param name="IsReadOnly"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function BuildFileList_HTML(ByVal fi As List(Of FileItem), ByVal IsReadOnly As Boolean, ByVal IsShowBack As Boolean, ByVal IsSelfTarget As Boolean) As String
            Dim HTML As String = ""

            If fi IsNot Nothing Then
                For i As Integer = 0 To fi.Count - 1
                    If fi(i) IsNot Nothing Then
                        If fi(i).GetType() Is GetType(FileItem) Then
                            If fi(i).Type.Equals("PDF") Then
                                Dim FilePlayerUrl As String = ConfigurationManager.AppSettings.Get("PDF_FILE_VIEWER")
                                Dim EncodedVideoFile As String = HttpUtility.UrlEncode(FileUploadHelper.ConvertDataBase2UrlFormat(fi(i).Url))

                                Dim url As String = String.Format(FilePlayerUrl, EncodedVideoFile)
                                url = IIf(IsShowBack, url & "&p=1", url)


                                HTML &= "<div id=""FileScreenID_" & i.ToString & """ name=""FileScreenID_" & i.ToString & """ class=""file-item"">"
                                HTML &= "<div class=""file-img-" & fi(i).Type & """></div>"
                                If Not IsReadOnly Then
                                    HTML &= "<div class=""file-name""><a href=""" & url & """ target=""_blank"" class=""fancybox fancybox.iframe"">" & fi(i).Name & "</a></div>"
                                    HTML &= "<div class=""file-delete"" onclick=""javascript:DeleteDocument('" & fi(i).Name & "', 'FileScreenID_" & i.ToString & "')""></div>"
                                Else
                                    If IsSelfTarget Then
                                        HTML &= "<div class=""file-name""><a href=""" & url & """ target=""_self"">" & fi(i).Name & "</a></div>"
                                    Else
                                        HTML &= "<div class=""file-name""><a href=""" & url & """ class=""fancybox fancybox.iframe"">" & fi(i).Name & "</a></div>"
                                    End If
                                End If
                                HTML &= "</div>"
                            Else
                                HTML &= "<div id=""FileScreenID_" & i.ToString & """ name=""FileScreenID_" & i.ToString & """ class=""file-item"">"
                                HTML &= "<div class=""file-img-" & fi(i).Type & """></div>"
                                HTML &= "<div class=""file-name""><a href=""" & HttpUtility.UrlDecode(fi(i).Url).Replace(ConfigurationManager.AppSettings.Get("FILESERVER_KEY").ToString, ConfigurationManager.AppSettings.Get("FILESERVER_URL").ToString) & """ target=""_blank"">" & fi(i).Name & "</a></div>"
                                If Not IsReadOnly Then
                                    HTML &= "<div class=""file-delete"" onclick=""javascript:DeleteDocument('" & fi(i).Name & "', 'FileScreenID_" & i.ToString & "')""></div>"
                                End If
                                HTML &= "</div>"
                            End If
                        End If
                    End If
                Next i
            End If

            BuildFileList_HTML = HTML
        End Function


    End Class


End Namespace