
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace Loja.Classes
{
    public partial class Contato : IDisposable
    {      
 
        public Contato()
        {
            this._codigo = Proximo();
            this._isNew = true;
            this._isModified = false;

        }
        public Contato(int Codigo)
        {
            //TODO: Criar o procedimento de leitura baseado no parâmetro codigo
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
                    cmd.CommandText = "Select * From Contato Where Codigo = @codigo";
                    cmd.Parameters.AddWithValue("@codigo", Codigo);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            this._codigo = dr.GetInt32(dr.GetOrdinal("Codigo"));
                            this._dadoscontato = dr.GetString(dr.GetOrdinal("DadosContato"));
                            this._tipo = dr.GetInt32(dr.GetOrdinal("Tipo"));
                            


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
                    cmd.CommandText = "Select Max(Codigo) + 1 From Contato";


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

        public static List<Contato> Todos(int Cliente)
        {
            List<Contato> _return = null;

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
                    cmd.CommandText = "Select * From Contato Where Cliente = @cliente";

                    cmd.Parameters.AddWithValue("@cliente", Cliente);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Contato con = ConvertRowEntity(dr);
                                                    
                                if (_return == null)
                                    _return = new List<Contato>();

                                con._isNew = false;

                                _return.Add(con);
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

