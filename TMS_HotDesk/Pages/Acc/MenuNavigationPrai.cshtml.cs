using System;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TMS_HotDesk.Pages.Acc
{
    public class MenuNavigationPraiModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public MenuNavigationPraiModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataTable SeatData { get; set; }

        public void OnGet()
        {
            SeatData = BLL.MenuNavPrai.GetIDList();
        }

        public IActionResult OnPostTesting([FromBody] TestingRequest request)
        {
            var connectionString = _configuration.GetConnectionString("SQLCon");
            string returnValue = string.Empty;

            using (var conn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand();
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    cmd.Transaction = tran;
                    cmd.Connection = conn;
                    cmd.CommandText = "SP_TMS_UPDATE_SEAT_PRAI";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@checkType", request.Checktype)).Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(new SqlParameter("@PstaffName", request.StaffName)).Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(new SqlParameter("@seat", request.SeatName)).Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(new SqlParameter("@return_value", SqlDbType.NVarChar, 4000)).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    tran.Commit();

                    returnValue = cmd.Parameters["@return_value"].Value.ToString();
                }
                catch (Exception)
                {
                    try { tran.Rollback(); } catch { }
                    return new JsonResult("An error occurred while updating the seat.");
                }
            }

            return new JsonResult(returnValue);
        }
    }
}
