using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
public static class MetodosExtensao
{
    public static int Metade (this int valor)
    {
        return valor / 2;
    }
    public static double Juros (this double Valor)
    {
        return Valor + 20;
    }
    public static string PrimeiraMaiuscula(this string Valor)
    {
        return Valor.Substring(0, 1).ToUpper() + Valor.Substring(1, Valor.Length - 1).ToLower();
    }
}

namespace Loja.Classes

{
   public partial class Cliente : IDisposable
    {
    public void Insert()
        {
            using (SqlConnection cn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=Loja;Trusted_Connection=true;"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }

                SqlCommand cmd = this.GetInsertCommand();
                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
            }
               
          
    }
    public void Update()
        {
            using (SqlConnection cn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=Loja;Trusted_Connection=true;"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Update Cliente Set Nome = @nome, Tipo = @tipo, DataCadastro = @datacadastro Where Codigo = @codigo";
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("@codigo", this._codigo);
                    cmd.Parameters.AddWithValue("@nome", this._nome);
                    cmd.Parameters.AddWithValue("@tipo", this._tipo);
                    cmd.Parameters.AddWithValue("@datacadastro", this._datacadastro);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
            }
    }
    public void Gravar()
    {
            if (this._isNew)
            {
                Insert();
            }
            else if (this._isModified)
            {
                Update();
                }
            
    }

    public void Apagar()
        {
            using (SqlConnection cn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=Loja;Trusted_Connection=true;"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Delete Cliente Where Codigo = @codigo";
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("@codigo", this._codigo);


                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
            }
        }

    public Cliente()
        {
            this._codigo = Proximo();
            this._isNew = true;
            this._isModified = false;
            
        }
    public Cliente(int Codigo)
        {
            //TODO: Criar o procedimento de leitura baseado no parâmetro codigo
            using (SqlConnection cn = new SqlConnection("Server=DESKTOP-T5DB7OK\\SQLEXPRESS;Database = Loja;Trusted_Connection=true;"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "Select * From Cliente Where Codigo = @codigo";
                    cmd.Parameters.AddWithValue("@codigo", Codigo);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            this._codigo = dr.GetInt32(dr.GetOrdinal("Codigo"));
                            this._nome = dr.GetString(dr.GetOrdinal("Nome"));
                            this._tipo = dr.GetInt32(dr.GetOrdinal("Tipo"));
                            this._datacadastro = dr.GetDateTime(dr.GetOrdinal("DataCadastro"));

                           
                        }
                    }
                    this._isNew = false;
                    this._isModified = false;
                }
            }
            
        }
    public static Int32 Proximo()
        {
            Int32 _return = 0;
            using (SqlConnection cn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=Loja;Trusted_Connection=true;"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "Select Max(Codigo) + 1 From Cliente";
                    

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            _return = dr.GetInt32(0);
                           
                        }
                    }
                    
                }
            }
            return _return;
        }
    
    public static List<Cliente> Todos()
        {
            List<Cliente> _return = null;

            using (System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=Loja;Trusted_Connection=true;"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "Select * From Cliente";
                    

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read()) {
                                Cliente cli = ConvertRowEntity(dr);
                          //   cli._codigo = dr.GetInt32(dr.GetOrdinal("Codigo"));
                          //   cli._nome = dr.GetString(dr.GetOrdinal("Nome"));
                          //   cli._tipo = dr.GetInt32(dr.GetOrdinal("Tipo"));
                          //   cli._datacadastro = dr.GetDateTime(dr.GetOrdinal("DataCadastro"));

                                cli.Contatos = Contato.Todos(cli._codigo);

                                if (_return == null)
                                    _return = new List<Cliente>();

                                 cli._isNew = false;

                                    _return.Add(cli);
                            }
                        }
                            
                           
                    }
                    
                }
            }

            return _return;
        }
    public void Dispose()
        {
            this.Gravar();
        }
    }
}
