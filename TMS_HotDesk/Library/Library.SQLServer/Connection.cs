using Microsoft.Data.SqlClient;

namespace Library.SQLServer
{
    /// <summary>
    /// Handler the SQL Server Connection Class
    /// -------------------------------------------
    /// C.C.Yeon    25 April 2011   Initial Version
    /// </summary>
    public abstract class Connection : System.IDisposable
    {
        protected SqlConnection _con;
        protected SqlCommand _cmd;
        protected SqlDataReader _rdr;
        protected SqlTransaction _tran;
        protected SqlDataAdapter _sqladp;

        private static System.Collections.Concurrent.ConcurrentDictionary<string, string> _registeredConnectionStrings
            = new System.Collections.Concurrent.ConcurrentDictionary<string, string>();

        /// <summary>
        /// Register a connection string from ASP.NET Core IConfiguration at startup.
        /// </summary>
        public static void RegisterConnectionString(string name, string connectionString)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(connectionString))
            {
                _registeredConnectionStrings[name] = connectionString;
            }
        }

        private string _constr = string.Empty;
        public string ConnectionString
        {
            get { return _constr; }
            set { _constr = value; }
        }

        public Connection(string connectionStringName)
        {
            // Try registered connection strings first (ASP.NET Core IConfiguration),
            // then fall back to ConfigurationManager (legacy .NET Framework config).
            if (_registeredConnectionStrings.TryGetValue(connectionStringName, out var registeredConnStr))
            {
                this.ConnectionString = registeredConnStr;
            }
            else
            {
                var cs = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName];
                this.ConnectionString = cs?.ToString() ?? string.Empty;
            }

            if (string.IsNullOrEmpty(ConnectionString))
            {
                throw new System.Exception("Invalid Connection String Name That Set At Web Config");
            }

            this._con = new SqlConnection(this.ConnectionString);
            this._con.Open();
            this._cmd = _con.CreateCommand();
            this._tran = this._con.BeginTransaction();
            this._cmd.Transaction = this._tran;
        }

        public string Status
        {
            get
            {
                if (_con != null)
                {
                    return _con.State.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Commit all the transaction
        /// </summary>
        public void Commit()
        {
            this._tran.Commit();
        }

        /// <summary>
        /// Rollback all the transaction
        /// </summary>
        public void Rollback()
        {
            this._tran.Rollback();
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // TODO: free other state (managed objects).
                }

                // TODO: free your own state (unmanaged objects).
                // TODO: set large fields to null.

                if (_rdr != null)
                {
                    _rdr.Dispose();
                }

                if (_cmd != null)
                {
                    _cmd.Dispose();
                }

                if (_con != null)
                {
                    if (_con.State == System.Data.ConnectionState.Open)
                    {
                        _con.Close();
                    }
                    _con.Dispose();
                }
            }
            this.disposedValue = true;
        }

        #region IDisposable Support
        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
        #endregion
    }
}
