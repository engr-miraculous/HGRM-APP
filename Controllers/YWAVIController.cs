using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HGRM.Models;
using Microsoft.EntityFrameworkCore;

namespace HGRM.Controllers
{
    public class YWAVIController : Controller
    {
        private readonly HGRMHomePageContext _context;

        public YWAVIController(HGRMHomePageContext context)
        {
            _context = context;
        }

        // GET: MBN
        public async Task<IActionResult> Index()
        {
            var ywaviHomeModel = new ViewModels.YwaviHomeViewModelcs
            {
                ywaviAudio = await _context.YwaviAudioMessages.ToListAsync(),
                ywaviPdf = await _context.YwaviPdfMessages.ToListAsync()

            };

            return View(ywaviHomeModel);
        }

    }
}