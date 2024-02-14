using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Core.Entities;

namespace Transacoes.Core.Services
{
    public interface IMetodoPagamentoServico: IBaseServico<MetodoPagamento>
    {
        public abstract class BaseMetodoPagamentoServicoValidator<T> : AbstractValidator<T> where T : MetodoPagamento
        {
            protected BaseMetodoPagamentoServicoValidator()
            {

            }
        }

        public class MetodoPagamentoValidator : BaseMetodoPagamentoServicoValidator<MetodoPagamento>
        {
            public MetodoPagamentoValidator()
            {
                RuleFor(x => x.Id)
                    .NotEmpty().WithMessage("Um código deve ser informado");

                RuleFor(x => x.Nome)
                    .NotEmpty().WithMessage("Um nome deve ser informado")
                    .MinimumLength(2).WithMessage("O nome precisa ter no mínimo 2 caracteres")
                    .MaximumLength(20).WithMessage("O nome precisa ter no máximo 20 caracteres");

                RuleFor(x => x.Descricao)
                    .NotEmpty().WithMessage("Uma descrição deve ser informada")
                    .MinimumLength(10).WithMessage("A descrição precisa ter no mínimo 10 caracteres")
                    .MaximumLength(50).WithMessage("A descrição precisa ter no máximo 50 caracteres");
            }
        }
    }
}
