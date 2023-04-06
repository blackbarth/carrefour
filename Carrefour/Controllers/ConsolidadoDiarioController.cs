using Carrefour.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Carrefour.Controllers
{
    public class ConsolidadoDiarioController : Controller
    {
        private readonly IConsolidadoDiarioServico _consolidadoDiarioServico;

        public ConsolidadoDiarioController(IConsolidadoDiarioServico consolidadoDiarioServico)
        {
            _consolidadoDiarioServico = consolidadoDiarioServico;
        }

        public async Task<IActionResult> Index()
        {
            var consolidadoDiario = await _consolidadoDiarioServico.GerarConsolidadoDiario();
            return View(consolidadoDiario);
        }
    }
}
