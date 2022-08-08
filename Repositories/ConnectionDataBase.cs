using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SIGIE.Core
{
    public class ConnectionDataBase
    {
        // Fields
        private SqlDataAdapter _Adapter;
        public SqlCommand _Command;
        private SqlConnection _Connection;

        public ConnectionDataBase()
        {
            _Connection = new SqlConnection("Server=.;Initial Catalog=DatabaseMVC; Integrated Security=true;");
        }

        public SqlDataAdapter Adapter { get => _Adapter; set => _Adapter = value; }

        public void OpenConection()
        {
            try
            {

                if ((_Connection.State == ConnectionState.Closed) || (_Connection.State == ConnectionState.Broken))
                {
                    _Connection.Open();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void CloseConecction()
        {
            try
            {
                if (_Connection.State == ConnectionState.Open)
                {
                    _Connection.Close();
                }
            }
            catch (Exception)
            {
            }
        }

        public bool ExecuteSP(string queryText, List<SqlParameter> parameters = null)
        {
            try
            {
                _Command = new SqlCommand();
                _Adapter = new SqlDataAdapter();
                _Command.CommandTimeout = 0;
                _Command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    _Command.Parameters.AddRange(parameters.ToArray());
                }
                _Command.Connection = _Connection;
                _Command.CommandText = queryText;
                _Adapter.InsertCommand = _Command;
                _Command.ExecuteNonQuery();

                SqlConnection.ClearPool(_Connection);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object ExecuteSPObject(string queryText, SqlParameter[] parameters = null)
        {
            try
            {
                object result = new object();
                _Command = new SqlCommand();
                _Command.CommandTimeout = 0;
                _Command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    _Command.Parameters.AddRange(parameters);
                }
                _Command.Connection = _Connection;
                _Command.CommandText = queryText;
                return _Command.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SqlDataReader ExecuteSPDataReader(string queryText, SqlParameter[] parameters = null)
        {
            try
            {
                _Command = new SqlCommand();
                _Command.CommandTimeout = 0;
                _Command.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    _Command.Parameters.AddRange(parameters);
                }
                _Command.Connection = _Connection;
                _Command.CommandText = queryText;
                return _Command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }

}
