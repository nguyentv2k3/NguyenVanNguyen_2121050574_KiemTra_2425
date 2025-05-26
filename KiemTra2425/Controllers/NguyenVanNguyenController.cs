using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KiemTra2425.Data;
using KiemTra2425.Models;

namespace KiemTra2425.Controllers
{
    public class NguyenVanNguyenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NguyenVanNguyenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NguyenVanNguyen
        public async Task<IActionResult> Index()
        {
            return View(await _context.NguyenVanNguyen.ToListAsync());
        }

        // GET: NguyenVanNguyen/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenVanNguyen = await _context.NguyenVanNguyen
                .FirstOrDefaultAsync(m => m.FullName == id);
            if (nguyenVanNguyen == null)
            {
                return NotFound();
            }

            return View(nguyenVanNguyen);
        }

        // GET: NguyenVanNguyen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NguyenVanNguyen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,Address,Age")] NguyenVanNguyen nguyenVanNguyen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguyenVanNguyen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nguyenVanNguyen);
        }

        // GET: NguyenVanNguyen/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenVanNguyen = await _context.NguyenVanNguyen.FindAsync(id);
            if (nguyenVanNguyen == null)
            {
                return NotFound();
            }
            return View(nguyenVanNguyen);
        }

        // POST: NguyenVanNguyen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FullName,Address,Age")] NguyenVanNguyen nguyenVanNguyen)
        {
            if (id != nguyenVanNguyen.FullName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguyenVanNguyen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguyenVanNguyenExists(nguyenVanNguyen.FullName))
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
            return View(nguyenVanNguyen);
        }

        // GET: NguyenVanNguyen/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenVanNguyen = await _context.NguyenVanNguyen
                .FirstOrDefaultAsync(m => m.FullName == id);
            if (nguyenVanNguyen == null)
            {
                return NotFound();
            }

            return View(nguyenVanNguyen);
        }

        // POST: NguyenVanNguyen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nguyenVanNguyen = await _context.NguyenVanNguyen.FindAsync(id);
            if (nguyenVanNguyen != null)
            {
                _context.NguyenVanNguyen.Remove(nguyenVanNguyen);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NguyenVanNguyenExists(string id)
        {
            return _context.NguyenVanNguyen.Any(e => e.FullName == id);
        }
    }
}
