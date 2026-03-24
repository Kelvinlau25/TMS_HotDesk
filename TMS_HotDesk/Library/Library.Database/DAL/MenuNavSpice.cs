using System.Data;
using Microsoft.Data.SqlClient;
using Library.Database;

namespace DAL
{
    public class MenuNavSpice : Library.SQLServer.Connection
    {
        public MenuNavSpice() : base("SQLCon")
        {
        }

        public DataTable GetIDList()
        {
            DataTable result = new DataTable();

            base._cmd.CommandText = "SP_TMS_SEAT_DISPLAY_PRAI";
            base._cmd.CommandType = CommandType.StoredProcedure;
            base._cmd.CommandTimeout = 0;

            base._rdr = base._cmd.ExecuteReader();
            result.Load(base._rdr);

            return result;
        }

        public ListCollection List(string table, string searchField, string searchValue, string sortField, int direction, int fromRowNo, int toRowNo, int deleted)
        {
            ListCollection result = new ListCollection();

            base._cmd.CommandText = "PSP_TESTING_LIST_CL";
            base._cmd.CommandType = CommandType.StoredProcedure;
            base._cmd.CommandTimeout = 0;

            base._cmd.Parameters.Clear();
            base._cmd.Parameters.Add(new SqlParameter("@Table", table)).Direction = ParameterDirection.Input;
            base._cmd.Parameters.Add(new SqlParameter("@Search", searchField)).Direction = ParameterDirection.Input;
            base._cmd.Parameters.Add(new SqlParameter("@Value", searchValue)).Direction = ParameterDirection.Input;
            base._cmd.Parameters.Add(new SqlParameter("@SortField", sortField)).Direction = ParameterDirection.Input;
            base._cmd.Parameters.Add(new SqlParameter("@Direction", direction)).Direction = ParameterDirection.Input;
            base._cmd.Parameters.Add(new SqlParameter("@FrmRowno", fromRowNo)).Direction = ParameterDirection.Input;
            base._cmd.Parameters.Add(new SqlParameter("@ToRowno", toRowNo)).Direction = ParameterDirection.Input;
            base._cmd.Parameters.Add(new SqlParameter("@Deleted", deleted)).Direction = ParameterDirection.Input;

            base._rdr = base._cmd.ExecuteReader();
            result.Data.Load(base._rdr);

            return result;
        }

        public DataTable GetData(string id)
        {
            DataTable result = new DataTable();

            base._cmd.CommandText = "PSP_MM_RACK_WAREHOUSE_SEL";
            base._cmd.CommandType = CommandType.StoredProcedure;
            base._cmd.CommandTimeout = 0;

            base._cmd.Parameters.Clear();
            base._cmd.Parameters.Add(new SqlParameter("@ID", id)).Direction = ParameterDirection.Input;

            base._rdr = base._cmd.ExecuteReader();
            result.Load(base._rdr);

            return result;
        }

        public string Maint(string id, string mods, string recType, string updatedBy, string updatedLoc, string updatedCC)
        {
            string result = string.Empty;

            base._cmd.CommandText = "PSP_TESTING_MAINT_CL";
            base._cmd.CommandType = CommandType.StoredProcedure;
            base._cmd.CommandTimeout = 0;

            base._cmd.Parameters.Clear();
            base._cmd.Parameters.Add(new SqlParameter("@ID", id)).Direction = ParameterDirection.Input;
            base._cmd.Parameters.Add(new SqlParameter("@MOD", mods)).Direction = ParameterDirection.Input;
            base._cmd.Parameters.Add(new SqlParameter("@RecType", recType)).Direction = ParameterDirection.Input;
            base._cmd.Parameters.Add(new SqlParameter("@CreatedBy", updatedBy)).Direction = ParameterDirection.Input;
            base._cmd.Parameters.Add(new SqlParameter("@CreatedLoc", updatedLoc)).Direction = ParameterDirection.Input;

            base._cmd.ExecuteNonQuery();

            return result;
        }

        public DataTable GetPalletData()
        {
            DataTable result = new DataTable();

            base._cmd.CommandText = "SP_DDL_MPALLET";
            base._cmd.CommandType = CommandType.StoredProcedure;
            base._cmd.CommandTimeout = 0;

            base._rdr = base._cmd.ExecuteReader();
            result.Load(base._rdr);

            return result;
        }
    }
}