using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Common.PT
{
    public class TestDonePTModel
    {
        public int TestDonePT_ID { get; set; }
        public int PT_ID { get; set; }
        public string Ashworth { get; set; }
        public string Goniometer { get; set; }
        public string Muscle_Strength { get; set; }
    }
}