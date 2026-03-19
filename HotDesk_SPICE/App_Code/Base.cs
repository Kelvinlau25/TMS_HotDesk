namespace Control
{
    public abstract class Base : Library.Root.Control.Base
    {
        public abstract void BindData();

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            this.BindData();
        }

        public override string DetailPage
        {
            get { return GetGlobalResourceObject("DetailPage", this.SetupKey) as string; }
        }

        public override string DisplayTitle
        {
            get { return GetGlobalResourceObject("Title", this.SetupKey) as string; }
        }

        public override string ListPage
        {
            get { return GetGlobalResourceObject("ListPage", this.SetupKey) as string; }
        }

        public override string LogPage
        {
            get { return GetGlobalResourceObject("ListPage", "History") as string; }
        }

        protected string RetrieveOthersDetail(string key)
        {
            return GetGlobalResourceObject("DetailPage", key) as string;
        }

        public override string PrintPage
        {
            get { return GetGlobalResourceObject("ListPage", "Print") as string; }
        }
    }
}