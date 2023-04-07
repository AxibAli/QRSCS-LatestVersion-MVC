using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QRSCS.Models
{
    public class Student_Result_StatusModel
    {
        public int GR_NO { get; set; }
        public int Class { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Presentage { get; set; }
        public string CurrentClass { get; set; }
        public string Result { get; set; }
        public string Year { get; set; }
    }
}