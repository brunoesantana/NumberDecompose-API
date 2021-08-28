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
                optionsBuilder.UseSqlServer("Server=BRUNOPC\\SQLEXPRESS;Database=number_decompose;Trusted_Connection=True");
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}