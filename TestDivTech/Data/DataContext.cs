using Microsoft.EntityFrameworkCore;
using TestDivTech.Models;

namespace TestDivTech.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Fornecedor> FORNECEDOR { get; set; }
    }
}
