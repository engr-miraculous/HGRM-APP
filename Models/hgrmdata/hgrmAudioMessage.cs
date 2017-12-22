using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HGRM.Models.hgrmdata
{
    public class hgrmAudioMessage
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string url { get; set; }
        public string Minister { get; set; }
        public int HgrmDataID { get; set; }
        public HgrmData hgrmData { get; set; }
    }
}
