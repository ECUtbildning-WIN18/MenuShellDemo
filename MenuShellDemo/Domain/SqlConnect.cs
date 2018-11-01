using System.Data.SqlClient;

namespace MenuShellDemo.Domain
{
    public class SqlConnect
    {
        public static SqlConnection Connection()
        {
            var connectionString = "Data Source=(local);Initial Catalog=MenuShellDemo; Integrated Security=true";

            var connection = new SqlConnection(connectionString);

            return connection;
        }
    }
}
