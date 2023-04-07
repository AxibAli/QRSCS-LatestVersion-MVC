using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QRSCS.Models
{
    public class SpeechAssessmentDTO
    {
        public string Name { get; set; }
        public string Father_Name { get; set; }
        public string Disability { get; set; }
        public string Year { get; set; }
        public int Marks { get; set; }
    }
}