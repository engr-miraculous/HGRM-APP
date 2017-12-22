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
    public class ObadiahPdfMessagesController : Controller
    {
        private readonly HGRMHomePageContext _context;

        public ObadiahPdfMessagesController(HGRMHomePageContext context)
        {
            _context = context;    
        }

        // GET: ObadiahPdfMessages/Home
        [AllowAnonymous]
        public async Task<IActionResult> Home()
        {

            return View(await _context.ObadiahPdfMessages.ToListAsync());
        }

        // GET: ObadiahPdfMessages
        public async Task<IActionResult> Index()
        {
            return View(await _context.ObadiahPdfMessages.ToListAsync());
        }

        // GET: ObadiahPdfMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obadiahPdfMessages = await _context.ObadiahPdfMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (obadiahPdfMessages == null)
            {
                return NotFound();
            }

            return View(obadiahPdfMessages);
        }

        // GET: ObadiahPdfMessages/Renderbook/5
        [AllowAnonymous]
        public async Task<IActionResult> Renderbook(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hgrmWrittenMessage = await _context.ObadiahPdfMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (hgrmWrittenMessage == null)
            {
                return NotFound();
            }

            return View(hgrmWrittenMessage);
        }

        // GET: ObadiahPdfMessages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ObadiahPdfMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,url")] ObadiahPdfMessages obadiahPdfMessages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obadiahPdfMessages);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(obadiahPdfMessages);
        }

        // GET: ObadiahPdfMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obadiahPdfMessages = await _context.ObadiahPdfMessages.SingleOrDefaultAsync(m => m.ID == id);
            if (obadiahPdfMessages == null)
            {
                return NotFound();
            }
            return View(obadiahPdfMessages);
        }

        // POST: ObadiahPdfMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,url")] ObadiahPdfMessages obadiahPdfMessages)
        {
            if (id != obadiahPdfMessages.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obadiahPdfMessages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObadiahPdfMessagesExists(obadiahPdfMessages.ID))
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
            return View(obadiahPdfMessages);
        }

        // GET: ObadiahPdfMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obadiahPdfMessages = await _context.ObadiahPdfMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (obadiahPdfMessages == null)
            {
                return NotFound();
            }

            return View(obadiahPdfMessages);
        }

        // POST: ObadiahPdfMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obadiahPdfMessages = await _context.ObadiahPdfMessages.SingleOrDefaultAsync(m => m.ID == id);
            _context.ObadiahPdfMessages.Remove(obadiahPdfMessages);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ObadiahPdfMessagesExists(int id)
        {
            return _context.ObadiahPdfMessages.Any(e => e.ID == id);
        }
    }
}
