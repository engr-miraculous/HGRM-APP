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
    public class YwaviPdfMessagesController : Controller
    {
        private readonly HGRMHomePageContext _context;

        public YwaviPdfMessagesController(HGRMHomePageContext context)
        {
            _context = context;    
        }

        // GET: YwaviPdfMessages/Home
        [AllowAnonymous]
        public async Task<IActionResult> Home()
        {

            return View(await _context.YwaviPdfMessages.ToListAsync());
        }

        // GET: YwaviPdfMessages
        public async Task<IActionResult> Index()
        {
            return View(await _context.YwaviPdfMessages.ToListAsync());
        }

        // GET: YwaviPdfMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ywaviPdfMessages = await _context.YwaviPdfMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (ywaviPdfMessages == null)
            {
                return NotFound();
            }

            return View(ywaviPdfMessages);
        }

        // GET: YwaviPdfMessages/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Renderbook(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ywaviWrittenMessage = await _context.YwaviPdfMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (ywaviWrittenMessage == null)
            {
                return NotFound();
            }

            return View(ywaviWrittenMessage);
        }


        // GET: YwaviPdfMessages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YwaviPdfMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,url")] YwaviPdfMessages ywaviPdfMessages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ywaviPdfMessages);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ywaviPdfMessages);
        }

        // GET: YwaviPdfMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ywaviPdfMessages = await _context.YwaviPdfMessages.SingleOrDefaultAsync(m => m.ID == id);
            if (ywaviPdfMessages == null)
            {
                return NotFound();
            }
            return View(ywaviPdfMessages);
        }

        // POST: YwaviPdfMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,url")] YwaviPdfMessages ywaviPdfMessages)
        {
            if (id != ywaviPdfMessages.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ywaviPdfMessages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YwaviPdfMessagesExists(ywaviPdfMessages.ID))
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
            return View(ywaviPdfMessages);
        }

        // GET: YwaviPdfMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ywaviPdfMessages = await _context.YwaviPdfMessages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (ywaviPdfMessages == null)
            {
                return NotFound();
            }

            return View(ywaviPdfMessages);
        }

        // POST: YwaviPdfMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ywaviPdfMessages = await _context.YwaviPdfMessages.SingleOrDefaultAsync(m => m.ID == id);
            _context.YwaviPdfMessages.Remove(ywaviPdfMessages);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool YwaviPdfMessagesExists(int id)
        {
            return _context.YwaviPdfMessages.Any(e => e.ID == id);
        }
    }
}
