using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HGRM.Models.hgrmdata;

namespace HGRM.Models
{
    public class HgrmData
    {
        public int ID { get; set; }
        public string welcomeTitle { get; set; }
        public string welcomeBody { get; set; }
        public string January { get; set; }
        public string Febuary { get; set; }
        public string march { get; set; }
        public string april { get; set; }
        public string may { get; set; }
        public string june { get; set; }
        public string july { get; set; }
        public string august { get; set; }
        public string september { get; set; }
        public string october { get; set; }
        public string november { get; set; }
        public string december { get; set; }
        public IList<hgrmAudioMessage> hgrmAudioMessages { get; set; }
        public IList<hgrmWrittenMessage> hgrmWrittenMessages { get; set; }
    }
}
