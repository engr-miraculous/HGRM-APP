using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HGRM.ViewModels
{
    public class YwaviHomeViewModelcs
    {
        public IList<Models.ywavi.YwaviPdfMessages> ywaviPdf { get; set; }
        public IList<Models.ywavi.YwaviAudioMessages> ywaviAudio { get; set; }
    }
}
