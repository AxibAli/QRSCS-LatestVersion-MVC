using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Common.PT
{
    public class MilestonePTModel
    {
        public int MilestonePT_ID { get; set; }
        public int PT_ID { get; set; }
        public string Cry { get; set; }
        public string Neck_Control { get; set; }
        public string Sitting { get; set; }
        public string Crawling { get; set; }
        public string Standing { get; set; }
        public string Walking { get; set; }
        public string Spoke_First_Word { get; set; }
        public string Bowl_Bladder { get; set; }
        public string Tactile { get; set; }
        public string Auditory { get; set; }
        public string Visual { get; set; }
        public string Taste_Smell { get; set; }
    }
}