using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HGRM.Models;
using HGRM.Models.tts;
using Microsoft.AspNetCore.Authorization;

namespace HGRM.Controllers
{
    [Authorize]
    public class TtsAudioMessagesController : Controller
    {
        private readonly HGRMHomePageContext _context;

        public TtsAudioMessagesController(HGRMHomePageContext context)
        {
            _context = context;    
        }

        // GET: MbnAudioMessages/Home
        [AllowAnonymous]
        public async Task<IActionResult> Home()
        {

            return View(await _context.TtsAudioMessages.ToListAsync());
        }

        // GET: TtsAudioMessages
        public async Task<IActionResult> Index()
        {
            return View(await _context.TtsAudioMessages.ToListAsync());
        }

        // GET: TtsAudioMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ttsAudioMessages = await _context.TtsAudioMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (ttsAudioMessages == null)
            {
                return NotFound();
            }

            return View(ttsAudioMessages);
        }

        // GET: TtsAudioMessages/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: TtsAudioMessages/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> RenderAudio(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ttsAudioMessage = await _context.TtsAudioMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (ttsAudioMessage == null)
            {
                return NotFound();
            }

            return View(ttsAudioMessage);
        }

        // POST: TtsAudioMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,url,Minister")] TtsAudioMessages ttsAudioMessages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ttsAudioMessages);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ttsAudioMessages);
        }

        // GET: TtsAudioMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ttsAudioMessages = await _context.TtsAudioMessages.SingleOrDefaultAsync(m => m.ID == id);
            if (ttsAudioMessages == null)
            {
                return NotFound();
            }
            return View(ttsAudioMessages);
        }

        // POST: TtsAudioMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,url,Minister")] TtsAudioMessages ttsAudioMessages)
        {
            if (id != ttsAudioMessages.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ttsAudioMessages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TtsAudioMessagesExists(ttsAudioMessages.ID))
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
            return View(ttsAudioMessages);
        }

        // GET: TtsAudioMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ttsAudioMessages = await _context.TtsAudioMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (ttsAudioMessages == null)
            {
                return NotFound();
            }

            return View(ttsAudioMessages);
        }

        // POST: TtsAudioMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ttsAudioMessages = await _context.TtsAudioMessages.SingleOrDefaultAsync(m => m.ID == id);
            _context.TtsAudioMessages.Remove(ttsAudioMessages);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TtsAudioMessagesExists(int id)
        {
            return _context.TtsAudioMessages.Any(e => e.ID == id);
        }
    }
}
