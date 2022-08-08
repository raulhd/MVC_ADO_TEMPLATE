using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace SIGIE.Core
{
    public static class Common
    {

        public static void InitClass(object claseObj, SqlDataReader dr, bool abrirLector = false)
        {
            try
            {
                DataTable schemaTable = dr.GetSchemaTable();
                int count = schemaTable.Rows.Count;
                if (abrirLector)
                {
                    dr.Read();
                }
                if (dr.HasRows)
                {
                    for (int i = 0; i < schemaTable.Rows.Count; i++)
                    {
                        string name = schemaTable.Rows[i][0].ToString();
                        string str2 = schemaTable.Rows[i][12].ToString();
                        PropertyInfo property = claseObj.GetType().GetProperty(name);
                        if ((property == null) || !property.CanWrite)
                        {
                            continue;
                        }
                        object obj2 = dr[i];
                        if ((obj2 == null) || (obj2 == DBNull.Value))
                        {
                            goto Label_014F;
                        }
                        string str3 = str2;
                        if (str3 != null)
                        {
                            if (!(str3 == "System.Byte") && !(str3 == "System.Int16"))
                            {
                                if (str3 == "System.Int32")
                                {
                                    goto Label_0114;
                                }
                                if (str3 == "System.Int64")
                                {
                                    goto Label_0124;
                                }
                                if (str3 == "System.String")
                                {
                                    goto Label_0134;
                                }
                                if (str3 == "System.DateTime")
                                {
                                    goto Label_013F;
                                }
                            }
                            else
                            {
                                obj2 = Convert.ToInt16(obj2);
                            }
                        }
                        goto Label_0152;
                    Label_0114:
                        obj2 = Convert.ToInt32(obj2);
                        goto Label_0152;
                    Label_0124:
                        obj2 = Convert.ToInt64(obj2);
                        goto Label_0152;
                    Label_0134:
                        obj2 = Convert.ToString(obj2);
                        goto Label_0152;
                    Label_013F:
                        obj2 = Convert.ToDateTime(obj2);
                        goto Label_0152;
                    Label_014F:
                        obj2 = null;
                    Label_0152:
                        property.SetValue(claseObj, obj2, null);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static SqlParameter GetSQLParamter(String nombreParametro, SqlDbType tipoSQL, Object valor, ParameterDirection parametroDireccion = ParameterDirection.Input)
        {
            SqlParameter param = new SqlParameter(nombreParametro, tipoSQL);

            param.Direction = parametroDireccion;

            if (valor == null)
                param.Value = DBNull.Value;
            else
                param.Value = valor;

            return param;
        }

    }
}
