
using System.ComponentModel;

namespace Loja.Classes
{
    public partial class Contato : Backwork<Contato>
    {
        private bool _isNew;
        [Browsable(false)]
        public bool IsNew
        {
            get { return _isNew; }

        }

        private bool _isModified;
        [Browsable(false)]
        public bool IsModified
        {
            get { return _isModified; }

        }


        private int _codigo;
        
        public int Codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                if (value < 0)
                {
                    throw new Loja.Execoes.ExcecoesCliente.ValidacaoException("O codigo do cliente não pode ser negativo");

                }
                _codigo = value;
                this._isModified = true;
            }
        }

        private string _dadoscontato;
        
        public string DadosContato
        {
            get
            {
                return _dadoscontato;
            }
            set
            {
                _dadoscontato = value;
                this._isModified = true;
            }

        }

        private int _tipo;
        

        public int Tipo
        {
            get
            {
                return _tipo;
            }
            set
            {
                _tipo = value;
                this._isModified = true;
            }
        }

        private int _cliente;
        [Browsable(false)]
        public int Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }


        }


    }
}
