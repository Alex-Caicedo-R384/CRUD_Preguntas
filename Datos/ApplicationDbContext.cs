using CRUD_Preguntas.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Preguntas.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Preguntas> Preguntas { get; set; }
    }
}
