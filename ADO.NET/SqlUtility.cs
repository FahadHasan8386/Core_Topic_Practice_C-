using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.NET
{
    public class SqlUtility
    {
        public void ExcuteSql(string sql)
        {
            var connectionString = "Server=Fahad\\SQLEXPRESS;Database=CSharp;User Id = csharpb22 ; password = 123456 ; Trust Server Certificate = True;";

            SqlConnection connection = new SqlConnection(connectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand command = new SqlCommand(sql, connection);
            int rowAffected = command.ExecuteNonQuery();//non query (write, update ,delete)


            connection.Close();
        }
    }
}
