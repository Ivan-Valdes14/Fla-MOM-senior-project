using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FLAMOM_SeniorProject.Data;
using FLAMOM_SeniorProject.ViewModel;

namespace FLAMOM_SeniorProject.Controllers
{
    public class VisitInformationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VisitInformationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VisitInformations
        public async Task<IActionResult> Index()
        {
              return View(await _context.VisitInformations.ToListAsync());
        }

        // GET: VisitInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VisitInformations == null)
            {
                return NotFound();
            }

            var visitInformation = await _context.VisitInformations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitInformation == null)
            {
                return NotFound();
            }

            return View(visitInformation);
        }

        // GET: VisitInformations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VisitInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VisitInformationVM visitInformation)
        {
            if (ModelState.IsValid)
            {
                //this is what gets generated to be saved to database, we need to remove these in all future forms
                //except the final page where we will submit all of the data together
                //_context.Add(visitInformationVm);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visitInformation);
        }

        // GET: VisitInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VisitInformations == null)
            {
                return NotFound();
            }

            var visitInformation = await _context.VisitInformations.FindAsync(id);
            if (visitInformation == null)
            {
                return NotFound();
            }
            return View(visitInformation);
        }

        // POST: VisitInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MouthPain,LengthOfPain,OverallHealth,TimeToTravel,AttendBefore")] VisitInformation visitInformation)
        {
            if (id != visitInformation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitInformationExists(visitInformation.Id))
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
            return View(visitInformation);
        }

        // GET: VisitInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VisitInformations == null)
            {
                return NotFound();
            }

            var visitInformation = await _context.VisitInformations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitInformation == null)
            {
                return NotFound();
            }

            return View(visitInformation);
        }

        // POST: VisitInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VisitInformations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.VisitInformations'  is null.");
            }
            var visitInformation = await _context.VisitInformations.FindAsync(id);
            if (visitInformation != null)
            {
                _context.VisitInformations.Remove(visitInformation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitInformationExists(int id)
        {
          return _context.VisitInformations.Any(e => e.Id == id);
        }
    }
}
