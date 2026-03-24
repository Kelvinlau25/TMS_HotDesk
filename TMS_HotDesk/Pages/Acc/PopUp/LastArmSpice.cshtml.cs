using System.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TMS_HotDesk.Pages.Acc.PopUp
{
    public class LastArmSpiceModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public DataTable Data { get; set; }

        public LastArmSpiceModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            Data = new DataTable();
            var connectionString = _configuration.GetConnectionString("SQLCon");

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                try
                {
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SP_GET_ARM_SPICE";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        using (var reader = cmd.ExecuteReader())
                        {
                            Data.Load(reader);
                        }
                    }
                }
                catch
                {
                    // Error handling
                }
            }
        }
    }
}
