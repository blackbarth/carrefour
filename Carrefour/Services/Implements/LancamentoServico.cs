using Carrefour.Data.Interfaces;
using Carrefour.Domain.Entities;
using Carrefour.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Carrefour.Services.Implements
{
    public class LancamentoServico : ILancamentoServico
    {
        private readonly ILancamentoRepositorio _lancamentoRepositorio;

        public LancamentoServico(ILancamentoRepositorio lancamentoRepositorio)
        {
            _lancamentoRepositorio = lancamentoRepositorio;
        }


        public async Task AdicionarLancamento(Lancamento lancamento)
        {
           await  _lancamentoRepositorio.AdicionarAsync(lancamento);
        }

        public async Task<IEnumerable<Lancamento>> ListarTodosLancamentos()
        {
            return await _lancamentoRepositorio.ObterTodosAsync();
        }

        public async Task<(IEnumerable<Lancamento> lancamentos, int totalPaginas)> ListarTodosLancamentosAsync(LancamentoFiltro filtro)
        {
            return await _lancamentoRepositorio.ListarTodosAsync(filtro);
        }

        public async Task<Lancamento> ObterLancamentoPorIdAsync(int id)
        {
            return await _lancamentoRepositorio.ObterLancamentoPorIdAsync(id);
        }

        public async Task ExcluirLancamentoAsync(int id)
        {
            await _lancamentoRepositorio.ExcluirLancamentoAsync(id);
    
        }

        public async Task AtualizarLancamentoAsync(Lancamento lancamento)
        {
            await _lancamentoRepositorio.AtualizarLancamentoAsync(lancamento);
        }
    }
}
