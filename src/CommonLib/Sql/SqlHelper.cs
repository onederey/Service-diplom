using CommonLib.Classes;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Sql
{
    /// <summary>
    /// There are all needed commands
    /// </summary>
    public static class SqlHelper
    {
        public static string ConnString { get; set; }

        public static IEnumerable<T> ExecuteQuery<T>(string sp)
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                return conn.Query<T>(sp, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
