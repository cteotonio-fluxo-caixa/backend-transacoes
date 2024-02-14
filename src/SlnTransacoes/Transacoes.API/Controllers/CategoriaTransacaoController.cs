using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Transacoes.API.Models.Request;
using Transacoes.API.Models.Response;
using Transacoes.Aplicacao.DTOs;
using Transacoes.Aplicacao.Servicos;
using Transacoes.Core.Exceptions;

namespace Transacoes.API.Controllers
{
    /// <summary>
    /// Serviço para controle de Categorias de Transações
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaTransacaoController : ControllerBase
    {
        /// <summary>
        /// App Serviço de Categoria de Transação
        /// </summary>
        private readonly ICategoriaTransacaoAppService _categoriaTransacaoAppService;
        /// <summary>
        /// Mapeador de objetos
        /// </summary>
        public readonly IMapper _mapper;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="categoriaTransacaoAppService">App Serviço de Categoria de Transação</param>
        /// <param name="mapper">Mapeador de objetos</param>
        public CategoriaTransacaoController(ICategoriaTransacaoAppService categoriaTransacaoAppService, IMapper mapper)
        {
            _categoriaTransacaoAppService = categoriaTransacaoAppService;
            _mapper = mapper;
        }

        /// <summary>
        /// Registra uma nova categoria de transacação.
        /// </summary>
        /// <param name="categoriaTransacao">Os dados da categoria de transação a serem registrados.</param>
        /// <returns>
        /// Um IActionResult representando o resultado da operação.
        /// - Retorna um código 200 (OK) se categoria de transação for registrada com sucesso.
        /// - Retorna um código 400 (BadRequest) se categoria de transação não puder ser registrada devido a problemas de validação.
        /// - Retorna um código 500 (InternalServerError) se ocorrer um erro interno ao processar o método de pagamento.
        /// </returns>
        [ProducesResponseType<CategoriaTransacaoResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> RegistrarMetodoPagamento([FromBody] CategoriaTransacaoRequest categoriaTransacao)
        {
            try
            {
                var categtrans = _mapper.Map<CategoriaTransacaoDTO>(categoriaTransacao);
                await _categoriaTransacaoAppService.RegistrarCategoriaTransacao(categtrans);
                var response = _mapper.Map<CategoriaTransacaoResponse>(categtrans);
                return Ok(response);
            }
            catch (TransacoesException ex)
            {
                return BadRequest(new { Mensagem = "A categoria de transação não pôde ser registrado devido a problemas de validação", Erro = ex.GetErrorMessage() });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao registrar categoria de transação: {@CategoriaTransacao}", categoriaTransacao);
                return StatusCode(500, "Erro interno ao processar a transação.");
            }
        }
    }
}
