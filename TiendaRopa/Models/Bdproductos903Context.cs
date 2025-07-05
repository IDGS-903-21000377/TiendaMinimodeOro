
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace TiendaRopa.Models
{
    public class Bdproductos903Context : DbContext
    {
        public Bdproductos903Context()
        {
        }

        public Bdproductos903Context(DbContextOptions<Bdproductos903Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.talla)
                      .HasMaxLength(50);

                entity.Property(e => e.color)
                      .HasMaxLength(50);

                entity.Property(e => e.descripcion)
                      .HasMaxLength(500);

                entity.Property(e => e.precio)
                      .HasColumnType("decimal(18,2)");
            });
        }
    }
}
