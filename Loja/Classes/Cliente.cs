
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Loja.Classes
{
    public  partial class Cliente : Backwork<Cliente>, ICRUD
    {
     
        private int _codigo;
        [DisplayName("Código")]
        [DataObjectField(true,true,false)]
        public int Codigo
        {
            get { 
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

        private string _nome;
        [DisplayName("Nome do cliente")]
        [DataObjectField(false, false, true)]
        public string Nome
        {
            get {
                return _nome;
            }
            set { 
              
               
                  
                    _nome = value;
                this._isModified = true;
            }

        }
        
        private int _tipo;
        [DisplayName("Tipo de cliente")]
        [DataObjectField(false, false, true)]

        public int Tipo
        {
            get {
                return _tipo;
            }
            set { 
                _tipo = value;
                this._isModified = true;
            }
        }

        private DateTime _datacadastro;
        [DisplayName("Data de cadastro")]
        [DataObjectField(false, false, true)]
        public DateTime DataCadastro
        {
            get {
                return _datacadastro;
            }
            set {
                _datacadastro = value;
                this._isModified = true;
            }
        }

        private List<Contato> _contato;

        public List<Contato> Contatos
        {
            get { 
                return _contato; 
            }
            set { 
                _contato = value;
            }
        }

        private bool _isNew;       
        private bool _isModified;

        [Browsable(false)]
        public bool IsNew
        {
            get { return _isNew; }
        }
        [Browsable(false)]
       public bool IsModified
        {
            get { return _isModified; }
        }
    }
}
