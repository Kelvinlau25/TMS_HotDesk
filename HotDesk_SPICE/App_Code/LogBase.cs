namespace Control
{
    public abstract class LogBase : Library.Root.Control.LogBase
    {
        public string LogTable
        {
            get { return GetGlobalResourceObject("Log", base.SetupKey) as string; }
        }

        public override string LogPage
        {
            get { return GetGlobalResourceObject("ListPage", "History") as string; }
        }

        public override string LogTitle
        {
            get { return GetGlobalResourceObject("Title", base.SetupKey) as string; }
        }

        public string SortDesc
        {
            get
            {
                try
                {
                    return GetGlobalResourceObject("SortDesc", base.SetupKey) as string;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        protected override void BindData()
        {
        }

        protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);
        }
    }
}