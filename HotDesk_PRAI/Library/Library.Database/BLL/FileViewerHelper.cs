using System.Web;
using System.Configuration;
using System.Collections.Generic;
using Library.Database.IntranetPortal.BLL;

namespace BLL
{
    public class FileViewerHelper
    {
        public static readonly string FileTextSeperator = "<{HT^^L*F1L35*S3P4R4T0R}>";

        public class FileItem
        {
            private string _FileType;
            private string _FileName;
            private string _HtmlLoc;

            public FileItem()
            {
                _FileType = "";
                _FileName = "";
                _HtmlLoc = "";
            }

            public FileItem(string raw)
            {
                _FileType = "";
                _FileName = "";
                _HtmlLoc = "";
                ReBuild(raw);
            }

            public object Type
            {
                get { return _FileType; }
            }

            public object Name
            {
                get { return _FileName; }
            }

            public object Url
            {
                get { return _HtmlLoc; }
                set { _HtmlLoc = value.ToString(); }
            }

            public void ReBuild(string raw)
            {
                int begin = 0, finish = 0;

                if (raw.IndexOf("type=\"") > -1)
                {
                    begin = raw.IndexOf("type=\"") + 6;
                    finish = (raw.IndexOf("\"", begin) > -1) ? raw.IndexOf("\"", begin) : raw.Length;
                    _FileType = raw.Substring(begin, finish - begin).Trim();
                    finish = finish + 1;
                }

                if (raw.IndexOf("name=\"") > -1)
                {
                    begin = raw.IndexOf("name=\"") + 6;
                    finish = (raw.IndexOf("\"", begin) > -1) ? raw.IndexOf("\"", begin) : raw.Length;
                    _FileName = raw.Substring(begin, finish - begin).Trim();
                    finish = finish + 1;

                    if (_FileType.Trim().Length < 3)
                    {
                        string Ext = "";
                        if (_FileName.Trim().ToLower().LastIndexOf(".") > 0 && _FileName.Trim().ToLower().LastIndexOf(".") < _FileName.Trim().Length - 1)
                        {
                            Ext = _FileName.Substring(_FileName.Trim().ToLower().LastIndexOf(".") + 1).ToUpper().Trim();
                        }
                        else
                        {
                            Ext = "";
                        }

                        switch (Ext)
                        {
                            case "PDF":
                                _FileType = "PDF";
                                break;
                            case "DOC":
                            case "DOCX":
                                _FileType = "WORD";
                                break;
                            case "XLS":
                            case "XLSX":
                            case "XLTX":
                                _FileType = "EXCEL";
                                break;
                            case "PPT":
                            case "PPTX":
                                _FileType = "POWERPOINT";
                                break;
                            default:
                                _FileType = "UNKNOWN";
                                break;
                        }
                    }
                }

                if (raw.IndexOf("]", finish) == finish)
                {
                    begin = finish + 1;
                    finish = (raw.IndexOf("[/FILE]", begin) > -1) ? raw.IndexOf("[/FILE]", begin) : raw.Length;
                    _HtmlLoc = raw.Substring(begin, finish - begin).Trim();
                }
            }

            public void Rebuild(string fileName, string fileLoc, string htmlLoc)
            {
                string Ext = "";

                if (fileName.Trim().ToLower().LastIndexOf(".") > 0 && fileName.Trim().ToLower().LastIndexOf(".") < fileName.Trim().Length - 1)
                {
                    Ext = fileName.Substring(fileName.Trim().ToLower().LastIndexOf(".") + 1).ToUpper().Trim();
                }
                else
                {
                    Ext = "";
                }

                switch (Ext)
                {
                    case "PDF":
                        _FileType = "PDF";
                        break;
                    case "DOC":
                    case "DOCX":
                        _FileType = "WORD";
                        break;
                    case "XLS":
                    case "XLSX":
                    case "XLTX":
                        _FileType = "EXCEL";
                        break;
                    case "PPT":
                    case "PPTX":
                        _FileType = "POWERPOINT";
                        break;
                    default:
                        _FileType = "UNKNOWN";
                        break;
                }

                _FileName = fileName;
                _HtmlLoc = HttpUtility.UrlEncode(htmlLoc.Replace(ConfigurationManager.AppSettings.Get("FILESERVER_URL").ToString(), ConfigurationManager.AppSettings.Get("FILESERVER_KEY").ToString()));
            }
        }

        /// <summary>
        /// Compile Files Lists
        /// </summary>
        /// <param name="rawContent"></param>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static bool CompileList_FileItem(string rawContent, ref List<FileItem> fi)
        {
            fi = null;
            bool result = false;

            if (rawContent != null)
            {
                if (rawContent.IndexOf("[/FILE]") > -1 || rawContent.IndexOf("\r\n") > -1)
                {
                    result = true;
                    fi = new List<FileItem>();

                    string[] items = rawContent.Split(new string[] { "\r\n", "[/FILE]" }, System.StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i <= items.Length - 1; i++)
                    {
                        if (items[i] != null)
                        {
                            fi.Add(new FileItem(items[i]));
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Build Files Lists into Database Varchar format
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static string BuildFileList_Database(List<FileItem> fi)
        {
            string VARCHAR = "";

            for (int i = 0; i <= fi.Count - 1; i++)
            {
                VARCHAR += BuildFile_Database(fi[i]);
            }

            return VARCHAR;
        }

        public static string BuildFile_Database(FileItem fi)
        {
            string VARCHAR = "";

            if (fi != null)
            {
                VARCHAR += "\r\n";
                VARCHAR += "[FILE";
                VARCHAR += " ";
                VARCHAR += "type=\"" + fi.Type + "\"";
                VARCHAR += " ";
                VARCHAR += "name=\"" + fi.Name + "\"]";
                VARCHAR += fi.Url;
                VARCHAR += "[/FILE]";
            }

            return VARCHAR;
        }

        /// <summary>
        /// Build Files Lists into HTML format
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="isShowBack"></param>
        /// <param name="isSelfTarget"></param>
        /// <returns></returns>
        public static string BuildFileList_HTML(List<FileItem> fi, bool isShowBack, bool isSelfTarget)
        {
            return BuildFileList_HTML(fi, true, isShowBack, isSelfTarget);
        }

        /// <summary>
        /// Build Files Lists into HTML format
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="isReadOnly"></param>
        /// <param name="isShowBack"></param>
        /// <param name="isSelfTarget"></param>
        /// <returns></returns>
        public static string BuildFileList_HTML(List<FileItem> fi, bool isReadOnly, bool isShowBack, bool isSelfTarget)
        {
            string HTML = "";

            if (fi != null)
            {
                for (int i = 0; i <= fi.Count - 1; i++)
                {
                    if (fi[i] != null)
                    {
                        if (fi[i].GetType() == typeof(FileItem))
                        {
                            if (fi[i].Type.Equals("PDF"))
                            {
                                string FilePlayerUrl = ConfigurationManager.AppSettings.Get("PDF_FILE_VIEWER");
                                string EncodedVideoFile = HttpUtility.UrlEncode(FileUploadHelper.ConvertDataBase2UrlFormat(fi[i].Url.ToString()));

                                string url = string.Format(FilePlayerUrl, EncodedVideoFile);
                                url = isShowBack ? url + "&p=1" : url;

                                HTML += "<div id=\"FileScreenID_" + i.ToString() + "\" name=\"FileScreenID_" + i.ToString() + "\" class=\"file-item\">";
                                HTML += "<div class=\"file-img-" + fi[i].Type + "\"></div>";
                                if (!isReadOnly)
                                {
                                    HTML += "<div class=\"file-name\"><a href=\"" + url + "\" target=\"_blank\" class=\"fancybox fancybox.iframe\">" + fi[i].Name + "</a></div>";
                                    HTML += "<div class=\"file-delete\" onclick=\"javascript:DeleteDocument('" + fi[i].Name + "', 'FileScreenID_" + i.ToString() + "')\"></div>";
                                }
                                else
                                {
                                    if (isSelfTarget)
                                    {
                                        HTML += "<div class=\"file-name\"><a href=\"" + url + "\" target=\"_self\">" + fi[i].Name + "</a></div>";
                                    }
                                    else
                                    {
                                        HTML += "<div class=\"file-name\"><a href=\"" + url + "\" class=\"fancybox fancybox.iframe\">" + fi[i].Name + "</a></div>";
                                    }
                                }
                                HTML += "</div>";
                            }
                            else
                            {
                                HTML += "<div id=\"FileScreenID_" + i.ToString() + "\" name=\"FileScreenID_" + i.ToString() + "\" class=\"file-item\">";
                                HTML += "<div class=\"file-img-" + fi[i].Type + "\"></div>";
                                HTML += "<div class=\"file-name\"><a href=\"" + HttpUtility.UrlDecode(fi[i].Url.ToString()).Replace(ConfigurationManager.AppSettings.Get("FILESERVER_KEY").ToString(), ConfigurationManager.AppSettings.Get("FILESERVER_URL").ToString()) + "\" target=\"_blank\">" + fi[i].Name + "</a></div>";
                                if (!isReadOnly)
                                {
                                    HTML += "<div class=\"file-delete\" onclick=\"javascript:DeleteDocument('" + fi[i].Name + "', 'FileScreenID_" + i.ToString() + "')\"></div>";
                                }
                                HTML += "</div>";
                            }
                        }
                    }
                }
            }

            return HTML;
        }
    }
}
