using Carrefour.Context;
using Carrefour.Data.Interfaces;
using Carrefour.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carrefour.Data.Implements
{
    public class LancamentoRepositorio : ILancamentoRepositorio
    {
        private readonly LancamentoContext _context;

        public LancamentoRepositorio(LancamentoContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Lancamento lancamento)
        {
            _context.Lancamentos.Add(lancamento);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Lancamento>> ObterTodosAsync()
        {
            return await _context.Lancamentos.ToListAsync();
        }

        public async Task<IEnumerable<ConsolidadoDiario>> ObterConsolidadoDiarioAsync()
        {
            return await _context.Lancamentos.GroupBy(l => l.Data.Date)
                                             .Select(g => new ConsolidadoDiario { Data = g.Key, Total = g.Sum(l => l.Valor) })
                                             .ToListAsync();
        }

        public async Task<(IEnumerable<Lancamento> lancamentos, int totalPaginas)> ListarTodosAsync(LancamentoFiltro filtro)
        {
            var query = _context.Lancamentos.AsQueryable();

            if (filtro.DataInicio.HasValue)
            {
                query = query.Where(l => l.Data.Date >= filtro.DataInicio.Value.Date);
            }

            if (filtro.DataFim.HasValue)
            {
                query = query.Where(l => l.Data.Date <= filtro.DataFim.Value.Date);
            }

            if (filtro.Tipo.HasValue)
            {
                query = query.Where(l => l.Tipo == filtro.Tipo.Value);
            }

            int totalPaginas = (int)Math.Ceiling(await query.CountAsync() / (double)filtro.ItensPorPagina);

            query = query
                .Skip((filtro.Pagina - 1) * filtro.ItensPorPagina)
                .Take(filtro.ItensPorPagina);

            var lancamentos = await query.ToListAsync();

            return (lancamentos, totalPaginas);
        }

        public async Task<Lancamento> ObterLancamentoPorIdAsync(int id)
        {
            return await _context.Lancamentos.FindAsync(id);
        }

        public async Task ExcluirLancamentoAsync(int id)
        {
            var lancamento = await _context.Lancamentos.FindAsync(id);
            if (lancamento != null)
            {
                _context.Lancamentos.Remove(lancamento);
                await _context.SaveChangesAsync();
            }
        }
        public async Task AtualizarLancamentoAsync(Lancamento lancamento)
        {
            _context.Entry(lancamento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }

}
