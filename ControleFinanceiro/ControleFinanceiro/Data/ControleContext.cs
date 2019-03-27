using ControleFinanceiro.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ControleFinanceiro.Data
{
    public class ControleContext : DbContext
    {
        public ControleContext() : base("ControleFinanceiroContext")
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
