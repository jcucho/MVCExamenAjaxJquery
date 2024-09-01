using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCExamen.Models;

namespace MVCExamen.Controllers
{
    public class ProductosController : Controller
    {
        private readonly MVCExamenContext _context;

        public ProductosController(MVCExamenContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
              return _context.Productos != null ? 
                          View(await _context.Productos.ToListAsync()) :
                          Problem("Entity set 'MVCExamenContext.Productos'  is null.");
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.ProductoID == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoID,Nombre,Precio,FechaVencimiento")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductoID,Nombre,Precio,FechaVencimiento")] Producto producto)
        {
            if (id != producto.ProductoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.ProductoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.ProductoID == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'MVCExamenContext.Productos'  is null.");
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
          return (_context.Productos?.Any(e => e.ProductoID == id)).GetValueOrDefault();
        }

        // GET: Productos/Create
        public IActionResult Busqueda()
        {
            return View();
        }

        [HttpGet] // Decorador para manejar solicitudes GET
        public IActionResult GetProductos(string nombre, string precio)
        {
            IQueryable<Producto> query = _context.Productos;

            if (!string.IsNullOrEmpty(nombre))
                query = query.Where(x => x.Nombre.Contains(nombre));

            if (!string.IsNullOrEmpty(precio))
                query = query.Where(x => x.Precio == Convert.ToDecimal(precio));

            //var productos = _context.Productos.ToList();
            return Json(query.ToList());
        }

        // Acción para abrir el modal de crear estudiante
        public IActionResult CrearProducto()
        {
            return PartialView("_CrearProductoPartial");
        }

        [HttpPost]
        public async Task<IActionResult> SubmitForm(string nombre, string precio, string fechaVencimiento)
        {
            try
            {
                var producto = new Producto
                {
                    Nombre = nombre,
                    Precio = Convert.ToDecimal(precio),
                    FechaVencimiento = Convert.ToDateTime(fechaVencimiento)
                };

                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                return Json(new { message = "Producto registrado con éxito." });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
            }
        }
    }
}
