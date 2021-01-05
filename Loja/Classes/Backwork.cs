using System;
using System.Collections.Generic;
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
    }
}
