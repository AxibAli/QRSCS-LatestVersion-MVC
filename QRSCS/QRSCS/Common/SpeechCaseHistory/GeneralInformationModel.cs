using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace QRSCS.Common.SpeechCaseHistory
{
    public class GeneralInformationModel
    {
        public int General_Information_ID { get; set; }
        public int Speach_Case_History_ID { get; set; }

        [Required(ErrorMessage = "Kindly Select Today's Date?")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Today_Date { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Child_Primary_Language { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Parent_Primary_Language { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Live_With_Both_Parents { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Child_Primary_Caregiver { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Child_Primary_Caregiver_Language { get; set; }
    }
}