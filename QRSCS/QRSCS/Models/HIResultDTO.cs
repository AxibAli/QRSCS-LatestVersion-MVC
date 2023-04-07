using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QRSCS.Common.BiMonthlyResult;
using QRSCS.Common.FinalResult;

namespace QRSCS.Models
{
    public class HIResultDTO
    {
        public BiMonthlyModel biMonthlyModel { get; set; }
        public FinalResultModel finalResultModel { get; set; }
    }
}