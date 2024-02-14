namespace Transacoes.API.Models.Request
{
    public class CategoriaTransacaoRequest
    {
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
