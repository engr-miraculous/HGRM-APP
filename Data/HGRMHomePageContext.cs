using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HGRM.Data;
using HGRM.Models;
using HGRM.Models.hgrmdata;
using HGRM.Models.MNB;
using HGRM.Models.ywavi;
using HGRM.Models.tts;
using HGRM.Models.OBADIAH;

namespace HGRM.Models
{
    public class HGRMHomePageContext : DbContext
    {
        public HGRMHomePageContext (DbContextOptions<HGRMHomePageContext> options)
            : base(options)
        {
        }

        
        public DbSet<HGRM.Models.HgrmData> HgrmData { get; set; }

        
        public DbSet<HGRM.Models.hgrmdata.hgrmAudioMessage> hgrmAudioMessage { get; set; }

        
        public DbSet<HGRM.Models.hgrmdata.hgrmWrittenMessage> hgrmWrittenMessage { get; set; }

        
        public DbSet<HGRM.Models.MNB.MbnPdfMessages> MbnPdfMessages { get; set; }

        
        public DbSet<HGRM.Models.MNB.MbnAudioMessages> MbnAudioMessages { get; set; }

        
        public DbSet<HGRM.Models.ywavi.YwaviAudioMessages> YwaviAudioMessages { get; set; }

        
        public DbSet<HGRM.Models.ywavi.YwaviPdfMessages> YwaviPdfMessages { get; set; }

        
        public DbSet<HGRM.Models.tts.TtsAudioMessages> TtsAudioMessages { get; set; }

        
        public DbSet<HGRM.Models.tts.TtsPdfMessages> TtsPdfMessages { get; set; }

        
        public DbSet<HGRM.Models.OBADIAH.ObadiahAudioMessages> ObadiahAudioMessages { get; set; }

        
        public DbSet<HGRM.Models.OBADIAH.ObadiahPdfMessages> ObadiahPdfMessages { get; set; }
    }
}
