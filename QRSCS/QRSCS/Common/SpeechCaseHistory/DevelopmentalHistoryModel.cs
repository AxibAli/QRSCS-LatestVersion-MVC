using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace QRSCS.Common.SpeechCaseHistory
{
    public class DevelopmentalHistoryModel
    {
        public int Developmental_History_ID { get; set; }
        public int Speach_Case_History_ID { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Use_Single_Word { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Combine_Word { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Name_Single_Object { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Use_Simple_Sentence { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Engage_Conversation { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Consistently_Sound { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Difficulty_Hearing_Speech { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string HearingTest_Where_When { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Diificult_Understand_Speech { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string SpecificSounds_Incoorectly { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Difficulty_Understanding_Direction { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Difficulty_PlayActivities { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Engage_Excussive_Repetition_Word { get; set; }

        [Required(ErrorMessage = "Kindly Enter Your Answer?")]
        public string Feeding_Problem { get; set; }


    }
}