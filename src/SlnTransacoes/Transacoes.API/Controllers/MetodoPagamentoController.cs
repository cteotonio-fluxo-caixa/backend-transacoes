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
    /// Serviço para controle de Métodos de Pagamentos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MetodoPagamentoController : ControllerBase
    {
        /// <summary>
        /// App Serviço de Metodo de Pagamento
        /// </summary>
        private readonly IMetodoPagamentoAppService _metodoPagamentoAppService;
        /// <summary>
        /// Mapeador de objetos
        /// </summary>
        public readonly IMapper _mapper;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="metodoPagamentoAppService">App Serviço de Metodo de Pagamento</param>
        /// <param name="mapper">Mapeador de objetos</param>
        public MetodoPagamentoController(IMetodoPagamentoAppService metodoPagamentoAppService, IMapper mapper)
        {
            _metodoPagamentoAppService = metodoPagamentoAppService;
            _mapper = mapper;
        }

        /// <summary>
        /// Registra uma novo metodo de pagamento.
        /// </summary>
        /// <param name="metodoPagamento">Os dados do método de pagamento a serem registrados.</param>
        /// <returns>
        /// Um IActionResult representando o resultado da operação.
        /// - Retorna um código 200 (OK) se o método de pagamento for registrado com sucesso.
        /// - Retorna um código 400 (BadRequest) se o método de pagamento não puder ser registrado devido a problemas de validação.
        /// - Retorna um código 500 (InternalServerError) se ocorrer um erro interno ao processar o método de pagamento.
        /// </returns>
        [ProducesResponseType<MetodoPagamentoResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> RegistrarMetodoPagamento([FromBody] MetodoPagamentoRequest metodoPagamento)
        {
            try
            {
                var metpag = _mapper.Map<MetodoPagamentoDTO>(metodoPagamento);
                await _metodoPagamentoAppService.RegistrarMetodoPagamento(metpag);
                var response = _mapper.Map<MetodoPagamentoResponse>(metpag);
                return Ok(response);
            }
            catch (TransacoesException ex)
            {
                return BadRequest(new { Mensagem = "O método de pagamento não pôde ser registrado devido a problemas de validação", Erro = ex.GetErrorMessage() });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao registrar método de pagamento: {@MetodoPagamento}", metodoPagamento);
                return StatusCode(500, "Erro interno ao processar a transação.");
            }
        }
    }
}
