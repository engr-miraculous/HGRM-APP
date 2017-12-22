using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HGRM.Models;
using Microsoft.EntityFrameworkCore;

namespace HGRM.Controllers
{
    public class MBNController : Controller
    {
        private readonly HGRMHomePageContext _context;

        public MBNController(HGRMHomePageContext context)
        {
            _context = context;
        }

        // GET: MBN
        public async Task<IActionResult> Index()
        {
            var mbnHomeModel = new ViewModels.MbnHomeViewModelcs
            {
                MbnAudio = await _context.MbnAudioMessages.ToListAsync(),
                MbnPdf = await _context.MbnPdfMessages.ToListAsync()

            };

            return View(mbnHomeModel);
        }

    }
}