using Carrefour.Domain.Entities;

namespace Carrefour.Data.Interfaces
{
    public interface ILancamentoRepositorio
    {
        Task<(IEnumerable<Lancamento> lancamentos, int totalPaginas)> ListarTodosAsync(LancamentoFiltro filtro);

        Task<IEnumerable<Lancamento>> ObterTodosAsync();
        Task AdicionarAsync(Lancamento lancamento);
        Task<IEnumerable<ConsolidadoDiario>> ObterConsolidadoDiarioAsync();

        Task<Lancamento> ObterLancamentoPorIdAsync(int id);
        Task ExcluirLancamentoAsync(int id);
        Task AtualizarLancamentoAsync(Lancamento lancamento);
    }
}
