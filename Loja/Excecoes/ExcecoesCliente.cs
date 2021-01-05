using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Execoes
{
    public class ExcecoesCliente
    {

        [Serializable]
        public class ValidacaoException : Exception
        {
            public ValidacaoException() { }
            public ValidacaoException(string message) : base(message) { }
            public ValidacaoException(string message, Exception inner) : base(message, inner) { }
            protected ValidacaoException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context)
                : base(info, context) { }
        }
    }
}
