using Microsoft.EntityFrameworkCore;
using NumberDecompose.Domain;

namespace NumberDecompose.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Number> Number { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=number_decompose;User Id=sa;Password=235245M@is");
                //optionsBuilder.UseSqlServer("Server=172.18.0.2,1433;Database=number_decompose;User Id=sa;Password=235245M@is"); ip que o container do banco esta rodando
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}