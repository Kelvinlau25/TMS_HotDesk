// ===========================================================================
// WebForms Compatibility Stubs for .NET 8 Migration
// ===========================================================================
// These are minimal stub types that allow existing WebForms-based code to
// compile under .NET 8. They replicate the API surface of System.Web.UI
// and related namespaces, but do NOT provide runtime WebForms behavior.
// They serve as a bridge during migration to ASP.NET Core patterns.
// ===========================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.IO;

// ========================== System.Web ==========================
namespace System.Web
{
    public class HttpContext
    {
        [ThreadStatic]
        private static HttpContext _current;

        public static HttpContext Current
        {
            get => _current ?? (_current = new HttpContext());
            set => _current = value;
        }

        public HttpRequest Request { get; set; } = new HttpRequest();
        public HttpResponse Response { get; set; } = new HttpResponse();
        public HttpSessionState Session { get; set; } = new HttpSessionState();
        public HttpServerUtility Server { get; set; } = new HttpServerUtility();

        public static object GetGlobalResourceObject(string classKey, string resourceKey)
        {
            return string.Empty;
        }
    }

    public class HttpRequest
    {
        public NameValueCollection QueryString { get; set; } = new NameValueCollection();
        public string UserHostAddress { get; set; } = string.Empty;
        public string RawUrl { get; set; } = string.Empty;
    }

    public class HttpResponse
    {
        public void Redirect(string url) { }
        public void Write(string s) { }
    }

    public class HttpSessionState
    {
        private readonly Dictionary<string, object> _values = new Dictionary<string, object>();

        public object this[string name]
        {
            get => _values.ContainsKey(name) ? _values[name] : null;
            set => _values[name] = value;
        }

        public void Abandon() { _values.Clear(); }
    }

    public class HttpServerUtility
    {
        public string UrlEncode(string s) => System.Net.WebUtility.UrlEncode(s);
        public string UrlDecode(string s) => System.Net.WebUtility.UrlDecode(s);
        public string HtmlEncode(string s) => System.Net.WebUtility.HtmlEncode(s);
        public string HtmlDecode(string s) => System.Net.WebUtility.HtmlDecode(s);
    }
}

// ========================== System.Web.UI ==========================
namespace System.Web.UI
{
    public class StateBag : IEnumerable
    {
        private readonly Dictionary<string, object> _bag = new Dictionary<string, object>();

        public object this[string key]
        {
            get => _bag.ContainsKey(key) ? _bag[key] : null;
            set => _bag[key] = value;
        }

        public IEnumerator GetEnumerator() => _bag.GetEnumerator();
    }

    public class Control
    {
        public string ID { get; set; }
        public bool Visible { get; set; } = true;
        public bool EnableViewState { get; set; } = true;
        public Control NamingContainer { get; set; }
        public ControlCollection Controls { get; }
        public AttributeCollection Attributes { get; } = new AttributeCollection();
        public Page Page { get; set; }

        public Control()
        {
            Controls = new ControlCollection(this);
        }

        public virtual Control FindControl(string id) => null;

        public virtual void DataBind() { }

        public virtual void Focus() { }

        public string ResolveUrl(string relativeUrl) => relativeUrl ?? string.Empty;

        protected virtual void OnInit(EventArgs e) { }
        protected virtual void OnLoad(EventArgs e) { }

        public virtual void RenderControl(HtmlTextWriter writer) { }
    }

    public class ControlCollection : IEnumerable
    {
        private readonly List<Control> _controls = new List<Control>();
        private readonly Control _owner;

        public ControlCollection(Control owner)
        {
            _owner = owner;
        }

        public void Add(Control child)
        {
            _controls.Add(child);
        }

        public void Remove(Control child)
        {
            _controls.Remove(child);
        }

        public void Clear()
        {
            _controls.Clear();
        }

        public int Count => _controls.Count;

        public Control this[int index] => _controls[index];

        public IEnumerator GetEnumerator() => _controls.GetEnumerator();
    }

    public class AttributeCollection
    {
        private readonly Dictionary<string, string> _attrs = new Dictionary<string, string>();

        public void Add(string key, string value)
        {
            _attrs[key] = value;
        }

        public string this[string key]
        {
            get => _attrs.ContainsKey(key) ? _attrs[key] : null;
            set => _attrs[key] = value;
        }
    }

    public class Page : Control
    {
        public string Title { get; set; }
        public bool IsPostBack { get; set; }
        public HttpRequest Request => HttpContext.Current?.Request ?? new HttpRequest();
        public HttpResponse Response => HttpContext.Current?.Response ?? new HttpResponse();
        public HttpServerUtility Server => HttpContext.Current?.Server ?? new HttpServerUtility();
        public HttpSessionState Session => HttpContext.Current?.Session ?? new HttpSessionState();
        public StateBag ViewState { get; } = new StateBag();
        public ClientScriptManager ClientScript { get; } = new ClientScriptManager();

        public string ResolveUrl(string relativeUrl) => relativeUrl;

        public object GetGlobalResourceObject(string classKey, string resourceKey)
        {
            return HttpContext.GetGlobalResourceObject(classKey, resourceKey);
        }
    }

    public class UserControl : Control
    {
        public Page Page { get; set; }
        public HttpRequest Request => HttpContext.Current?.Request ?? new HttpRequest();
        public HttpResponse Response => HttpContext.Current?.Response ?? new HttpResponse();
        public HttpServerUtility Server => HttpContext.Current?.Server ?? new HttpServerUtility();
        public HttpSessionState Session => HttpContext.Current?.Session ?? new HttpSessionState();
        public StateBag ViewState { get; } = new StateBag();

        public bool IsPostBack => Page?.IsPostBack ?? false;
    }

    public class HtmlTextWriter : TextWriter
    {
        private readonly TextWriter _writer;

        public HtmlTextWriter(TextWriter writer)
        {
            _writer = writer;
        }

        public override System.Text.Encoding Encoding => _writer.Encoding;

        public override void Write(string value) => _writer.Write(value);
        public override void Write(char value) => _writer.Write(value);
        public override void WriteLine(string value) => _writer.WriteLine(value);

        public void WriteEncodedText(string text)
        {
            _writer.Write(System.Net.WebUtility.HtmlEncode(text));
        }

        public virtual void RenderBeginTag(string tagName)
        {
            _writer.Write($"<{tagName}>");
        }

        public virtual void RenderEndTag()
        {
            _writer.Write("</>");
        }
    }

    public interface ITemplate
    {
        void InstantiateIn(Control container);
    }

    public class ClientScriptManager
    {
        public void RegisterStartupScript(Type type, string key, string script) { }
    }

    public class ImageClickEventArgs : EventArgs
    {
        public int X { get; set; }
        public int Y { get; set; }

        public ImageClickEventArgs(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class ScriptManager
    {
        public static void RegisterStartupScript(Page page, Type type, string key, string script, bool addScriptTags) { }
        public static void RegisterStartupScript(Control control, Type type, string key, string script, bool addScriptTags) { }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class ToolboxDataAttribute : Attribute
    {
        public ToolboxDataAttribute(string data) { }
    }
}

// ======================== System.Web.UI.WebControls ========================
namespace System.Web.UI.WebControls
{
    public enum HorizontalAlign
    {
        NotSet = 0,
        Left = 1,
        Center = 2,
        Right = 3,
        Justify = 4
    }

    public enum ListItemType
    {
        Header = 0,
        Footer = 1,
        Item = 2,
        AlternatingItem = 3,
        SelectedItem = 4,
        EditItem = 5,
        Separator = 6,
        Pager = 7
    }

    public enum DataControlRowType
    {
        Header = 0,
        Footer = 1,
        DataRow = 2,
        Separator = 3,
        Pager = 4,
        EmptyDataRow = 5
    }

    public enum SortDirection
    {
        Ascending = 0,
        Descending = 1
    }

    public struct Unit
    {
        public double Value { get; set; }

        public static Unit Pixel(int n) => new Unit { Value = n };
        public static Unit Percentage(double n) => new Unit { Value = n };
    }

    public class Style
    {
        public HorizontalAlign HorizontalAlign { get; set; }
        public Unit Width { get; set; }
        public string CssClass { get; set; }
    }

    public class TableItemStyle : Style
    {
    }

    public class WebControl : Control
    {
        public Unit Width { get; set; }
        public Unit Height { get; set; }
        public string CssClass { get; set; }
        public bool Enabled { get; set; } = true;
        public string ValidationGroup { get; set; }
        public new StateBag ViewState { get; } = new StateBag();

        public virtual void RenderBeginTag(HtmlTextWriter writer) { }
        protected virtual void RenderContents(HtmlTextWriter output) { }
    }

    public class PlaceHolder : Control
    {
    }

    public class Label : WebControl
    {
        public string Text { get; set; }
    }

    public class Literal : Control
    {
        public string Text { get; set; }
    }

    public class CheckBox : WebControl
    {
        public bool Checked { get; set; }
        public bool AutoPostBack { get; set; }
        public event EventHandler CheckedChanged;

        internal void OnCheckedChanged()
        {
            CheckedChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public class RadioButton : CheckBox
    {
        public string GroupName { get; set; }
    }

    public class ListItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public bool Selected { get; set; }

        public ListItem() { }
        public ListItem(string text) { Text = text; Value = text; }
        public ListItem(string text, string value) { Text = text; Value = value; }

        public static implicit operator ListItem(string text) => new ListItem(text);
    }

    public class ListItemCollection : List<ListItem>
    {
        public new void Insert(int index, ListItem item)
        {
            base.Insert(index, item);
        }
    }

    public class ListControl : WebControl
    {
        public object DataSource { get; set; }
        public string DataTextField { get; set; }
        public string DataValueField { get; set; }
        public ListItemCollection Items { get; } = new ListItemCollection();
        public string SelectedValue { get; set; }
        public int SelectedIndex { get; set; } = -1;
        public ListItem SelectedItem
        {
            get => SelectedIndex >= 0 && SelectedIndex < Items.Count ? Items[SelectedIndex] : null;
        }

        public void DataBind() { }
    }

    public class DropDownList : ListControl
    {
    }

    public class DataKeyArray
    {
        private readonly List<DataKey> _keys = new List<DataKey>();

        public DataKey this[int index] => _keys[index];
    }

    public class DataKey
    {
        private readonly object[] _values;

        public DataKey(object[] values)
        {
            _values = values ?? new object[0];
        }

        public object this[int index] => _values.Length > index ? _values[index] : null;
    }

    public class GridViewRow : Control
    {
        public DataControlRowType RowType { get; set; }
        public int RowIndex { get; set; }
        public TableCellCollection Cells { get; } = new TableCellCollection();
        public new AttributeCollection Attributes { get; } = new AttributeCollection();

        public override Control FindControl(string id) => null;
    }

    public class TableCell : Control
    {
        public string Text { get; set; }
    }

    public class TableCellCollection : List<TableCell>
    {
    }

    public class GridViewRowCollection : IEnumerable<GridViewRow>
    {
        private readonly List<GridViewRow> _rows = new List<GridViewRow>();

        public IEnumerator<GridViewRow> GetEnumerator() => _rows.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _rows.GetEnumerator();
    }

    public class GridViewSortEventArgs : EventArgs
    {
        public string SortExpression { get; set; }
        public SortDirection SortDirection { get; set; }
    }

    public class GridViewRowEventArgs : EventArgs
    {
        public GridViewRow Row { get; set; }

        public GridViewRowEventArgs(GridViewRow row)
        {
            Row = row;
        }
    }

    public class GridView : WebControl
    {
        public object DataSource { get; set; }
        public DataKeyArray DataKeys { get; } = new DataKeyArray();
        public DataControlFieldCollection Columns { get; } = new DataControlFieldCollection();
        public GridViewRowCollection Rows { get; } = new GridViewRowCollection();
        public bool AllowSorting { get; set; }
        public int PageIndex { get; set; }
        public bool AllowPaging { get; set; }
        public int PageSize { get; set; } = 10;

        public event EventHandler<GridViewSortEventArgs> Sorting;
        public event EventHandler<GridViewRowEventArgs> RowCreated;
        public event EventHandler<GridViewRowEventArgs> RowDataBound;

        public void DataBind() { }
    }

    public class DataControlField
    {
        public ITemplate ItemTemplate { get; set; }
        public ITemplate HeaderTemplate { get; set; }
        public TableItemStyle ItemStyle { get; } = new TableItemStyle();
        public TableItemStyle HeaderStyle { get; } = new TableItemStyle();
        public Style ControlStyle { get; } = new Style();
    }

    public class TemplateField : DataControlField
    {
    }

    public class DataControlFieldCollection : List<DataControlField>
    {
    }

    public class DataGrid : WebControl
    {
        public object DataSource { get; set; }

        public void DataBind() { }
    }
}

// ======================== System.Web.UI.HtmlControls ========================
namespace System.Web.UI.HtmlControls
{
    public class HtmlControl : System.Web.UI.Control
    {
    }

    public class HtmlInputFile : HtmlControl
    {
        public string Accept { get; set; }
    }

    public class HtmlInputHidden : HtmlControl
    {
        public string Value { get; set; }
    }

    public class HtmlGenericControl : HtmlControl
    {
        public string InnerHtml { get; set; }
        public string InnerText { get; set; }
        public string TagName { get; set; }

        public HtmlGenericControl() { }
        public HtmlGenericControl(string tag) { TagName = tag; }
    }

    public class HtmlAnchor : HtmlControl
    {
        public string HRef { get; set; }
        public string Target { get; set; }
        public string Title { get; set; }
    }
}

// ======================== System.Web (additional) ========================
namespace System.Web
{
    public class MasterPage : System.Web.UI.Page
    {
    }
}

// ======================== System.Web.UI (additional) ========================
namespace System.Web.UI
{
    public class MasterPage : Page
    {
    }
}

// ======================== System.Web.Services ========================
namespace System.Web.Services
{
    [AttributeUsage(AttributeTargets.Method)]
    public class WebMethodAttribute : Attribute
    {
    }
}

// ======================== System.Web.UI.WebControls (additional) ========================
namespace System.Web.UI.WebControls
{
    public class Button : WebControl
    {
        public string Text { get; set; }
        public string CommandArgument { get; set; }
        public string CommandName { get; set; }
        public bool CausesValidation { get; set; }
        public string ValidationGroup { get; set; }
        public string OnClientClick { get; set; }
        public event EventHandler Click;

        internal void OnClick()
        {
            Click?.Invoke(this, EventArgs.Empty);
        }
    }

    public class TextBox : WebControl
    {
        public string Text { get; set; }
        public bool ReadOnly { get; set; }
    }

    public class Panel : WebControl
    {
    }

    public class HyperLink : WebControl
    {
        public string Text { get; set; }
        public string NavigateUrl { get; set; }
        public string Target { get; set; }
    }

    public class Image : WebControl
    {
        public string ImageUrl { get; set; }
        public string AlternateText { get; set; }
    }

    public class LinkButton : WebControl
    {
        public string Text { get; set; }
        public string CommandArgument { get; set; }
        public string CommandName { get; set; }
        public string PostBackUrl { get; set; }
        public event EventHandler Click;

        internal void OnClick()
        {
            Click?.Invoke(this, EventArgs.Empty);
        }
    }

    public class ListBox : ListControl
    {
        public System.Web.UI.WebControls.ListSelectionMode SelectionMode { get; set; }
    }

    public enum ListSelectionMode
    {
        Single = 0,
        Multiple = 1
    }

    public class BulletedList : ListControl
    {
    }

    public class Repeater : WebControl
    {
        public object DataSource { get; set; }
        public void DataBind() { }
    }

    public class HiddenField : Control
    {
        public string Value { get; set; }
    }

    public class RequiredFieldValidator : WebControl
    {
        public string ControlToValidate { get; set; }
        public string ErrorMessage { get; set; }
        public string ValidationGroup { get; set; }
    }

    public class ValidationSummary : WebControl
    {
        public string ValidationGroup { get; set; }
    }

    public class UpdatePanel : WebControl
    {
    }

    public class ScriptManagerProxy : Control
    {
    }

    public class ContentPlaceHolder : Control
    {
    }

    public class Content : Control
    {
        public string ContentPlaceHolderID { get; set; }
    }

    public class GridViewPageEventArgs : EventArgs
    {
        public int NewPageIndex { get; set; }

        public GridViewPageEventArgs(int newPageIndex)
        {
            NewPageIndex = newPageIndex;
        }
    }

    public class ServerValidateEventArgs : EventArgs
    {
        public string Value { get; set; }
        public bool IsValid { get; set; }

        public ServerValidateEventArgs(string value, bool isValid)
        {
            Value = value;
            IsValid = isValid;
        }
    }

    public enum ValidationDataType
    {
        String = 0,
        Integer = 1,
        Double = 2,
        Date = 3,
        Currency = 4
    }

    public class RangeValidator : WebControl
    {
        public string ControlToValidate { get; set; }
        public string ErrorMessage { get; set; }
        public string MinimumValue { get; set; }
        public string MaximumValue { get; set; }
        public ValidationDataType Type { get; set; }
        public string ValidationGroup { get; set; }
    }

    public class CustomValidator : WebControl
    {
        public string ControlToValidate { get; set; }
        public string ErrorMessage { get; set; }
        public string ValidationGroup { get; set; }
        public event EventHandler<ServerValidateEventArgs> ServerValidate;

        internal void OnServerValidate(ServerValidateEventArgs e)
        {
            ServerValidate?.Invoke(this, e);
        }
    }

    public class CompareValidator : WebControl
    {
        public string ControlToValidate { get; set; }
        public string ControlToCompare { get; set; }
        public string ErrorMessage { get; set; }
        public ValidationDataType Type { get; set; }
        public string Operator { get; set; }
        public string ValidationGroup { get; set; }
        public string ValueToCompare { get; set; }
    }

    public class RegularExpressionValidator : WebControl
    {
        public string ControlToValidate { get; set; }
        public string ErrorMessage { get; set; }
        public string ValidationExpression { get; set; }
        public string ValidationGroup { get; set; }
    }

    public class ImageButton : WebControl
    {
        public string ImageUrl { get; set; }
        public string AlternateText { get; set; }
        public string PostBackUrl { get; set; }
        public event EventHandler Click;

        internal void OnClick()
        {
            Click?.Invoke(this, EventArgs.Empty);
        }
    }
}
