using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transacoes.Core.Entities
{
    /// <summary>
    /// Classe que representa a entidade Categoria da Transação
    /// </summary>
    public class CategoriaTransacao : BaseEntities
    {
        /// <summary>
        /// Contrutor
        /// </summary>
        /// <param name="nome">Nome da categoria</param>
        /// <param name="descricao">Descricao da categoria</param>
        public CategoriaTransacao(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
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
