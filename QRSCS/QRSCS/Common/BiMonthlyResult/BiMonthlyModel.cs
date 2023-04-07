using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QRSCS.Common.BiMonthlyResult
{
    public class BiMonthlyModel
    {
        public int Result_ID { get; set; }
        public int GR_NO { get; set; }
        public string Test_Type { get; set; }
        public int English { get; set; }
        public int Urdu { get; set; }
        public int Maths { get; set; }
        public int Science { get; set; }
        public int Social_Studies { get; set; }
        public int Islamiat { get; set; }
        public int Computer { get; set; }
        public int Speech { get; set; }
        public int Language { get; set; }
        public int Concepts { get; set; }
        public int Art_and_Drawing { get; set; }
        public int Sindhi { get; set; }
        public int Obtained_Total { get; set; }
        public int Percentage { get; set; }
        public string Grade { get; set; }
        public System.DateTime Result_Date { get; set; }
    }
}