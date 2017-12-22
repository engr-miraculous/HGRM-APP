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
    public class MbnPdfMessagesController : Controller
    {
        private readonly HGRMHomePageContext _context;

        public MbnPdfMessagesController(HGRMHomePageContext context)
        {
            _context = context;    
        }

        // GET: MbnPdfMessages/Home
        [AllowAnonymous]
        public async Task<IActionResult> Home()
        {
            
            return View(await _context.MbnPdfMessages.ToListAsync());
        }

        // GET: MbnPdfMessages
        public async Task<IActionResult> Index()
        {
            return View(await _context.MbnPdfMessages.ToListAsync());
        }

        // GET: MbnPdfMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mbnPdfMessages = await _context.MbnPdfMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (mbnPdfMessages == null)
            {
                return NotFound();
            }

            return View(mbnPdfMessages);
        }

        // GET: MbnPdfMessages/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Renderbook(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hgrmWrittenMessage = await _context.MbnPdfMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (hgrmWrittenMessage == null)
            {
                return NotFound();
            }

            return View(hgrmWrittenMessage);
        }

        // GET: MbnPdfMessages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MbnPdfMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,url")] MbnPdfMessages mbnPdfMessages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mbnPdfMessages);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mbnPdfMessages);
        }

        // GET: MbnPdfMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mbnPdfMessages = await _context.MbnPdfMessages.SingleOrDefaultAsync(m => m.ID == id);
            if (mbnPdfMessages == null)
            {
                return NotFound();
            }
            return View(mbnPdfMessages);
        }

        // POST: MbnPdfMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,url")] MbnPdfMessages mbnPdfMessages)
        {
            if (id != mbnPdfMessages.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mbnPdfMessages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MbnPdfMessagesExists(mbnPdfMessages.ID))
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
            return View(mbnPdfMessages);
        }

        // GET: MbnPdfMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mbnPdfMessages = await _context.MbnPdfMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (mbnPdfMessages == null)
            {
                return NotFound();
            }

            return View(mbnPdfMessages);
        }

        // POST: MbnPdfMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mbnPdfMessages = await _context.MbnPdfMessages.SingleOrDefaultAsync(m => m.ID == id);
            _context.MbnPdfMessages.Remove(mbnPdfMessages);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MbnPdfMessagesExists(int id)
        {
            return _context.MbnPdfMessages.Any(e => e.ID == id);
        }
    }
}
