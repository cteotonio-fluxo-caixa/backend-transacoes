namespace Transacoes.API.Models.Response
{
    public class CategoriaTransacaoResponse
    {
        /// <summary>
        /// Código da Categoria da Transação
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome da Categoria
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Descrição da categoria
        /// </summary>
        public string Descricao { get; set; }
    }
}
