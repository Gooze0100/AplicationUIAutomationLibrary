using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace SQLLibrary.Dapper.Internal.SqlDataAccess;

internal class SqlDataAccess
{
    public static List<T> GetData<T, U>(string sqlQuery, U parameters, string connectionString)
        where T : class
    {
        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            IEnumerable<T> data = connection.Query<T>(sqlQuery, parameters);

            List<T> dataList = [.. data];

            return dataList;
        }
    }

    public static List<T> GetDataSP<T, U>(string storedProcedure, U parameters, string connectionString)
        where T : class
    {
        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            var data = connection.Query(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

            List<T> dataList = [.. data];

            return dataList;
        }
    }
}
