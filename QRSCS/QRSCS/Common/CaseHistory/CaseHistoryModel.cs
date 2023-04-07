using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QRSCS.Common.CaseHistory
{
    public class CaseHistoryModel
    {
        public int CaseHistory_ID { get; set; }

        public int GR_NO { get; set; }

        [Required(ErrorMessage = "Kindly Select Date of Examination")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date_of_Examination { get; set; }
    }
}