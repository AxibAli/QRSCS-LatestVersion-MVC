using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QRSCS.Common.CaseHistory
{
    public class BehavioralObservationModel
    {
        public int Behavioral_Observation_Answer_ID { get; set; }
        public int CaseHistory_ID { get; set; }
        [Required(ErrorMessage = "Kindly Select a Behaviour?")]
        public string Aggressive { get; set; }
        [Required(ErrorMessage = "Kindly Select a Behaviour?")]
        public string Restlessness { get; set; }
        [Required(ErrorMessage = "Kindly Select a Behaviour?")]
        public string Impulsivity { get; set; }
        [Required(ErrorMessage = "Kindly Select a Behaviour?")]
        public string Distractibility { get; set; }
        [Required(ErrorMessage = "Kindly Select a Behaviour?")]
        public string Destructive { get; set; }
        [Required(ErrorMessage = "Kindly Select a Behaviour?")]
        public string Hyper_Active { get; set; }
        [Required(ErrorMessage = "Kindly Select a Behaviour?")]
        public string Tantrum { get; set; }
        [Required(ErrorMessage = "Kindly Select a Behaviour?")]
        public string Self_Stimulation { get; set; }
        [Required(ErrorMessage = "Kindly Select a Behaviour?")]
        public string Shyness { get; set; }
        [Required(ErrorMessage = "Kindly Select a Behaviour?")]
        public string Complain { get; set; }
        [Required(ErrorMessage = "Kindly Select a Behaviour?")]
        public string Dependence { get; set; }
        [Required(ErrorMessage = "Kindly Select a Behaviour?")]
        public string Low_Self_Image { get; set; }
        [Required(ErrorMessage = "Kindly Select a Behaviour?")]
        public string Add_ { get; set; }
        [Required(ErrorMessage = "Kindly Select a Behaviour?")]
        public string Short_Attention_Span { get; set; }
        [Required(ErrorMessage = "Kindly Select a Behaviour?")]
        public string Poor_Motivation { get; set; }
        [Required(ErrorMessage = "Kindly Select a Behaviour?")]
        public string Isolation_ { get; set; }
        [Required(ErrorMessage = "Kindly Select a Behaviour?")]
        public string Withdrawn { get; set; }
        [Required(ErrorMessage = "Kindly Select a Behaviour?")]
        public string Asocial { get; set; }

    }
}