using GoIdentity.Entities.Core;
using GoIdentity.Utilities.Constants;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System;
using GoIdentity.Utilities.Extensions;

namespace GoIdentity.ResourceAccess
{
    public static class DbContextExtensions
    {
        public static IList<T> ExecuteStoredProcedure<T>(this DbContext db, string procedureName, List<SqlParameter> parms = null) where T : new()
        {
            var result = default(IList<T>);

            var sqlQuery = new StringBuilder(string.Format("EXECUTE {0} ", procedureName));
            var parmArray = default(SqlParameter[]);

            if (parms != null && parms.Count > 0)
            {
                for (int i = 0; i < parms.ToArray().Length; i++)
                {
                    sqlQuery.Append(string.Format("{0} {1},", parms[i].ParameterName, parms[i].Direction == ParameterDirection.Input ? string.Empty : "out"));
                }
                sqlQuery = sqlQuery.Remove(sqlQuery.Length - 1, 1);
            }

            if (parms == null || parms.Count == 0)
            {
                //result = db.Database.SqlQuery<T>(sqlQuery.ToString()).ToList();
                using (var command = db.Database.GetDbConnection().CreateCommand())
                {
                    //command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = sqlQuery.ToString();
                    var sqlAdapter = new SqlDataAdapter(command as SqlCommand);
                    var dataSet = new DataSet();
                    sqlAdapter.Fill(dataSet);
                    result = dataSet.Tables.Count > 0 ? dataSet.Tables[0].ToList<T>() : new List<T>();
                }
            }
            else
            {
                parmArray = parms.ToArray();

                //result = db.Database.SqlQuery<T>(sqlQuery.ToString(), parmArray).ToList();
                using (var command = db.Database.GetDbConnection().CreateCommand())
                {
                    //command.CommandType = CommandType.StoredProcedure;
                    foreach (var param in parmArray)
                    {
                        command.Parameters.Add(param);
                    }
                    command.CommandText = sqlQuery.ToString();

                    var sqlAdapter = new SqlDataAdapter(command as SqlCommand);
                    var dataSet = new DataSet();
                    sqlAdapter.Fill(dataSet);
                    result = dataSet.Tables.Count > 0 ? dataSet.Tables[0].ToList<T>() : new List<T>();
                }

            }

            if (null != parmArray) parms = parmArray.ToList();

            return result;
        }

        public static int ExecuteNonQuery(this DbContext db, string sql)
        {
            var i = 0;
            db.Database.OpenConnection();
            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = sql;
                i = command.ExecuteNonQuery();
            }
            db.Database.CloseConnection();
            return i;
        }

        /// <summary>
        /// Execute stored procedure which doesn't return any result set
        /// </summary>
        /// <param name="procedureName">Stored procedure name</param>
        /// <param name="parms">SQL parameters</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(this DbContext db, string procedureName, List<SqlParameter> parms, CommandType queryCommandType = CommandType.StoredProcedure)
        {
            var result = default(int);

            var parmArray = default(SqlParameter[]);
            var sqlQuery = new StringBuilder(string.Format("EXECUTE {0} ", procedureName));

            if(queryCommandType != CommandType.StoredProcedure)
            {
                sqlQuery = new StringBuilder(procedureName);
            }
            

            if (queryCommandType == CommandType.StoredProcedure)
            {
                if (parms != null && parms.Count > 0)
                {
                    for (int i = 0; i < parms.ToArray().Length; i++)
                    {
                        sqlQuery.Append(string.Format("{0} {1},", parms[i].ParameterName, parms[i].Direction == ParameterDirection.Input ? string.Empty : "out"));
                    }
                    sqlQuery = sqlQuery.Remove(sqlQuery.Length - 1, 1);
                }

                if (parms == null || parms.Count == 0)
                {
                    result = db.Database.ExecuteSqlCommand($"{sqlQuery.ToString()}");
                }
                else
                {
                    parmArray = parms.ToArray();
                    result = db.Database.ExecuteSqlCommand($"{sqlQuery.ToString()}", parmArray);
                }
            }
            else
            {
                if (parms == null || parms.Count == 0)
                {
                    var dbResult = db.Database.ExecuteSqlCommand($"{sqlQuery.ToString()}");
                }
                else
                {
                    parmArray = parms.ToArray();
                    var dbResult = db.Database.ExecuteSqlCommand($"{sqlQuery.ToString()}", parmArray);
                }
            }


            if (null != parmArray) parms = parmArray.ToList();

            return result;
        }

        /// <summary>
        /// Execute stored procedure which doesn't return any result set
        /// </summary>
        /// <param name="procedureName">Stored procedure name</param>
        /// <param name="parms">SQL parameters</param>
        /// <returns></returns>
        public static List<T> ExecuteResultSet<T>(this DbContext db, string query, params SqlParameter[] parms) where T : new()
        {
            var result = default(List<T>);

            if (parms == null || parms.Length == 0)
            {
                //result = db.Database.SqlQuery<T>(sqlQuery.ToString(), parmArray).ToList();
                using (var command = db.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = query.ToString();

                    var sqlAdapter = new SqlDataAdapter(command as SqlCommand);
                    var dataSet = new DataSet();
                    sqlAdapter.Fill(dataSet);
                    result = dataSet.Tables.Count > 0 ? dataSet.Tables[0].ToList<T>() : new List<T>();
                }

            }
            else
            {
                //result = db.Database.SqlQuery<T>(sqlQuery.ToString(), parmArray).ToList();
                using (var command = db.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    foreach (var param in parms)
                    {
                        command.Parameters.Add(param);
                    }
                    command.CommandText = query.ToString();

                    var sqlAdapter = new SqlDataAdapter(command as SqlCommand);
                    var dataSet = new DataSet();
                    sqlAdapter.Fill(dataSet);
                    result = dataSet.Tables.Count > 0 ? dataSet.Tables[0].ToList<T>() : new List<T>();
                }
            }

            return result;
        }

        /// <summary>
        /// Execute stored procedure which doesn't return any result set
        /// </summary>
        /// <param name="procedureName">Stored procedure name</param>
        /// <param name="parms">SQL parameters</param>
        /// <returns></returns>
        public static List<T> SqlQuery<T>(this DbContext db, string query) where T : new()
        {
            var result = default(List<T>);

            //result = db.Database.SqlQuery<T>(sqlQuery.ToString(), parmArray).ToList();
            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = query.ToString();

                var sqlAdapter = new SqlDataAdapter(command as SqlCommand);
                var dataSet = new DataSet();
                sqlAdapter.Fill(dataSet);
                result = dataSet.Tables.Count > 0 ? dataSet.Tables[0].ToList<T>() : new List<T>();
            }

            return result;
        }

        /// <summary>
        /// Returns data table from the given query
        /// </summary>
        /// <param name="db">Db Context</param>
        /// <param name="query">SQL Server</param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(this DbContext db, string query)
        {
            var resultSet = new DataSet();

            using (var conn = new SqlConnection(db.Database.GetDbConnection().ConnectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(resultSet);
                    }
                }
            }
            return resultSet.Tables[0];
        }

        public static string ExecuteScalar(this DbContext db, string query)
        {
            var resultSet = ExecuteQuery(db, query);

            return (resultSet.Rows.Count > 0 && resultSet.Columns.Count > 0 && resultSet.Rows[0][0] != DBNull.Value) ? resultSet.Rows[0][0].ToString() : default(string);
        }
        
    }
}
