using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Loja.Classes
{
    public class Contato
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
            get { return _codigo; }
            set { _codigo = value; }
        }

        private string _dadoscontato;

        public string DadosContato
        {
            get { return _dadoscontato; }
            set { _dadoscontato = value; }
        }

        private int _tipo;

        public int Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

   

    }
}
