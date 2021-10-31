using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgresqlCoreDemo.DataAccess.DbHelper
{
    public static class DbHelper
    {
        public static IDbConnection dbConnection;
        static DbHelper()
        {
            dbConnection = GetConnection();
        }

        public static IDbConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5433; Database=Northwind; User Id=postgres;Password=1234");
        }

        public static int ExecuteNonQuery(string sql, object param = null)
        {
            int fnResult = -1;
            return fnResult = dbConnection.Execute(sql, param);
        }

        public static IEnumerable<T> Query<T>(string sql, object param = null)
        {
            return dbConnection.Query<T>(sql, param).ToList();
        }
        public static List<T> QueryList<T>(string sql, object param = null)
        {
            return dbConnection.Query<T>(sql, param).ToList();
        }
    }
}
