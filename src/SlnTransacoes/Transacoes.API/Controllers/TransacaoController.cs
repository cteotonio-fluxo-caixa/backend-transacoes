using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transacoes.API.Models.Request;
using Transacoes.Aplicacao.DTOs;
using Transacoes.Aplicacao.Servicos;
using Serilog;
using Transacoes.Core.Exceptions;

namespace Transacoes.API.Controllers
{
    /// <summary>
    /// Serviços para controle de Transações 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        /// <summary>
        /// App Servico de Transação
        /// </summary>
        private readonly ITransacaoAppService _transacaoAppService;
        /// <summary>
        /// Mapeador de objetos
        /// </summary>
        public readonly IMapper _mapper;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="transacaoAppService">App Servido de Transações</param>
        /// <param name="mapper">Mapeador de objetos</param>
        public TransacaoController (ITransacaoAppService transacaoAppService, IMapper mapper)
        {
            _transacaoAppService = transacaoAppService;
            _mapper = mapper;
        }

        /// <summary>
        /// Registra uma nova transação.
        /// </summary>
        /// <param name="transacao">Os dados da transação a serem registrados.</param>
        /// <returns>
        /// Um IActionResult representando o resultado da operação.
        /// - Retorna um código 200 (OK) se a transação for registrada com sucesso.
        /// - Retorna um código 400 (BadRequest) se a transação não puder ser registrada devido a problemas de validação.
        /// - Retorna um código 500 (InternalServerError) se ocorrer um erro interno ao processar a transação.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> RegistrarTransacao([FromBody] TransacaoRequest transacao)
        {
            try
            {
                var trans = _mapper.Map<TransacaoDTO>(transacao);
                await _transacaoAppService.RegistrarTransacao(trans);
                return Ok(new { Mensagem = "Transação registrada com sucesso.", transacao = trans }) ;
            }
            catch (TransacoesException ex)
            {
                return BadRequest(new { Mensagem = "A transação não pôde ser registrada devido a problemas de validação", Erro = ex.GetErrorMessage() });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao registrar transação: {@Transacao}", transacao);
                return StatusCode(500, "Erro interno ao processar a transação.");
            }
        }
    }
}
