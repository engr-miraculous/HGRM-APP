using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HGRM.ViewModels
{
    public class TtsHomeViewModelcs
    {
        public IList<Models.tts.TtsPdfMessages> TtsPdf { get; set; }
        public IList<Models.tts.TtsAudioMessages> TtsAudio { get; set; }
    }
}
