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
    public class TtsPdfMessagesController : Controller
    {
        private readonly HGRMHomePageContext _context;

        public TtsPdfMessagesController(HGRMHomePageContext context)
        {
            _context = context;    
        }

        // GET: TtsPdfMessages/Home
        [AllowAnonymous]
        public async Task<IActionResult> Home()
        {

            return View(await _context.TtsPdfMessages.ToListAsync());
        }

        // GET: TtsPdfMessages
        public async Task<IActionResult> Index()
        {
            return View(await _context.TtsPdfMessages.ToListAsync());
        }

        // GET: TtsPdfMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ttsPdfMessages = await _context.TtsPdfMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (ttsPdfMessages == null)
            {
                return NotFound();
            }

            return View(ttsPdfMessages);
        }

        // GET: TtsPdfMessages/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: TtsPdfMessages/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Renderbook(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ttsWrittenMessage = await _context.TtsPdfMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (ttsWrittenMessage == null)
            {
                return NotFound();
            }

            return View(ttsWrittenMessage);
        }

        // POST: TtsPdfMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,url")] TtsPdfMessages ttsPdfMessages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ttsPdfMessages);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ttsPdfMessages);
        }

        // GET: TtsPdfMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ttsPdfMessages = await _context.TtsPdfMessages.SingleOrDefaultAsync(m => m.ID == id);
            if (ttsPdfMessages == null)
            {
                return NotFound();
            }
            return View(ttsPdfMessages);
        }

        // POST: TtsPdfMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,url")] TtsPdfMessages ttsPdfMessages)
        {
            if (id != ttsPdfMessages.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ttsPdfMessages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TtsPdfMessagesExists(ttsPdfMessages.ID))
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
            return View(ttsPdfMessages);
        }

        // GET: TtsPdfMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ttsPdfMessages = await _context.TtsPdfMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (ttsPdfMessages == null)
            {
                return NotFound();
            }

            return View(ttsPdfMessages);
        }

        // POST: TtsPdfMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ttsPdfMessages = await _context.TtsPdfMessages.SingleOrDefaultAsync(m => m.ID == id);
            _context.TtsPdfMessages.Remove(ttsPdfMessages);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TtsPdfMessagesExists(int id)
        {
            return _context.TtsPdfMessages.Any(e => e.ID == id);
        }
    }
}
