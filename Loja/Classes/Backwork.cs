using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Loja.Classes
{
    public abstract class Backwork<T> where T : Backwork<T>, new()
    {
        private static object ChangeType(object value, Type conversionType)
        {
            return Convert.ChangeType(value, conversionType);
        }

        public static T ConvertRowEntity(SqlDataReader dr)
        {
            T _return = new T();
            foreach (PropertyInfo pro in typeof(T).GetProperties().ToList())
            {
                try
                {
                    object valor = dr.GetValue(dr.GetOrdinal(pro.Name));
                    if (valor == DBNull.Value)
                    {
                        _return.GetType().GetProperty(pro.Name).SetValue(null, null);
                    }
                    else
                    {
                        valor = ChangeType(valor, pro.PropertyType);
                        _return.GetType().GetProperty(pro.Name).SetValue(_return, valor);
                    }
                }
                catch (Exception)
                {

                }
            }
            return _return;
        }

        public SqlCommand GetInsertCommand()
        {
            SqlCommand _return = new SqlCommand();
            _return.CommandText = "Insert into {0} ({1}) Values ({2})";

            string tabela = typeof(T).Name;
            string campos = "";
            string valores = "";

            foreach (PropertyInfo prop in typeof(T).GetProperties().ToList().Where(
                p => p.GetCustomAttribute(typeof(DataObjectFieldAttribute)) != null))
            {
                campos += prop.Name + ", ";
                valores += "@" + prop.Name + ",";

                _return.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(this));
            }

            campos = campos.Substring(0, campos.Length - 2);
            valores = valores.Substring(0, valores.Length - 1);

            _return.CommandText = string.Format(_return.CommandText, tabela, campos, valores);

                return _return;
        }
    }
}
