using System.Web.UI.WebControls;

public class checkboxfield : System.Web.UI.ITemplate
{
    public const string CheckboxHeaderID = "chkall";
    public const string CheckboxItemID = "ckitem";
    private ListItemType plittype;

    public checkboxfield(ListItemType type)
    {
        this.plittype = type;
    }

    public void InstantiateIn(System.Web.UI.Control container)
    {
        CheckBox ckitem;
        CheckBox ckall;

        switch (this.plittype)
        {
            case ListItemType.Header:
                ckall = new CheckBox();
                ckall.ID = "chkall";
                ckall.AutoPostBack = true;
                container.Controls.Add(ckall);
                break;
            case ListItemType.Footer:
                return;
            case ListItemType.Item:
                ckitem = new CheckBox();
                ckitem.ID = "ckitem";
                ckitem.AutoPostBack = true;
                container.Controls.Add(ckitem);
                break;
        }
    }
}
