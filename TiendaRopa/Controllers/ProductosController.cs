using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using TiendaRopa.Models;

namespace TiendaRopa.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly Bdproductos903Context _baseDatos;

        public ProductosController(Bdproductos903Context baseDatos)
        {
            _baseDatos = baseDatos;
        }

        // GET: api/Productos/ListaProductos
        [HttpGet("ListaProductos")]
        public async Task<IActionResult> Lista()
        {
            var listaProductos = await _baseDatos.Productos.ToListAsync();
            return Ok(listaProductos);
        }

        // POST: api/Productos/AgregarProducto
        [HttpPost("AgregarProducto")]
        public async Task<IActionResult> Agregar([FromBody] Producto request)
        {
            if (request == null)
                return BadRequest("Producto inválido");

            await _baseDatos.Productos.AddAsync(request);
            await _baseDatos.SaveChangesAsync();
            return Ok(request); // devuelve el producto agregado con su Id
        }

        // PUT: api/Productos/ModificarProducto/5
        [HttpPut("ModificarProducto/{id:int}")]
        public async Task<IActionResult> Modificar(int id, [FromBody] Producto request)
        {
            var productoModificar = await _baseDatos.Productos.FindAsync(id);

            if (productoModificar == null)
                return NotFound("Producto no encontrado");

            // Actualiza los campos que quieras permitir
            productoModificar.Nombre = request.Nombre;
            productoModificar.talla = request.talla;
            productoModificar.color = request.color;
            productoModificar.descripcion = request.descripcion;
            productoModificar.precio = request.precio;

            try
            {
                await _baseDatos.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Error al guardar cambios");
            }

            return Ok(productoModificar);
        }

        // DELETE: api/Productos/EliminarProducto/5
        [HttpDelete("EliminarProducto/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var productoEliminar = await _baseDatos.Productos.FindAsync(id);

            if (productoEliminar == null)
                return NotFound("Producto no encontrado");

            _baseDatos.Productos.Remove(productoEliminar);
            await _baseDatos.SaveChangesAsync();

            return Ok("Producto eliminado");
        }
    }
}