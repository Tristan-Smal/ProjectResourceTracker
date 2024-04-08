using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ResourceTracker.Data;
using ResourceTracker.Models;

namespace ResourceTracker.Controllers
{
    public class ResourcesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResourcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Resources
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Resource.Include(r => r.Project);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Resources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Resource == null)
            {
                return NotFound();
            }

            var resource = await _context.Resource
                .Include(r => r.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // GET: Resources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Resource == null)
            {
                return NotFound();
            }

            var resource = await _context.Resource.FindAsync(id);
            if (resource == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Id", resource.ProjectId);
            return View(resource);
        }

        // POST: Resources/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResourceTitle,ResourceLink,ProjectId")] Resource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResourceExists(resource.Id))
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
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "Id", resource.ProjectId);
            return View(resource);
        }

        // GET: Resources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Resource == null)
            {
                return NotFound();
            }

            var resource = await _context.Resource
                .Include(r => r.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: Resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Resource == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Resource'  is null.");
            }
            var resource = await _context.Resource.FindAsync(id);
            if (resource != null)
            {
                _context.Resource.Remove(resource);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //------------------------------- New Stuff ----------------------------------//

        // GET: Resources/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return _context.Resource != null ?
                        View() :
                        Problem("Entity set 'ApplicationDbContext.Resource'  is null.");
        }
        // POST: Resources/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return _context.Resource != null ?
                        View("Index", await _context.Resource.Where(j => j.ResourceTitle.Contains(SearchPhrase)).ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Resource'  is null.");
        }


        // POST: Resources/ProjectResources
        public async Task<IActionResult> ProjectResources(int id)
        {
            return _context.Resource != null ?
                        View("Index", await _context.Resource.Where(j => j.ProjectId.Equals(id)).ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Resource'  is null.");
        }

        // GET: Resources/AddResource
        public async Task<IActionResult> AddResource()
        {
            return View();
        }
        // POST: Resources/AddResource
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddResource(int id, [Bind("ResourceTitle,ResourceLink,ProjectId")] Resource resource)
        {
            if (ModelState.IsValid)
            {
                resource.ProjectId = id;
                _context.Add(resource);
                await _context.SaveChangesAsync();
                return View("Index", await _context.Resource.Where(j => j.ProjectId.Equals(id)).ToListAsync());
            }
            return View(resource);
        }

        private bool ResourceExists(int id)
        {
            return (_context.Resource?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
