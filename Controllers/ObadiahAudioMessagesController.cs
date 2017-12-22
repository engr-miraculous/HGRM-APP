using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HGRM.Models;
using HGRM.Models.OBADIAH;
using Microsoft.AspNetCore.Authorization;

namespace HGRM.Controllers
{
    [Authorize]
    public class ObadiahAudioMessagesController : Controller
    {
        private readonly HGRMHomePageContext _context;

        public ObadiahAudioMessagesController(HGRMHomePageContext context)
        {
            _context = context;    
        }

        // GET: ObadiahAudioMessages/Home
        [AllowAnonymous]
        public async Task<IActionResult> Home()
        {

            return View(await _context.ObadiahAudioMessages.ToListAsync());
        }

        // GET: ObadiahAudioMessages
        public async Task<IActionResult> Index()
        {
            return View(await _context.ObadiahAudioMessages.ToListAsync());
        }

        // GET: ObadiahAudioMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obadiahAudioMessages = await _context.ObadiahAudioMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (obadiahAudioMessages == null)
            {
                return NotFound();
            }

            return View(obadiahAudioMessages);
        }

        // GET: ObadiahAudioMessages/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: ObadiahAudioMessages/RenderAudio/5
        [AllowAnonymous]
        public async Task<IActionResult> RenderAudio(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mbnAudioMessage = await _context.ObadiahAudioMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (mbnAudioMessage == null)
            {
                return NotFound();
            }

            return View(mbnAudioMessage);
        }

        // POST: ObadiahAudioMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,url,Minister")] ObadiahAudioMessages obadiahAudioMessages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obadiahAudioMessages);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(obadiahAudioMessages);
        }

        // GET: ObadiahAudioMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obadiahAudioMessages = await _context.ObadiahAudioMessages.SingleOrDefaultAsync(m => m.ID == id);
            if (obadiahAudioMessages == null)
            {
                return NotFound();
            }
            return View(obadiahAudioMessages);
        }

        // POST: ObadiahAudioMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,url,Minister")] ObadiahAudioMessages obadiahAudioMessages)
        {
            if (id != obadiahAudioMessages.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obadiahAudioMessages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObadiahAudioMessagesExists(obadiahAudioMessages.ID))
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
            return View(obadiahAudioMessages);
        }

        // GET: ObadiahAudioMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obadiahAudioMessages = await _context.ObadiahAudioMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (obadiahAudioMessages == null)
            {
                return NotFound();
            }

            return View(obadiahAudioMessages);
        }

        // POST: ObadiahAudioMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obadiahAudioMessages = await _context.ObadiahAudioMessages.SingleOrDefaultAsync(m => m.ID == id);
            _context.ObadiahAudioMessages.Remove(obadiahAudioMessages);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ObadiahAudioMessagesExists(int id)
        {
            return _context.ObadiahAudioMessages.Any(e => e.ID == id);
        }
    }
}
