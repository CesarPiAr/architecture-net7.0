using Microsoft.EntityFrameworkCore;
using Proyecto.API.Domain.Entities;

namespace Proyecto.API.Infrastructure.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; }
    }
}
