namespace Control
{
    /// <summary>
    /// Handler All Page Common Function 
    /// 1 ) Retrieve and Determine Key
    /// 2 ) Retrieve and Determine Action(Insert / Update / Delete)
    /// 3 ) Generate (Insert / Edit / Delete / List / View ) URL Based on the Setup Key
    /// 4 ) Generete Title Based on the Setup Key
    /// 5 ) Generate Action Desc 
    /// 6 ) Retrieve and Determine Sort Field , Sort Direction 
    /// 7 ) Generate the List View URL (Include Sort Field , Sort Value and Page No )
    /// 8 ) Function Control property , Default = true , if false all the generate list will not auto generate, this is to igone the error wish the page doest not have setting in the resource page
    /// 9 ) Delete Control property , Default = true, if false then the show deleted Check box will be disappear.
    /// 
    /// Remark : The default sort property will determine wherether the url is check or not
    /// check ( if the url failed retrieve the sort field then will generete and redirect its
    /// -------------------------------------------------------------------------------
    /// C.C.Yeon    25 April 2011   initial Version
    /// C.C.Yeon    12 May   2011   Add FucntionControl Property
    /// </summary>
    public abstract class Base : Library.Root.Control.Base
    {
        public abstract void BindData();

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            this.BindData();
        }

        /// <summary>
        /// Retrieve the Detail Path
        /// </summary>
        public override string DetailPage
        {
            get { return GetGlobalResourceObject("DetailPage", this.SetupKey) as string; }
        }

        /// <summary>
        /// Retrieve Title
        /// </summary>
        public override string DisplayTitle
        {
            get { return GetGlobalResourceObject("Title", this.SetupKey) as string; }
        }

        /// <summary>
        /// Retrieve List Page
        /// </summary>
        public override string ListPage
        {
            get { return GetGlobalResourceObject("ListPage", this.SetupKey) as string; }
        }

        /// <summary>
        /// Retrieve Log Page
        /// </summary>
        public override string LogPage
        {
            get { return GetGlobalResourceObject("ListPage", "History") as string; }
        }

        /// <summary>
        /// Retrieve other path based on the key
        /// </summary>
        protected string RetrieveOthersDetail(string key)
        {
            return GetGlobalResourceObject("DetailPage", key) as string;
        }

        /// <summary>
        /// Retrieve Print Page Path
        /// </summary>
        public override string PrintPage
        {
            get { return GetGlobalResourceObject("ListPage", "Print") as string; }
        }
    }
}
