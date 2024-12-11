using AmetekLabelAPI.Resources.Logging;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace AmetekLabelAPI.Resources.Services
{
    /// <summary>
    /// This service connects to a SQL database to return data.
    /// </summary>
    public partial class SQLService : ISQLService
    {
        #region Declarations

        private readonly IConfiguration _config;
        private readonly ILoggingBroker _logger;
        private string _connectionStringName = "Default";

        /// <summary>
        /// Name used to retrieve the connection string information from the configuration. 
        /// </summary>
        public string ConnectionStringName
        {
            get { return _connectionStringName; }
            set
            {
                _connectionStringName = value;
                if (!string.IsNullOrEmpty(_connectionStringName) & _config.GetConnectionString(value) != null)
                {
                    this.ConnectionString = _config.GetConnectionString(value)!;
                }
            }
        }


        /// <summary>
        /// Actual connection string information if not included in setup.
        /// </summary>
        public string ConnectionString { get; set; } = "";
        #endregion Declarations

        #region Constructors
        /// <summary>
        /// Default constructor that requires a configuration object and a logging object and sets the connection string.
        /// </summary>
        /// <param name="config">configuration object of type IConfiguration</param>
        /// <param name="Logger">logging object of type ILoggingBroker</param>        
        public SQLService(IConfiguration config, ILoggingBroker Logger)
        {
            this._config = config;
            this._logger = Logger;
            this.ConnectionString = config.GetValue<string>("ConnectionStrings:Default") ?? string.Empty;
        }

        #endregion Constructors

        #region public methods

        /// <summary>
        /// Method for returning data from SQL Data Table.
        /// </summary>
        /// <typeparam name="T">Model data type for returning a list of data</typeparam>
        /// <typeparam name="U">Parameters object defined at run time</typeparam>
        /// <param name="sql">SQL Code to be exicuted.</param>
        /// <param name="parameters">Parameters object to cusomize queried information to SQL command.</param>
        /// <returns>ValueTask with List of data objects of type specified on input.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public async ValueTask<List<T>> LoadListData<T, U>(string sql, U parameters)
        {
            string connectionString = TryCatch(() =>
            {
                return ValidateConnectionString(ConnectionStringName, this.ConnectionString);
            });

            if ((string.IsNullOrEmpty(this.ConnectionString) & !string.IsNullOrEmpty(ConnectionStringName)) && _config.GetConnectionString(ConnectionStringName) != null)
            {
                this.ConnectionString = _config.GetConnectionString(ConnectionString)!;
            }

            using (IDbConnection connection = new SqlConnection(this.ConnectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);

                return data.ToList();
            }

        }

        #endregion public methods

        #region Private methods

        #endregion Private methods
    }
}
