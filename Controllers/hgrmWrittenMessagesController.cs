using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HGRM.Models;
using HGRM.Models.hgrmdata;
using Microsoft.AspNetCore.Authorization;

namespace HGRM.Controllers
{
    [Authorize]
    public class hgrmWrittenMessagesController : Controller
    {
        private readonly HGRMHomePageContext _context;

        public hgrmWrittenMessagesController(HGRMHomePageContext context)
        {
            _context = context;    
        }
        // GET: hgrmWrittenMessages/Home
        [AllowAnonymous]
        public async Task<IActionResult> Home()
        {
            var hGRMHomePageContext =await _context.hgrmWrittenMessage.ToListAsync();
            return View(hGRMHomePageContext);
        }
        // GET: hgrmWrittenMessages
        public async Task<IActionResult> Index()
        {
            var hGRMHomePageContext = _context.hgrmWrittenMessage.Include(h => h.hgrmData);
            return View(await hGRMHomePageContext.ToListAsync());
        }

        // GET: hgrmWrittenMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hgrmWrittenMessage = await _context.hgrmWrittenMessage
                .Include(h => h.hgrmData)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (hgrmWrittenMessage == null)
            {
                return NotFound();
            }

            return View(hgrmWrittenMessage);
        }

        // GET: hgrmWrittenMessages/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Renderbook(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hgrmWrittenMessage = await _context.hgrmWrittenMessage
                .Include(h => h.hgrmData)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (hgrmWrittenMessage == null)
            {
                return NotFound();
            }

            return View(hgrmWrittenMessage);
        }
        // GET: hgrmWrittenMessages/Create
        public IActionResult Create()
        {
            ViewData["HgrmDataID"] = new SelectList(_context.HgrmData, "ID", "ID");
            return View();
        }

        // POST: hgrmWrittenMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Sermon,url,HgrmDataID")] hgrmWrittenMessage hgrmWrittenMessage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hgrmWrittenMessage);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["HgrmDataID"] = new SelectList(_context.HgrmData, "ID", "ID", hgrmWrittenMessage.HgrmDataID);
            return View(hgrmWrittenMessage);
        }

        // GET: hgrmWrittenMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hgrmWrittenMessage = await _context.hgrmWrittenMessage.SingleOrDefaultAsync(m => m.ID == id);
            if (hgrmWrittenMessage == null)
            {
                return NotFound();
            }
            ViewData["HgrmDataID"] = new SelectList(_context.HgrmData, "ID", "ID", hgrmWrittenMessage.HgrmDataID);
            return View(hgrmWrittenMessage);
        }

        // POST: hgrmWrittenMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Sermon,url,HgrmDataID")] hgrmWrittenMessage hgrmWrittenMessage)
        {
            if (id != hgrmWrittenMessage.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hgrmWrittenMessage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!hgrmWrittenMessageExists(hgrmWrittenMessage.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["HgrmDataID"] = new SelectList(_context.HgrmData, "ID", "ID", hgrmWrittenMessage.HgrmDataID);
            return View(hgrmWrittenMessage);
        }

        // GET: hgrmWrittenMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hgrmWrittenMessage = await _context.hgrmWrittenMessage
                .Include(h => h.hgrmData)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (hgrmWrittenMessage == null)
            {
                return NotFound();
            }

            return View(hgrmWrittenMessage);
        }

        // POST: hgrmWrittenMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hgrmWrittenMessage = await _context.hgrmWrittenMessage.SingleOrDefaultAsync(m => m.ID == id);
            _context.hgrmWrittenMessage.Remove(hgrmWrittenMessage);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool hgrmWrittenMessageExists(int id)
        {
            return _context.hgrmWrittenMessage.Any(e => e.ID == id);
        }
    }
}
