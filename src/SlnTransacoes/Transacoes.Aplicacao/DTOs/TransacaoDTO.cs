using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Core.Entities;

namespace Transacoes.Aplicacao.DTOs
{
    public class TransacaoDTO: BaseDto
    {
        /// <summary>
        /// Valor da transação
        /// </summary>
        public decimal Valor { get; set; } = 0;

        /// <summary>
        /// Data da Transação
        /// </summary>
        public DateTime DataTransacao { get; set; }= DateTime.Now;

        /// <summary>
        /// Indicação de a operação é Crédito ou Débito
        /// </summary>
        public bool IsCredito { get; set; } = false;

        /// <summary>
        /// Descrição da transação
        /// </summary>
        public string Descricao { get; set; } = string.Empty;

        /// <summary>
        /// Id do Usuário que criou o registro
        /// </summary>
        public Guid CriadoPorId { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Data de criação do registro
        /// </summary>
        public DateTime CriadoEm { get; set; } = DateTime.Now;

        /// <summary>
        /// Id do Usuário que modificou o registro
        /// </summary>
        public Guid? ModificadoPor { get; set; } = null;

        /// <summary>
        /// Data de modificação do registro
        /// </summary>
        public DateTime? ModificadoEm { get; set; } = null;

        /// <summary>
        /// Id do usuário que modificou o registro
        /// </summary>
        public Guid? ExcluidoPor { get; set; } = null;

        /// <summary>
        /// Data de exclusão do registro
        /// </summary>
        public DateTime? ExcluidoEm { get; set; } = null;

        /// <summary>
        /// Indica se o registro foi excluído
        /// </summary>
        public bool Excluido { get; set; } = false;

        /// <summary>
        /// Id da Categoria
        /// </summary>
        public Guid CategoriaId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Id do Método de Pagamento
        /// </summary>
        public Guid MetodoPagamentoId { get; set; } = Guid.NewGuid();
    }
}
