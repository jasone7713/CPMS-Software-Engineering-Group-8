using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CPMS.Data;
using CPMS.Models;

namespace CPMS.Controllers
{
    public class DefaultsController : Controller
    {
        private readonly CPMSContext _context;

        public DefaultsController(CPMSContext context)
        {
            _context = context;
        }

        // GET: Defaults
        public async Task<IActionResult> Index()
        {

            //only allow admin access
            if(LoginManager.IsAdmin() != true)
            {
                return NotFound();
            }

              return _context.Defaults != null ? 
                          View(await _context.Defaults.ToListAsync()) :
                          Problem("Entity set 'CPMSContext.Defaults'  is null.");
        }

        // GET: Defaults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //only allow admin access
            if (LoginManager.IsAdmin() != true)
            {
                return NotFound();
            }

            if (id == null || _context.Defaults == null)
            {
                return NotFound();
            }

            var defaults = await _context.Defaults
                .FirstOrDefaultAsync(m => m.DefaultsID == id);
            if (defaults == null)
            {
                return NotFound();
            }

            return View(defaults);
        }

        // GET: Defaults/Create
        public IActionResult Create()
        {
            //only allow admin access
            if (LoginManager.IsAdmin() != true)
            {
                return NotFound();
            }

            return View();
        }

        // POST: Defaults/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DefaultsID,EnabledReviewers,EnabledAuthors")] Defaults defaults)
        {

            //only allow admin access
            if (LoginManager.IsAdmin() != true)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Add(defaults);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(defaults);
        }

        // GET: Defaults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Defaults == null)
            {
                return NotFound();
            }

            var defaults = await _context.Defaults.FindAsync(id);
            if (defaults == null)
            {
                return NotFound();
            }
            return View(defaults);
        }

        // POST: Defaults/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DefaultsID,EnabledReviewers,EnabledAuthors")] Defaults defaults)
        {
            //only allow admin access
            if (LoginManager.IsAdmin() != true)
            {
                return NotFound();
            }

            if (id != defaults.DefaultsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(defaults);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DefaultsExists(defaults.DefaultsID))
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
            return View(defaults);
        }

        // GET: Defaults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //only allow admin access
            if (LoginManager.IsAdmin() != true)
            {
                return NotFound();
            }

            if (id == null || _context.Defaults == null)
            {
                return NotFound();
            }

            var defaults = await _context.Defaults
                .FirstOrDefaultAsync(m => m.DefaultsID == id);
            if (defaults == null)
            {
                return NotFound();
            }

            return View(defaults);
        }

        // POST: Defaults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //only allow admin access
            if (LoginManager.IsAdmin() != true)
            {
                return NotFound();
            }

            if (_context.Defaults == null)
            {
                return Problem("Entity set 'CPMSContext.Defaults'  is null.");
            }
            var defaults = await _context.Defaults.FindAsync(id);
            if (defaults != null)
            {
                _context.Defaults.Remove(defaults);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DefaultsExists(int id)
        {
          return (_context.Defaults?.Any(e => e.DefaultsID == id)).GetValueOrDefault();
        }
    }
}
