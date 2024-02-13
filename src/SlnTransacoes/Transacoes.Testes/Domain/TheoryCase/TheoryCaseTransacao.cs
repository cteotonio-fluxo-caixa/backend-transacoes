using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transacoes.Testes.Domain
{
    public partial class TransacaoServiceTeste
    {
        public static readonly object[][] DatasCorretas =
        {
            new object[] { "Teste Data Fixa: ", new DateTime(2017,3,1) },
            new object[] { "Teste Data Atua - 5 dias", DateTime.Now.AddDays(-5)}
        };

        public static readonly object[][] TransacoesValidas =
        {       
            new object[] { "Cenário 1: Transação Válida para inclusão", Guid.NewGuid(), 15.0, new DateTime(2017,3,1), true, "Teste descrição", Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), Guid.NewGuid()   },
        };

        public static readonly object[][] TransacoesInValidas =
        {
            new object[] { "Cenário 1: A descrição precisa ter no mínimo 10 caracteres ", Guid.NewGuid(), 15, new DateTime(2017,3,1), true, "Test", Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), Guid.NewGuid() },
            new object[] { "Cenário 2: A Data da Transação não pode ser maior que a data atual ", Guid.NewGuid(), 15, DateTime.Now.AddDays(1), true, "Teste descrição", Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), Guid.NewGuid() },
            new object[] { "Cenário 3: O valor da transação deve ser diferente de zero ", Guid.NewGuid(), 0, new DateTime(2017, 3, 1), true, "Teste descrição", Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), Guid.NewGuid() },
            new object[] { "Cenário 4: A descrição da transação deve ser informada ", Guid.NewGuid(), 15, new DateTime(2017, 3, 1), true, null, Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), Guid.NewGuid() },
            new object[] { "Cenário 5: A descrição da transação deve ser informada ", Guid.NewGuid(), 15, new DateTime(2017, 3, 1), true, "            ", Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), Guid.NewGuid() },
            new object[] { "Cenário 6: A descrição precisa ter no máximo 15 caracteres ", Guid.NewGuid(), 15, new DateTime(2017, 3, 1), true, "Teste decrição transacao - Teste decrição transacao", Guid.NewGuid(), DateTime.Now, Guid.NewGuid(), Guid.NewGuid() },
        };
    }
}
