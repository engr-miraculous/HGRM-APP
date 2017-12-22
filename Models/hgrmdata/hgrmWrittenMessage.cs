using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HGRM.Models.hgrmdata
{
    public class hgrmWrittenMessage
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Sermon { get; set; }
        public string url { get; set; }
        public int HgrmDataID { get; set; }
        public HgrmData hgrmData { get; set; }

    }
}
