using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transacoes.Aplicacao.DTOs
{
    public class CategoriaTransacaoDTO: BaseDto
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
