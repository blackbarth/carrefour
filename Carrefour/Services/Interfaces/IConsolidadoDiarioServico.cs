using Carrefour.Domain.Entities;

namespace Carrefour.Services.Interfaces
{
    public interface IConsolidadoDiarioServico
    {
        Task<IEnumerable<ConsolidadoDiario>> GerarConsolidadoDiario();
    }
}
