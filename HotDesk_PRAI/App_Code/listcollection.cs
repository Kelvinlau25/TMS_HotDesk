using System.Data;

public class listcollection
{
    private int _TotalRow = 0;
    public int TotalRow
    {
        get { return _TotalRow; }
        set { _TotalRow = value; }
    }

    private DataTable _Data = new DataTable();
    public DataTable Data
    {
        get { return _Data; }
        set { _Data = value; }
    }
}
