using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QRSCS.Common.SpeechCaseHistory
{
    public class SpeechAndLanguageModel
    {
        public int Speach_and_Langauge_ID { get; set; }
        public int Speach_Case_History_ID { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Speech_Text { get; set; }
    }
}