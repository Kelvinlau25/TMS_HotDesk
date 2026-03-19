using System.Data;
using System.Data.SqlClient;
using Library.Database;

namespace DAL
{
    /// <summary>
    /// CapexCapital Data Access Layer
    /// ------------------------------------------------
    /// 15 March 2012  C.C.Yeon Initial Version
    /// </summary>
    public class HotSeat : Library.SQLServer.Connection
    {
        public HotSeat() : base("SQLCon")
        {
        }

        internal ListCollection List(int fromRowNo, int toRowNo)
        {
            ListCollection result = new ListCollection();

            base._cmd.CommandText = "SP_GET_CHECK_IN_STAFF";
            base._cmd.CommandType = CommandType.StoredProcedure;
            base._cmd.CommandTimeout = 0;
            base._cmd.Parameters.Clear();
            base._cmd.Parameters.Add(new SqlParameter("@FrmRowno", fromRowNo)).Direction = ParameterDirection.Input;
            base._cmd.Parameters.Add(new SqlParameter("@ToRowno", toRowNo)).Direction = ParameterDirection.Input;

            base._rdr = base._cmd.ExecuteReader();
            result.Data.Load(base._rdr);

            return result;
        }

        internal DataTable GetData(string id)
        {
            DataTable result = new DataTable();

            base._cmd.CommandText = "SP_MM_EQUIPMENT_SEL";
            base._cmd.CommandType = CommandType.StoredProcedure;
            base._cmd.CommandTimeout = 0;

            base._cmd.Parameters.Clear();
            base._cmd.Parameters.Add(new SqlParameter("@pID", id)).Direction = ParameterDirection.Input;

            base._rdr = base._cmd.ExecuteReader();
            result.Load(base._rdr);

            return result;
        }

        internal string Maint(string id, string EQ_Name, string EQ_Code, string recType, string updatedBy, string updatedLoc, string updatedCC)
        {
            string result = "1";
            try
            {
                base._cmd.CommandText = "SP_MM_EQUIPMENT_MAINT";
                base._cmd.CommandType = CommandType.StoredProcedure;
                base._cmd.CommandTimeout = 0;

                base._cmd.Parameters.Clear();
                base._cmd.Parameters.Add(new SqlParameter("@pID", id)).Direction = ParameterDirection.Input;
                base._cmd.Parameters.Add(new SqlParameter("@pEQ_Name", EQ_Name)).Direction = ParameterDirection.Input;
                base._cmd.Parameters.Add(new SqlParameter("@pEQ_Code", EQ_Code)).Direction = ParameterDirection.Input;
                base._cmd.Parameters.Add(new SqlParameter("@pRecType", recType)).Direction = ParameterDirection.Input;
                base._cmd.Parameters.Add(new SqlParameter("@pCreatedBy", updatedBy)).Direction = ParameterDirection.Input;
                base._cmd.Parameters.Add(new SqlParameter("@pCreatedLoc", updatedLoc)).Direction = ParameterDirection.Input;
                base._cmd.Parameters.Add(new SqlParameter("@pCreatedCC", updatedCC)).Direction = ParameterDirection.Input;

                base._cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
    }
}