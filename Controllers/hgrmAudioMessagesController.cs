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
    public class hgrmAudioMessagesController : Controller
    {
        private readonly HGRMHomePageContext _context;

        public hgrmAudioMessagesController(HGRMHomePageContext context)
        {
            _context = context;    
        }
        // GET: hgrmAudioMessages/Home
        [AllowAnonymous]
        public async Task<IActionResult> Home()
        {
            var hGRMHomePageContext = await _context.hgrmAudioMessage.ToListAsync();
            return View(hGRMHomePageContext);
        }

        // GET: hgrmAudioMessages
        public async Task<IActionResult> Index()
        {
            var hGRMHomePageContext = _context.hgrmAudioMessage.Include(h => h.hgrmData);
            return View(await hGRMHomePageContext.ToListAsync());
        }

        // GET: hgrmAudioMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hgrmAudioMessage = await _context.hgrmAudioMessage
                .Include(h => h.hgrmData)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (hgrmAudioMessage == null)
            {
                return NotFound();
            }

            return View(hgrmAudioMessage);
        }

        // GET: hgrmAudioMessages/Create
        public IActionResult Create()
        {
            ViewData["HgrmDataID"] = new SelectList(_context.HgrmData, "ID", "ID");
            return View();
        }
        // GET: hgrmAudioMessages/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> RenderAudio(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var HgrmAudioMessage = await _context.hgrmAudioMessage
                .Include(h => h.hgrmData)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (HgrmAudioMessage == null)
            {
                return NotFound();
            }

            return View(HgrmAudioMessage);
        }

        // POST: hgrmAudioMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,url,Minister,HgrmDataID")] hgrmAudioMessage hgrmAudioMessage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hgrmAudioMessage);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["HgrmDataID"] = new SelectList(_context.HgrmData, "ID", "ID", hgrmAudioMessage.HgrmDataID);
            return View(hgrmAudioMessage);
        }

        // GET: hgrmAudioMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hgrmAudioMessage = await _context.hgrmAudioMessage.SingleOrDefaultAsync(m => m.ID == id);
            if (hgrmAudioMessage == null)
            {
                return NotFound();
            }
            ViewData["HgrmDataID"] = new SelectList(_context.HgrmData, "ID", "ID", hgrmAudioMessage.HgrmDataID);
            return View(hgrmAudioMessage);
        }

        // POST: hgrmAudioMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,url,Minister,HgrmDataID")] hgrmAudioMessage hgrmAudioMessage)
        {
            if (id != hgrmAudioMessage.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hgrmAudioMessage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!hgrmAudioMessageExists(hgrmAudioMessage.ID))
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
            ViewData["HgrmDataID"] = new SelectList(_context.HgrmData, "ID", "ID", hgrmAudioMessage.HgrmDataID);
            return View(hgrmAudioMessage);
        }

        // GET: hgrmAudioMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hgrmAudioMessage = await _context.hgrmAudioMessage
                .Include(h => h.hgrmData)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (hgrmAudioMessage == null)
            {
                return NotFound();
            }

            return View(hgrmAudioMessage);
        }

        // POST: hgrmAudioMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hgrmAudioMessage = await _context.hgrmAudioMessage.SingleOrDefaultAsync(m => m.ID == id);
            _context.hgrmAudioMessage.Remove(hgrmAudioMessage);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool hgrmAudioMessageExists(int id)
        {
            return _context.hgrmAudioMessage.Any(e => e.ID == id);
        }
    }
}
