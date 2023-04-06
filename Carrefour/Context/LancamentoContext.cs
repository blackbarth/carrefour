using Carrefour.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Carrefour.Context
{
    public class LancamentoContext : DbContext
    {
        public LancamentoContext(DbContextOptions<LancamentoContext> options) : base(options)
        {
        }

        public DbSet<Lancamento> Lancamentos { get; set; }
    }
}
