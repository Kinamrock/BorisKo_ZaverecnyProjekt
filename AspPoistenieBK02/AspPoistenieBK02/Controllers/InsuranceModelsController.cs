using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspPoistenieBK02.Data;
using AspPoistenieBK02.Models;

namespace AspPoistenieBK02.Controllers
{
    public class InsuranceModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InsuranceModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InsuranceModels
        public async Task<IActionResult> Index()
        {
                
              return View(await _context.InsuranceModel.ToListAsync());
        }

        // GET: InsuranceModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InsuranceModel == null)
            {
                return NotFound();
            }

            var insuranceModel = await _context.InsuranceModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuranceModel == null)
            {
                return NotFound();
            }

            return View(insuranceModel);
        }

        // GET: InsuranceModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InsuranceModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,InsuranceType,Amount,Subject,ValidFrom,ValidTo")] InsuranceModel insuranceModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insuranceModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
#warning po pridani redirect na details actual user

            return View(insuranceModel);
        }

        // GET: InsuranceModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InsuranceModel == null)
            {
                return NotFound();
            }

            var insuranceModel = await _context.InsuranceModel.FindAsync(id);
            if (insuranceModel == null)
            {
                return NotFound();
            }
            return View(insuranceModel);
        }

        // POST: InsuranceModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,InsuranceType,Amount,Subject,ValidFrom,ValidTo")] InsuranceModel insuranceModel)
        {
            if (id != insuranceModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insuranceModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsuranceModelExists(insuranceModel.Id))
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
            return View(insuranceModel);
        }

        // GET: InsuranceModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InsuranceModel == null)
            {
                return NotFound();
            }

            var insuranceModel = await _context.InsuranceModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuranceModel == null)
            {
                return NotFound();
            }

            return View(insuranceModel);
        }

        // POST: InsuranceModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InsuranceModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.InsuranceModel'  is null.");
            }
            var insuranceModel = await _context.InsuranceModel.FindAsync(id);
            if (insuranceModel != null)
            {
                _context.InsuranceModel.Remove(insuranceModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsuranceModelExists(int id)
        {
          return _context.InsuranceModel.Any(e => e.Id == id);
        }
    }
}
