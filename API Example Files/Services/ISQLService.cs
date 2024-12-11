
namespace AmetekLabelAPI.Resources.Services
{
    /// <summary>
    /// This service accesses the SQL Server for data.
    /// </summary>
    public interface ISQLService
    {
        /// <summary>
        /// Name used to retrieve the connection string information.
        /// </summary>
        string ConnectionStringName { get; set; }

        /// <summary>
        /// Actual connection string information if not included in setup.
        /// </summary>
        string ConnectionString { get; set; }
        /// <summary>
        /// Method for returning data from SQL Data Table.
        /// </summary>
        /// <typeparam name="T">Model data type for returning a list of data</typeparam>
        /// <typeparam name="U">Parameters object defined at run time</typeparam>
        /// <param name="sql">SQL Code to be exicuted.</param>
        /// <param name="parameters">Parameters object to cusomize queried information to SQL command.</param>
        /// <returns>ValueTask with List of data objects of type specified on input.</returns>

        ValueTask<List<T>> LoadListData<T, U>(string sql, U parameters);
    }
}