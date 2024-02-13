using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Core.Entities;
using static Transacoes.Core.Services.ITransacaoServico;

namespace Transacoes.Core.Services
{
    public interface ITransacaoServico: IBaseServico<Transacao>
    {
        public abstract class BaseTransacaoValidator<T> : AbstractValidator<T> where T : Transacao
        {
            protected BaseTransacaoValidator() {
                int a = 0;
            }
            // Regras de validação comuns para transações, se necessário
        }

        // Exemplo de validador específico para transações
        public class TransacaoValidator : BaseTransacaoValidator<Transacao>
        {
            public TransacaoValidator()
            {
                RuleFor(x => x.DataTransacao)
                    .Must(TransacaoDataMaiorQueDataAtual)
                        .WithMessage("A Data da Transação não pode ser maior que a data atual");

                RuleFor(x => x.Descricao)
                    .NotEmpty().WithMessage("A descrição da transação deve ser informada")
                    .MinimumLength(10).WithMessage("A descrição precisa ter no mínimo 10 caracteres")
                    .MaximumLength(15).WithMessage("A descrição precisa ter no máximo 15 caracteres");

                RuleFor(x => x.Valor)
                    .NotEqual(0).WithMessage("O valor da transação deve ser diferente de zero");
                


                // Definir regras de validação específicas para transações, se necessário
            }
        }

        private static bool TransacaoDataMaiorQueDataAtual(DateTime date) => date < DateTime.Now;
    }
}
