using System.Web;

namespace Object
{
    /// <summary>
    /// Must Inheritance Common Object 
    /// -------------------------------------------
    /// C.C.Yeon      25 April 2011  initial Version
    /// </summary>
    public abstract class Base
    {
        public Base()
        {
            _id = 0;
            _createdby = HttpContext.Current.Session["gstrUserID"].ToString();
            _createddate = System.DateTime.Now;
            _createdloc = HttpContext.Current.Request.UserHostAddress;
            _Updatedby = HttpContext.Current.Session["gstrUserID"].ToString();
            _updatedDate = System.DateTime.Now;
            _UpdatedLoc = HttpContext.Current.Request.UserHostAddress;
        }

        private int _id = 0;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _rectype = string.Empty;
        public string Record_Type
        {
            get { return _rectype; }
            set { _rectype = value; }
        }

        private string _createdby = string.Empty;
        public string CreatedBy
        {
            get { return _createdby; }
            set { _createdby = value; }
        }

        private System.DateTime _createddate = System.DateTime.Now;
        public System.DateTime CreatedDate
        {
            get { return _createddate; }
            set { _createddate = value; }
        }

        private string _createdloc = string.Empty;
        public string CreatedLoc
        {
            get { return _createdloc; }
            set { _createdloc = value; }
        }

        private string _Updatedby = string.Empty;
        public string UpdatedBy
        {
            get { return _Updatedby; }
            set { _Updatedby = value; }
        }

        private System.DateTime _updatedDate = System.DateTime.Now;
        public System.DateTime UpdatedDate
        {
            get { return _updatedDate; }
            set { _updatedDate = value; }
        }

        private string _UpdatedLoc = string.Empty;
        public string UpdatedLoc
        {
            get { return _UpdatedLoc; }
            set { _UpdatedLoc = value; }
        }
    }
}
