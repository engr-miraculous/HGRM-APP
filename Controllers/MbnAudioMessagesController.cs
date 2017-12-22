using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HGRM.Models;
using HGRM.Models.MNB;
using Microsoft.AspNetCore.Authorization;

namespace HGRM.Controllers
{
    [Authorize]
    public class MbnAudioMessagesController : Controller
    {
        private readonly HGRMHomePageContext _context;

        public MbnAudioMessagesController(HGRMHomePageContext context)
        {
            _context = context;    
        }

        // GET: MbnAudioMessages/Home
        [AllowAnonymous]
        public async Task<IActionResult> Home()
        {
           
            return View(await _context.MbnAudioMessages.ToListAsync());
        }
        // GET: MbnAudioMessages
        public async Task<IActionResult> Index()
        {
            return View(await _context.MbnAudioMessages.ToListAsync());
        }

        // GET: MbnAudioMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mbnAudioMessages = await _context.MbnAudioMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (mbnAudioMessages == null)
            {
                return NotFound();
            }

            return View(mbnAudioMessages);
        }

        // GET: MbnAudioMessages/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: MbnAudioMessages/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> RenderAudio(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mbnAudioMessage = await _context.MbnAudioMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (mbnAudioMessage == null)
            {
                return NotFound();
            }

            return View(mbnAudioMessage);
        }

        // POST: MbnAudioMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,url,Minister")] MbnAudioMessages mbnAudioMessages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mbnAudioMessages);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mbnAudioMessages);
        }

        // GET: MbnAudioMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mbnAudioMessages = await _context.MbnAudioMessages.SingleOrDefaultAsync(m => m.ID == id);
            if (mbnAudioMessages == null)
            {
                return NotFound();
            }
            return View(mbnAudioMessages);
        }

        // POST: MbnAudioMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,url,Minister")] MbnAudioMessages mbnAudioMessages)
        {
            if (id != mbnAudioMessages.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mbnAudioMessages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MbnAudioMessagesExists(mbnAudioMessages.ID))
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
            return View(mbnAudioMessages);
        }

        // GET: MbnAudioMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mbnAudioMessages = await _context.MbnAudioMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (mbnAudioMessages == null)
            {
                return NotFound();
            }

            return View(mbnAudioMessages);
        }

        // POST: MbnAudioMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mbnAudioMessages = await _context.MbnAudioMessages.SingleOrDefaultAsync(m => m.ID == id);
            _context.MbnAudioMessages.Remove(mbnAudioMessages);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MbnAudioMessagesExists(int id)
        {
            return _context.MbnAudioMessages.Any(e => e.ID == id);
        }
    }
}
