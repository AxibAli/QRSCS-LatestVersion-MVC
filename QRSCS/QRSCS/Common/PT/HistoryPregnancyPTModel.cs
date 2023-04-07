using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Common.PT
{
    public class HistoryPregnancyPTModel
    {
        public int HistoryPregnancyPT_ID { get; set; }
        public int PT_ID { get; set; }
        public string Pregnancy_Length { get; set; }
        public string Pregnancy_Type { get; set; }
        public string Birth_Detail { get; set; }
        public string Breathing_Problem { get; set; }
        public string Baby_Position { get; set; }
        public string Pregnancy { get; set; }
    }
}