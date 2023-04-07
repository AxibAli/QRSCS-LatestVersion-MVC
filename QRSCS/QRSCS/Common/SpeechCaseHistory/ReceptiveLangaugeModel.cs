using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QRSCS.Common.SpeechCaseHistory
{
    public class ReceptiveLangaugeModel
    {
        public int Receptive_langauge_ID { get; set; }
        public int Speach_Case_History_ID { get; set; }

        [Required(ErrorMessage = "Kindly Select Your Answer?")]
        public string Single_Words { get; set; }

        [Required(ErrorMessage = "Kindly Select Your Answer?")]
        public string Yes_No_Questions { get; set; }

        [Required(ErrorMessage = "Kindly Select Your Answer?")]
        public string Sentences { get; set; }

        [Required(ErrorMessage = "Kindly Select Your Answer?")]
        public string WH_Questions { get; set; }

        [Required(ErrorMessage = "Kindly Select Your Answer?")]
        public string Routine_Questions { get; set; }

        [Required(ErrorMessage = "Kindly Select Your Answer?")]
        public string Conversation_Text { get; set; }
    }
}