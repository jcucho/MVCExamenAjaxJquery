using Microsoft.EntityFrameworkCore;

namespace MVCExamen.Models
{
    public class MVCExamenContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }

        public MVCExamenContext(DbContextOptions<MVCExamenContext> options):base(options)
        {
                
        }
    }
}
