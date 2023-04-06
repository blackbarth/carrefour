using Carrefour.Domain.Entities;
using Carrefour.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Carrefour.Controllers
{
    public class LancamentoController : Controller
    {
        private readonly ILancamentoServico _lancamentoServico;

        public LancamentoController(ILancamentoServico lancamentoServico)
        {
            _lancamentoServico = lancamentoServico;
        }

        public async Task<IActionResult> Index(LancamentoFiltro filtro)
        {
            var (lancamentos, totalPaginas) = await _lancamentoServico.ListarTodosLancamentosAsync(filtro);
            ViewBag.TotalPaginas = totalPaginas;
            ViewBag.Filtro = filtro;
            return View(lancamentos);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(Lancamento lancamento)
        {
            if (ModelState.IsValid)
            {
                await _lancamentoServico.AdicionarLancamento(lancamento);
                return RedirectToAction("Index");
            }
            return View(lancamento);
        }

        // GET: Lancamento/Editar/5
        public async Task<IActionResult> Editar(int id)
        {
            var lancamento = await _lancamentoServico.ObterLancamentoPorIdAsync(id);
            if (lancamento == null)
            {
                return NotFound();
            }
            return View(lancamento);
        }

        // POST: Lancamento/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Lancamento lancamento)
        {
            if (id != lancamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _lancamentoServico.AtualizarLancamentoAsync(lancamento);
                return RedirectToAction(nameof(Index));
            }
            return View(lancamento);
        }

        // GET: Lancamento/Excluir/5
        public async Task<IActionResult> Excluir(int id)
        {
            var lancamento = await _lancamentoServico.ObterLancamentoPorIdAsync(id);
            if (lancamento == null)
            {
                return NotFound();
            }
            return View(lancamento);
        }

        // POST: Lancamento/Excluir/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExcluirConfirmado(int id)
        {
            await _lancamentoServico.ExcluirLancamentoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
