using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;

namespace ProjetoFinal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Local> Local { get; set; } = default!;
        public DbSet<Reserva> Reserva { get; set; } = default!;
    }
}
