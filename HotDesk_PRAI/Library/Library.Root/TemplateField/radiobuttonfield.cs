using System.Web.UI.WebControls;

public class radiobuttonfield : System.Web.UI.ITemplate
{
    public const string RadioButtonItemID = "rbitem";
    private ListItemType plittype;

    public radiobuttonfield(ListItemType type)
    {
        this.plittype = type;
    }

    public void InstantiateIn(System.Web.UI.Control container)
    {
        RadioButton rbitem;

        switch (this.plittype)
        {
            case ListItemType.Header:
                return;
            case ListItemType.Footer:
                return;
            case ListItemType.Item:
                rbitem = new RadioButton();
                rbitem.ID = "rbitem";
                rbitem.AutoPostBack = true;
                container.Controls.Add(rbitem);
                break;
        }
    }
}
