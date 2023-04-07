using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Models
{
    public class PsychologicalAssessmentModel
    {
        public int PA_ID { get; set; }
        public int GR_NO { get; set; }
        public DateTime Date { get; set; }
        public bool Solosson_Intelligence_Test { get; set; }
        public bool Draw_A_Person_Test { get; set; }
        public bool Colored_Progressive_Matrices { get; set; }
        public bool Standard_Progressive_Matrices { get; set; }
        public bool Vineland_Adaptive_Behavior_Scales { get; set; }
        public bool Childhood_Autism_Rating_Scale { get; set; }
        public bool Attention_Deficit_Hyperactive_Disorder_Test { get; set; }
        public bool Children_Apperception_Thematic_Test { get; set; }
        public bool Personality_Assessment { get; set; }






    }
}