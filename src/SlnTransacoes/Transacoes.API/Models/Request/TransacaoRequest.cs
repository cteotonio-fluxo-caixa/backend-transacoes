namespace Transacoes.API.Models.Request
{
    /// <summary>
    /// Modelo para criação de Transações
    /// </summary>
    public class TransacaoRequest
    {
        /// <summary>
        /// Valor da transação
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Data da Transação
        /// </summary>
        public DateTime DataTransacao { get; set; }

        /// <summary>
        /// Indica se a operação é Crédito ou Débito
        /// </summary>
        public bool IsCredito { get; set; }

        /// <summary>
        /// Descrição da transação
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Código da Categoria
        /// </summary>
        public Guid CategoriaId { get; set; }

        /// <summary>
        /// Código do Método de Pagamento
        /// </summary>
        public Guid MetodoPagamentoId { get; set; }

        ///// <summary>
        ///// Id do Usuário que criou o registro
        ///// </summary>
        //public Guid CriadoPorId { get; set; }

        ///// <summary>
        ///// Data de criação do registro
        ///// </summary>
        //public DateTime CriadoEm { get; set; }

        ///// <summary>
        ///// Indica se o registro foi excluído
        ///// </summary>
        //public bool Excluido { get; set; }


    }
}
