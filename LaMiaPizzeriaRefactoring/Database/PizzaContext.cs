using LaMiaPizzeriaRefactoring.Models;
using Microsoft.EntityFrameworkCore;

namespace LaMiaPizzeriaRefactoring.Database
{
    public class PizzaContext : DbContext
    {
        public DbSet<PizzaModel> Pizzas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=PizzaDb;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}