using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace HGRM.Models
{
    public class HgrmDatasController : Controller
    {
        private readonly HGRMHomePageContext _context;

        public HgrmDatasController(HGRMHomePageContext context)
        {
            
            _context = context;    
        }

        // GET: HgrmDatas
        public async Task<IActionResult> Index()
        {
            
            var hgrm = await _context.HgrmData.Include(w => w.hgrmAudioMessages).Include(a => a.hgrmWrittenMessages).ToListAsync();
            return View(hgrm);
        }

        // GET: HgrmDatas/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var hgrmData = await _context.HgrmData
        //        .SingleOrDefaultAsync(m => m.ID == id);
        //    if (hgrmData == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(hgrmData);
        //}

        ////GET: HgrmDatas/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        ////POST: HgrmDatas/Create
        ////To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,welcomeTitle,welcomeBody,January,Febuary,march,april,may,june,july,august,september,october,november,december")] HgrmData hgrmData)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(hgrmData);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(hgrmData);
        //}

        // GET: HgrmDatas/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hgrmData = await _context.HgrmData.SingleOrDefaultAsync(m => m.ID == id);
            if (hgrmData == null)
            {
                return NotFound();
            }
            return View(hgrmData);
        }

        // POST: HgrmDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,welcomeTitle,welcomeBody,January,Febuary,march,april,may,june,july,august,september,october,november,december")] HgrmData hgrmData)
        {
            if (id != hgrmData.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hgrmData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HgrmDataExists(hgrmData.ID))
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
            return View(hgrmData);
        }

        // GET: HgrmDatas/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var hgrmData = await _context.HgrmData
        //            .SingleOrDefaultAsync(m => m.ID == id);
        //        if (hgrmData == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(hgrmData);
        //    }

        //    // POST: HgrmDatas/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var hgrmData = await _context.HgrmData.SingleOrDefaultAsync(m => m.ID == id);
        //        _context.HgrmData.Remove(hgrmData);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        private bool HgrmDataExists(int id)
        {
            return _context.HgrmData.Any(e => e.ID == id);
        }
    }
}
