using Oracle.DataAccess.Client;
using Library.Database.IntranetPortal.BLL;
using System.Data;

namespace DAL
{
    public class DynamicAction : Library.Oraclecls.Connection
    {
        // To Initialized Inherited Class by Passing Connection String Name
        public DynamicAction() : base("ORCL_IP")
        {
        }

        internal DataTable List(string table, string columns, string where, string sort)
        {
            DataTable result = new DataTable();

            string pSQL = "";
            pSQL = pSQL + "\n" + "SELECT " + columns;
            pSQL = pSQL + "\n" + "FROM " + table;
            if (where != null && where.Length > 0)
            {
                pSQL = pSQL + "\n" + "WHERE " + where;
            }
            if (sort != null && sort.Length > 0)
            {
                pSQL = pSQL + "\n" + "ORDER BY " + sort;
            }

            base._cmd.CommandText = "SP_DYNAMIC_ACTION_LST";
            base._cmd.CommandType = CommandType.StoredProcedure;
            base._cmd.CommandTimeout = 0;

            base._cmd.Parameters.Clear();
            base._cmd.Parameters.Add(new OracleParameter("pSQL", pSQL)).Direction = ParameterDirection.Input;
            base._cmd.Parameters.Add(new OracleParameter("SREFData", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;

            base._rdr = base._cmd.ExecuteReader();
            result.Load(_rdr);

            return result;
        }

        internal int Update(string table, string UPDField, string UPDValue, string PKField, string PKValue)
        {
            string pSQL = "";
            pSQL = pSQL + "\n" + "UPDATE " + table;
            pSQL = pSQL + "\n" + "SET " + UPDField + "='" + UPDValue.Replace("'", "''") + "' ";
            pSQL = pSQL + "\n" + "WHERE " + PKField + "='" + PKValue.Replace("'", "''") + "' ";

            base._cmd.CommandText = "SP_DYNAMIC_ACTION_UPD";
            base._cmd.CommandType = CommandType.StoredProcedure;
            base._cmd.CommandTimeout = 0;

            base._cmd.Parameters.Clear();
            base._cmd.Parameters.Add(new OracleParameter("pSQL", pSQL)).Direction = ParameterDirection.Input;

            return base._cmd.ExecuteNonQuery();
        }

        internal int UpdateNewsBody(string ID_NEWS, string HTML_BODY)
        {
            base._cmd.CommandText = "SP_DYNAMIC_ACTION_NEWS";
            base._cmd.CommandType = CommandType.StoredProcedure;
            base._cmd.CommandTimeout = 0;

            base._cmd.Parameters.Clear();
            base._cmd.Parameters.Add(new OracleParameter("pID_NEWS", ID_NEWS)).Direction = ParameterDirection.Input;
            base._cmd.Parameters.Add(new OracleParameter("pHTML_BODY", HTML_BODY)).Direction = ParameterDirection.Input;

            return base._cmd.ExecuteNonQuery();
        }
    }
}
