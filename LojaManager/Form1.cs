using Loja.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LojaManager
{
    public partial class Form1 : Form
    {
        BindingSource dados = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;


            dados.DataSource = Cliente.Todos();
            dataGridView1.DataSource = dados;

            txtCodigo.DataBindings.Add("Text", dados, "Codigo", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNome.DataBindings.Add("Text", dados, "Nome", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTipo.DataBindings.Add("Text", dados, "Tipo", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDataCadastro.DataBindings.Add("Text", dados, "DataCadastro", true, DataSourceUpdateMode.OnPropertyChanged);

            txtCodigoContato.DataBindings.Add("Text", ((Cliente)dados.Current).Contatos, "Codigo", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDadosContato.DataBindings.Add("Text", ((Cliente)dados.Current).Contatos, "Dados Contato", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTipoContato.DataBindings.Add("Text", ((Cliente)dados.Current).Contatos, "Tipo", true, DataSourceUpdateMode.OnPropertyChanged);
            txtClienteContato.DataBindings.Add("Text", ((Cliente)dados.Current).Contatos, "Cliente", true, DataSourceUpdateMode.OnPropertyChanged);


            dados.CurrentChanged += dados_CurrentChanged;
        }

        void dados_CurrentChanged(object sender, EventArgs e)
        {
            dgvContatos.DataSource = ((Cliente)dados.Current).Contatos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Cliente)dados.Current).Gravar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dados.Add(new Cliente());
            dados.MoveLast();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente apagar este cliente?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                ((Cliente)dados.Current).Apagar();
                dados.RemoveCurrent();
            }
            
        }


    }
}
