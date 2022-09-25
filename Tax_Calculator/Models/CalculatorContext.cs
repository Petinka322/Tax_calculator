namespace Tax_Calculator.Models
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.SqlServer;
    public class CalculatorContext:DbContext
    {
        public DbSet<Taxes> Taxes { get; set; }
        public DbSet<TaxPayer> TaxPayer { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-NFLODBL\SQLEXPRESS;Database=CalculatprDb;Trusted_Connection=True; ");
        }
    }
}
