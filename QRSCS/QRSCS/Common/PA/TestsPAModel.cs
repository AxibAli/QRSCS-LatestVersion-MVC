using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRSCS.Common.PA
{
    public class TestsPAModel
    {
        public int TestsPA_ID { get; set; }
        public int PA_ID { get; set; }
        public string Solosson_Intelligence_Test { get; set; }
        public string Draw_A_Person_Test { get; set; }
        public string Colored_Progressive_Matrices { get; set; }
        public string Standard_Progressive_Matrices { get; set; }
        public string Vineland_Adaptive_Behavior_Scales { get; set; }
        public string Childhood_Autism_Rating_Scale { get; set; }
        public string Attention_Deficit_Hyperactive_Disorder_Test { get; set; }
        public string Children_Apperception_Thematic_Test { get; set; }
        public string Personality_Assessment { get; set; }
    }
}