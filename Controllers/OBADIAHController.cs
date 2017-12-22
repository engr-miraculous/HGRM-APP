using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HGRM.Models;
using Microsoft.EntityFrameworkCore;

namespace HGRM.Controllers
{
    public class OBADIAHController : Controller
    {
        private readonly HGRMHomePageContext _context;

        public OBADIAHController(HGRMHomePageContext context)
        {
            _context = context;
        }

        // GET: OBADIAH
        public async Task<IActionResult> Index()
        {
            var obadiahHomeModel = new ViewModels.ObadiahHomeViewModelcs
            {
                ObadiahAudio = await _context.ObadiahAudioMessages.ToListAsync(),
                ObadiahPdf = await _context.ObadiahPdfMessages.ToListAsync()

            };

            return View(obadiahHomeModel);
        }
    }
}