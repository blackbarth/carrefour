using Carrefour.Domain.enums;

namespace Carrefour.Domain.Entities
{
    public class Lancamento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoLancamento Tipo { get; set; }
    }
}
