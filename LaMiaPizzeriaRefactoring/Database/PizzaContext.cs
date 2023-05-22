using LaMiaPizzeriaRefactoring.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LaMiaPizzeriaRefactoring.Database
{
    public class PizzaContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<PizzaModel> Pizzas { get; set; }
        public DbSet<PrenotazioneModel> Prenotazioni { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=PizzaDb;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}