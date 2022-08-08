using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entities.Models;
using SIGIE.Core;

namespace Repositories
{
    public class ClientRepository : IClientRepository
    {
        protected ConnectionDataBase Connection;

        public ClientRepository()
        {
            this.Connection = new ConnectionDataBase();
        }

        public Client Create(Client client)
        {
            try
            {
                List<SqlParameter> listaParametro = new List<SqlParameter>();

                SqlParameter id = Common.GetSQLParamter("@Id", SqlDbType.Int, client.Id, ParameterDirection.Output);
                listaParametro.Add(id);

                listaParametro.Add(Common.GetSQLParamter("@Name", SqlDbType.VarChar, client.Name));
                listaParametro.Add(Common.GetSQLParamter("@LastName", SqlDbType.VarChar, client.LastName));
                listaParametro.Add(Common.GetSQLParamter("@IdentificationNumber", SqlDbType.VarChar, client.IdentificationNumber));

                this.Connection.OpenConection();
                this.Connection.ExecuteSP("InsertClient", listaParametro);

                client.Id = Convert.ToInt32(id.Value);

                return client;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Connection.CloseConecction();
            }
        }

        public bool Delete(int id)
        {
            try
            {
                List<SqlParameter> listaParametro = new List<SqlParameter>();

                listaParametro.Add(Common.GetSQLParamter("@Id", SqlDbType.SmallInt, id));

                this.Connection.OpenConection();
                return this.Connection.ExecuteSP("DeleteClient", listaParametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Connection.CloseConecction();
            }
        }

        public List<Client> GetAll()
        {
            try
            {

                this.Connection.OpenConection();
                SqlDataReader sqlDR = this.Connection.ExecuteSPDataReader("GetAllClient", null);

                List<Client> arrList = new List<Client>();

                if (sqlDR.HasRows)
                {
                    while (sqlDR.Read())
                    {
                        Client claseObj = new Client();
                        Common.InitClass(claseObj, sqlDR, false);
                        arrList.Add(claseObj);
                    }
                }

                sqlDR.Close();
                return arrList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Connection.CloseConecction();
            }
        }

        public Client GetById(int id)
        {
            try
            {
                List<SqlParameter> listaParmetro = new List<SqlParameter>();

                listaParmetro.Add(Common.GetSQLParamter("@Id", SqlDbType.SmallInt, id));

                this.Connection.OpenConection();
                SqlDataReader sqlDR = this.Connection.ExecuteSPDataReader("GetByIdClient", listaParmetro.ToArray());

                Client claseObj = new Client();
                Common.InitClass(claseObj, sqlDR, true);
                sqlDR.Close();

                return claseObj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Connection.CloseConecction();
            }
        }

        public Client Update(Client client)
        {
            try
            {
                List<SqlParameter> listaParametro = new List<SqlParameter>();

                listaParametro.Add(Common.GetSQLParamter("@Id", SqlDbType.SmallInt, client.Id));
                listaParametro.Add(Common.GetSQLParamter("@Name", SqlDbType.VarChar, client.Name));
                listaParametro.Add(Common.GetSQLParamter("@LastName", SqlDbType.VarChar, client.Name));
                listaParametro.Add(Common.GetSQLParamter("@IdentificationNumber", SqlDbType.VarChar, client.IdentificationNumber));

                this.Connection.OpenConection();
                this.Connection.ExecuteSP("UpdateClient", listaParametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Connection.CloseConecction();
            }
            return client;
        }
    }
}
