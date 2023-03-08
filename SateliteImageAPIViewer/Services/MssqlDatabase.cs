using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SateliteImageAPIViewer.Interfaces;

namespace SateliteImageAPIViewer.Services
{
    public class MssqlDatabase : IDataBase
    {  
        private DbConnection connection;
        public void Connect()
        {
            connection = new SqlConnection("server=localhost;database=mydb;user id=myusername;password=mypassword");
            connection.Open();
        }

        public void Disconnect()
        {
            connection.Close();
        }

        public DbDataReader ExcuteSql(string sql)
        {
            DbCommand command = new SqlCommand(sql, (SqlConnection)connection);
            return command.ExecuteReader();
        }
    }
}
