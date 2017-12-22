using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HGRM.ViewModels
{
    public class MbnHomeViewModelcs
    {
        public IList<Models.MNB.MbnPdfMessages> MbnPdf { get; set; }
        public IList<Models.MNB.MbnAudioMessages> MbnAudio { get; set; }
    }
}
