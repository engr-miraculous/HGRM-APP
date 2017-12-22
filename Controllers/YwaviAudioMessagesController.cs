using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HGRM.Models;
using HGRM.Models.ywavi;
using Microsoft.AspNetCore.Authorization;

namespace HGRM.Controllers
{
    [Authorize]
    public class YwaviAudioMessagesController : Controller
    {
        private readonly HGRMHomePageContext _context;

        public YwaviAudioMessagesController(HGRMHomePageContext context)
        {
            _context = context;    
        }

        // GET: YwaviAudioMessages/Home
        [AllowAnonymous]
        public async Task<IActionResult> Home()
        {

            return View(await _context.YwaviAudioMessages.ToListAsync());
        }
        // GET: YwaviAudioMessages
        public async Task<IActionResult> Index()
        {
            return View(await _context.YwaviAudioMessages.ToListAsync());
        }

        // GET: YwaviAudioMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ywaviAudioMessages = await _context.YwaviAudioMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (ywaviAudioMessages == null)
            {
                return NotFound();
            }

            return View(ywaviAudioMessages);
        }

        // GET: YwaviAudioMessages/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: YwaviAudioMessages/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> RenderAudio(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ywaviAudioMessage = await _context.YwaviAudioMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (ywaviAudioMessage == null)
            {
                return NotFound();
            }

            return View(ywaviAudioMessage);
        }

        // POST: YwaviAudioMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,url,Minister")] YwaviAudioMessages ywaviAudioMessages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ywaviAudioMessages);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ywaviAudioMessages);
        }

        // GET: YwaviAudioMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ywaviAudioMessages = await _context.YwaviAudioMessages.SingleOrDefaultAsync(m => m.ID == id);
            if (ywaviAudioMessages == null)
            {
                return NotFound();
            }
            return View(ywaviAudioMessages);
        }

        // POST: YwaviAudioMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,url,Minister")] YwaviAudioMessages ywaviAudioMessages)
        {
            if (id != ywaviAudioMessages.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ywaviAudioMessages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YwaviAudioMessagesExists(ywaviAudioMessages.ID))
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
            return View(ywaviAudioMessages);
        }

        // GET: YwaviAudioMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ywaviAudioMessages = await _context.YwaviAudioMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (ywaviAudioMessages == null)
            {
                return NotFound();
            }

            return View(ywaviAudioMessages);
        }

        // POST: YwaviAudioMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ywaviAudioMessages = await _context.YwaviAudioMessages.SingleOrDefaultAsync(m => m.ID == id);
            _context.YwaviAudioMessages.Remove(ywaviAudioMessages);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool YwaviAudioMessagesExists(int id)
        {
            return _context.YwaviAudioMessages.Any(e => e.ID == id);
        }
    }
}
