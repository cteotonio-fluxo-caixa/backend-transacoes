namespace Transacoes.API.Models.Response
{
    public class MetodoPagamentoResponse
    {
        public Guid Id { get; set; }
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
