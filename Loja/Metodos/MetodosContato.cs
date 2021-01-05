
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace Loja.Classes
{
    public partial class Contato : IDisposable
    {      

        public void Insert()
        {
            using (SqlConnection cn = new SqlConnection("Server=DESKTOP-T5DB7OK\\SQLEXPRESS;Database=Loja;Trusted_Connection=true;"))
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
                    cmd.CommandText = "Insert into Contato (Codigo, DadosContato, Tipo) Values (@codigo, @dadoscontato, @tipo, @cliente)";
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("@codigo", this._codigo);
                    cmd.Parameters.AddWithValue("@nome", this._dadoscontato);
                    cmd.Parameters.AddWithValue("@tipo", this._tipo);
                    cmd.Parameters.AddWithValue("@cliente", this._cliente);

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
        public void Update()
        {
            using (SqlConnection cn = new SqlConnection("Server=DESKTOP-T5DB7OK\\SQLEXPRESS;Database=Loja;Trusted_Connection=true;"))
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
                    cmd.CommandText = "Update Contato Set DadosContato = @dadoscontato, Tipo = @tipo Where Codigo = @codigo";
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("@codigo", this._codigo);
                    cmd.Parameters.AddWithValue("@dadoscontato", this._dadoscontato);
                    cmd.Parameters.AddWithValue("@tipo", this._tipo);
                    cmd.Parameters.AddWithValue("@cliente", this._cliente);


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
            using (SqlConnection cn = new SqlConnection("Server=DESKTOP-T5DB7OK\\SQLEXPRESS;Database=Loja;Trusted_Connection=true;"))
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
                    cmd.CommandText = "Delete Contato Where Codigo = @codigo";
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

        public Contato()
        {
            this._codigo = Proximo();
            this._isNew = true;
            this._isModified = false;

        }
        public Contato(int Codigo)
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

            using (System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection("Server=DESKTOP-T5DB7OK\\SQLEXPRESS;Database = Loja;Trusted_Connection=true;"))
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
                                Contato con = new Contato();
                                con._codigo = dr.GetInt32(dr.GetOrdinal("Codigo"));
                                con._dadoscontato = dr.GetString(dr.GetOrdinal("Dados Contato"));
                                con._tipo = dr.GetInt32(dr.GetOrdinal("Tipo"));
                                con._cliente = dr.GetInt32(dr.GetOrdinal("Cliente"));
                                

                                

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

