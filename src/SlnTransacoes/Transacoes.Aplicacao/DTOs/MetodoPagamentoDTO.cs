using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transacoes.Aplicacao.DTOs
{
    public class MetodoPagamentoDTO: BaseDto
    {
        /// <summary>
        /// Nome do método de pagamento
        /// </summary>
        public string Nome { get; set; } = string.Empty;
        /// <summary>
        /// Descrição do método de pagamento
        /// </summary>
        public string Descricao { get; set; } = string.Empty;
    }
}
