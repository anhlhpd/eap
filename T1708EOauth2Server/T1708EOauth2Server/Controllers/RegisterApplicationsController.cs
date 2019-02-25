using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using T1708EOauth2Server.Models;
using T1708EOauth2Server.Data;

namespace T1708EOauth2Server.Controllers
{
    public class RegisterApplicationsController : Controller
    {
        private readonly T1708EOauth2ServerContext _context;

        public RegisterApplicationsController(T1708EOauth2ServerContext context)
        {
            _context = context;
        }

        // GET: RegisterApplications
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegisterApplication.ToListAsync());
        }

        // GET: RegisterApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerApplication = await _context.RegisterApplication
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registerApplication == null)
            {
                return NotFound();
            }

            return View(registerApplication);
        }

        // GET: RegisterApplications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegisterApplications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Logo,RedirectUrl,Description")] RegisterApplication registerApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registerApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registerApplication);
        }

        // GET: RegisterApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerApplication = await _context.RegisterApplication.FindAsync(id);
            if (registerApplication == null)
            {
                return NotFound();
            }
            return View(registerApplication);
        }

        // POST: RegisterApplications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Logo,RedirectUrl,Description,CreatedAt,UpdatedAt,DeletedAt,Status")] RegisterApplication registerApplication)
        {
            if (id != registerApplication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registerApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterApplicationExists(registerApplication.Id))
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
            return View(registerApplication);
        }

        // GET: RegisterApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerApplication = await _context.RegisterApplication
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registerApplication == null)
            {
                return NotFound();
            }

            return View(registerApplication);
        }

        // POST: RegisterApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registerApplication = await _context.RegisterApplication.FindAsync(id);
            _context.RegisterApplication.Remove(registerApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterApplicationExists(int id)
        {
            return _context.RegisterApplication.Any(e => e.Id == id);
        }
    }
}
