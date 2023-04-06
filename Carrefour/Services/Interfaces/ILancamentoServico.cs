using Carrefour.Domain.Entities;
using System.Runtime.CompilerServices;

namespace Carrefour.Services.Interfaces
{
    public interface ILancamentoServico
    {
        Task<(IEnumerable<Lancamento> lancamentos, int totalPaginas)> ListarTodosLancamentosAsync(LancamentoFiltro filtro);

        Task<IEnumerable<Lancamento>> ListarTodosLancamentos();
        Task AdicionarLancamento(Lancamento lancamento);
        Task<Lancamento> ObterLancamentoPorIdAsync(int id);
        Task ExcluirLancamentoAsync(int id);
        Task AtualizarLancamentoAsync(Lancamento lancamento);
    }
}
