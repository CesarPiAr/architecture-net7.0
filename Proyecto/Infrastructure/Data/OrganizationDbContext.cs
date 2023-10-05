using Microsoft.EntityFrameworkCore;
using Proyecto.API.Domain.Entities;

namespace Proyecto.API.Infrastructure.Data
{
    public class OrganizationDbContext : DbContext
    {
        public OrganizationDbContext(DbContextOptions<OrganizationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Organizacion> Organizaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Organizacion)
                .WithMany(o => o.Usuarios)
                .HasForeignKey(u => u.OrganizacionId)
                .IsRequired();
        }
    }
}
