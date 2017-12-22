using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HGRM.ViewModels
{
    public class ObadiahHomeViewModelcs
    {
        public IList<Models.OBADIAH.ObadiahPdfMessages> ObadiahPdf { get; set; }
        public IList<Models.OBADIAH.ObadiahAudioMessages> ObadiahAudio { get; set; }
    }
}
