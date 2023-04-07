using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QRSCS.Common.SpeechCaseHistory
{
    public class ExpressiveLangauageModel
    {
        public int Expressive_Langauage_ID { get; set; }
        public int Speach_Case_History_ID { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Babble { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string First_Word { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Combine_2_Word { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Complete_Sentence { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Gestures { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Phrases { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Sing_Language { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Sentence { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Words { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Conversation_Ex_Text { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string When_Did_Concerned_Child_Speech { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Caused_Your_Child_Difficulty { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Worse_Better_Overtime { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Self_Consious_Speech_Langauge { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Speech_Language_Hearing_Family { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Professionals_Seen_Child { get; set; }

    }
}