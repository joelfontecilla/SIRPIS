using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using  System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Comun.Recursos;

namespace DAO.Dao
{
    public class DaoBase
    {
        private DbProviderFactory factory;
        private int commandTimeOut = int.Parse(ConfigurationSIRPIS.commandTimeOut);//5min
        private string connString;

        public DaoBase()
        {
            factory = DbProviderFactories.GetFactory(ConfigurationSIRPIS.dataProvider);
            connString = ConfigurationManager.AppSettings.Get("STRINGDB").ToString();
        }

        #region Metodos Privados
        private List<SqlParameter> Clone(List<SqlParameter> paramParameters)
        {
            List<SqlParameter> Resp = new List<SqlParameter>();
            paramParameters.ForEach(c =>
            {

                Resp.Add(new SqlParameter() { ParameterName = c.ParameterName, Value = c.Value, DbType = c.DbType, Direction = c.Direction });
            });
            return Resp;
        }
        #endregion

        #region Metodos Publicos
        public int Insert(string sql, List<SqlParameter> paramParameters)
        {
            List<SqlParameter> parameters = Clone(paramParameters);
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connString;
                using (DbCommand command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.CommandTimeout = commandTimeOut;
                    command.Parameters.Clear();
                    if (parameters != null && parameters.Count > 0)
                        command.Parameters.AddRange(parameters.ToArray());
                    connection.Open();
                    command.ExecuteNonQuery();
                    int id = -1;
                    string identitySelect;
                    identitySelect = "SELECT @@IDENTITY";
                    command.CommandText = identitySelect;
                    id = int.Parse(command.ExecuteScalar().ToString());
                    connection.Close();
                    command.Dispose();
                    return id;
                }
            }
        }

        public DataSet Consult(string sql, List<SqlParameter> paramParameters)
        {
            List<SqlParameter> parameters = Clone(paramParameters);
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connString;
                using (DbCommand command = factory.CreateCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = sql;
                    command.CommandTimeout = commandTimeOut;
                    command.Parameters.Clear();
                    if (parameters != null && parameters.Count > 0)
                        command.Parameters.AddRange(parameters.ToArray());

                    using (DbDataAdapter adapter = factory.CreateDataAdapter())
                    {
                        adapter.SelectCommand = command;
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        connection.Close();
                        command.Dispose();
                        return ds;
                    }
                }
            }
        }
        #endregion
    }
}
