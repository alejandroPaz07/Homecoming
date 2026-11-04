
using Homecoming.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Homecoming.Data
{
    public class HomecomingContext : IdentityDbContext
    {
        public HomecomingContext(
            DbContextOptions<HomecomingContext> options)
            : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
    }
}
