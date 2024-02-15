using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transacoes.Core.Entities
{
    /// <summary>
    /// Saldos dos dias
    /// </summary>
    public class SaldoDia: BaseEntities
    {
        /// <summary>
        /// Data do Saldo
        /// </summary>
        public DateTime DataSaldo { get; set; }

        /// <summary>
        /// Valor do saldo
        /// </summary>
        public decimal Saldo { get; set; }
    }
}
