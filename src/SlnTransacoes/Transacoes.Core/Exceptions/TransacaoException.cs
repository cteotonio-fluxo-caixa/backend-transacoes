using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transacoes.Core.Exceptions
{

    // Exceção personalizada para erros relacionados a transações
    public class TransacoesException : Exception
    {
        public List<string> Errors { get; }
        public TransacoesException() { }
        public TransacoesException(string message) : base(message) { }
        public TransacoesException(string message, Exception innerException) : base(message, innerException) { }
        public TransacoesException(List<string> errors) : base("Erros relacionados à transação")
        {
            Errors = errors;
        }
        public string GetErrorMessage()
        {
            if (Errors != null)
              return string.Join(Environment.NewLine, Errors);
            else return string.Empty;
        }


    }

}
