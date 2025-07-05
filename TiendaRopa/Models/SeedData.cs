using Microsoft.EntityFrameworkCore;

namespace TiendaRopa.Models
{
    public class SeedData
    {

        public static void Inicializar(IServiceProvider serviceProvider)
        {
            using (var context = new Bdproductos903Context(
                serviceProvider.GetRequiredService<DbContextOptions<Bdproductos903Context>>()))
            {
                // Si ya hay datos, no hacemos nada
                if (context.Productos.Any())
                {
                    return;
                }

                context.Productos.AddRange(
                    new Producto
                    {
                        Nombre = "Playera Oversize",
                        talla = "M",
                        color = "Negro",
                        descripcion = "Playera de algodón estilo urbano.",
                        precio = 299.99M
                    },
                    new Producto
                    {
                        Nombre = "Pantalón Cargo",
                        talla = "L",
                        color = "Verde militar",
                        descripcion = "Pantalón cómodo con bolsillos laterales.",
                        precio = 499.00M
                    },
                    new Producto
                    {
                        Nombre = "Sudadera con capucha",
                        talla = "XL",
                        color = "Gris",
                        descripcion = "Sudadera térmica para clima frío.",
                        precio = 649.50M
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
