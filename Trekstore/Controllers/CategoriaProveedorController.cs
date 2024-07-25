using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trekstore.Areas.Identity.Data;
using Trekstore.Models;

namespace Trekstore.Controllers
{
    public class CategoriaProveedorController : Controller
    {
        private readonly TrekstorDbContext _context;

        public CategoriaProveedorController(TrekstorDbContext context)
        {
            _context = context;
        }

        // GET: CategoriaProveedor
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaProveedor.ToListAsync());
        }

        // GET: CategoriaProveedor/Details/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProveedor = await _context.CategoriaProveedor
                .FirstOrDefaultAsync(m => m.CategoriaProveedorID == id);
            if (categoriaProveedor == null)
            {
                return NotFound();
            }

            return View(categoriaProveedor);
        }

        // GET: CategoriaProveedor/Create
        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaProveedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaProveedorID,CategoriaProveedorNombre,CategoriaProveedorDescripcion")] CategoriaProveedor categoriaProveedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaProveedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaProveedor);
        }

        // GET: CategoriaProveedor/Edit/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProveedor = await _context.CategoriaProveedor.FindAsync(id);
            if (categoriaProveedor == null)
            {
                return NotFound();
            }
            return View(categoriaProveedor);
        }

        // POST: CategoriaProveedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaProveedorID,CategoriaProveedorNombre,CategoriaProveedorDescripcion")] CategoriaProveedor categoriaProveedor)
        {
            if (id != categoriaProveedor.CategoriaProveedorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaProveedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaProveedorExists(categoriaProveedor.CategoriaProveedorID))
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
            return View(categoriaProveedor);
        }

        // GET: CategoriaProveedor/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProveedor = await _context.CategoriaProveedor
                .FirstOrDefaultAsync(m => m.CategoriaProveedorID == id);
            if (categoriaProveedor == null)
            {
                return NotFound();
            }

            return View(categoriaProveedor);
        }

        // POST: CategoriaProveedor/Delete/5
        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaProveedor = await _context.CategoriaProveedor.FindAsync(id);
            if (categoriaProveedor != null)
            {
                _context.CategoriaProveedor.Remove(categoriaProveedor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaProveedorExists(int id)
        {
            return _context.CategoriaProveedor.Any(e => e.CategoriaProveedorID == id);
        }
    }
}
