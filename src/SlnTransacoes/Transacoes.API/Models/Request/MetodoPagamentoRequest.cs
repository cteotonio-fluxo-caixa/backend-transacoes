namespace Transacoes.API.Models.Request
{
    public class MetodoPagamentoRequest
    {
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
