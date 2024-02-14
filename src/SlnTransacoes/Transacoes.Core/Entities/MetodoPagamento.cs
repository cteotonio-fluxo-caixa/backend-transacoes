using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transacoes.Core.Entities
{
    /// <summary>
    /// Classe que representa a entidade de Métodos de Pagamentos
    /// </summary>
    public class MetodoPagamento: BaseEntities
    {
        public MetodoPagamento()
        {
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="nome">Nome do método de pagamento</param>
        /// <param name="descricao">Descrição do método de pagamento</param>
        public MetodoPagamento(string nome, string descricao) 
        {
            Nome = nome;
            Descricao = descricao;
        }

        /// <summary>
        /// Nome do método de pagamento
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Descrição do método de pagamento
        /// </summary>
        public string Descricao { get; set; }
    }
}
