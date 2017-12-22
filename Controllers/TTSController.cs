using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HGRM.Models;
using Microsoft.EntityFrameworkCore;

namespace HGRM.Controllers
{
    public class TTSController : Controller
    {
        private readonly HGRMHomePageContext _context;

        public TTSController(HGRMHomePageContext context)
        {
            _context = context;
        }

        // GET: TTS
        public async Task<IActionResult> Index()
        {
            var ttsHomeModel = new ViewModels.TtsHomeViewModelcs
            {
                TtsAudio = await _context.TtsAudioMessages.ToListAsync(),
                TtsPdf = await _context.TtsPdfMessages.ToListAsync()

            };

            return View(ttsHomeModel);
        }

    }
}