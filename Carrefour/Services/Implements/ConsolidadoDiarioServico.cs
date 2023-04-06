using Carrefour.Data.Interfaces;
using Carrefour.Domain.Entities;
using Carrefour.Domain.enums;
using Carrefour.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Carrefour.Services.Implements
{
    public class ConsolidadoDiarioServico : IConsolidadoDiarioServico
    {
        private readonly ILancamentoRepositorio _lancamentoRepositorio;

        public ConsolidadoDiarioServico(ILancamentoRepositorio lancamentoRepositorio)
        {
            _lancamentoRepositorio = lancamentoRepositorio;
        }

        public async Task<IEnumerable<ConsolidadoDiario>> GerarConsolidadoDiario()
        {
            var lancamentos = await _lancamentoRepositorio.ObterTodosAsync();

            return lancamentos
                .GroupBy(l => l.Data.Date)
                .Select(g => new ConsolidadoDiario
                {
                    Data = g.Key,
                    Total = g.Sum(l => l.Tipo == TipoLancamento.Credito ? l.Valor : -l.Valor)
                })
                .OrderBy(c => c.Data);
        }
    }
}
