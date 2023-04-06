using Carrefour.Domain.enums;

namespace Carrefour.Domain.Entities
{
    public class LancamentoFiltro
    {
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public TipoLancamento? Tipo { get; set; }
        public int Pagina { get; set; } = 1;
        public int ItensPorPagina { get; set; } = 10;
    }
}
